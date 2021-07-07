using System;
using DataAccessLayer;
using DataTransferObject;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class BllManager : IDisposable
    {
        private DalManager dalmanager;
        public BllManager()
        {
            dalmanager = new DalManager();
        }

        public void LoadFile(String file, int max)
        {
            dalmanager.LoadTextFileInDB(file, max);
        }

        public List<LightActorDTO> GetListActorsByIdFilm(int IdF)
        {
            Film TmpF = dalmanager.SelectFilmWithId(IdF);

            List<LightActorDTO> LActor = new List<LightActorDTO>();

            foreach(Actor a in TmpF.Actors)
            {
                LActor.Add(new LightActorDTO(a.IdActor, a.Name, a.Surname));
            }

            return (LActor);
        }

        public List<FilmTypeDTO> GetListFilmTypesByIdFilm(int IdF)
        {
            Film TmpFilm = dalmanager.SelectFilmWithId(IdF);

            List<FilmTypeDTO> LFT = new List<FilmTypeDTO>();

            foreach (FilmType tmpft in TmpFilm.FilmTypes)
            {
                LFT.Add(new FilmTypeDTO(tmpft.IdFilmType, tmpft.Name));
            }
            return (LFT);
        }

        public List<FilmDTO> FindListFilmByPartialActorName(String name, int maxfilm)
        {
            var listactor = dalmanager.SelectActorWithName(name);

            List<FilmDTO> ListFilm = new List<FilmDTO>();

            foreach(Actor a in listactor)
            {
                foreach(Film f in a.Films)
                {
                    List<CommentDTO> Comments = new List<CommentDTO>();
                    foreach(Comment c in f.Comments)
                    {
                        Comments.Add(new CommentDTO(c.Content, c.Rate, c.Username, c.Date));
                    }
                    ListFilm.Add(new FilmDTO(f.IdFilm, f.Title, f.ReleaseDate, f.VoteAverage, f.RunTime, f.PosterPath, Comments));
                }
            }

            ListFilm.RemoveRange(maxfilm - 1, ListFilm.Count - maxfilm);

            return (ListFilm);
        }

        public List<ActorDTO> GetFavoriteActors(int NbMinFilm, int maxActeur)
        {
            var listeAct = dalmanager.SelectActorNbFilmMin(NbMinFilm);

            List<ActorDTO> ListFavAct = new List<ActorDTO>();
            int i = 0;

            foreach (Actor a in listeAct)
            {
                i++;
                if (i > maxActeur)
                    break;
                ListFavAct.Add(new ActorDTO(a.IdActor, a.Name, a.Surname, a.Films.Count));
            }

            return (ListFavAct);
        }

        public List<FilmDTO> GetPageOfFilmDTOOrderByTitle(int index, int nbbypage)
        {
            var PageFIlm = dalmanager.GetPageOfFilmOrderByTitle(index, nbbypage);

            List<FilmDTO> Page = new List<FilmDTO>();

            foreach (Film f in PageFIlm)
            {
                List<CommentDTO> Comments = new List<CommentDTO>();
                foreach (Comment c in f.Comments)
                {
                    Comments.Add(new CommentDTO(c.Content, c.Rate, c.Username, c.Date));
                }
                Page.Add(new FilmDTO(f.IdFilm, f.Title, f.ReleaseDate, f.VoteAverage, f.RunTime, f.PosterPath, Comments));
            }
            return (Page);
        }

        public List<FilmDTO> GetFilmListWithName(string name, int index, int nbbypage)
        {
            var lf = dalmanager.GetFilmListWithName(name, index, nbbypage);

            List<FilmDTO> ListFilm = new List<FilmDTO>();

            foreach (Film f in lf)
            {
                List<CommentDTO> Comments = new List<CommentDTO>();
                foreach (Comment c in f.Comments)
                {
                    Comments.Add(new CommentDTO(c.Content, c.Rate, c.Username, c.Date));
                }
                ListFilm.Add(new FilmDTO(f.IdFilm, f.Title, f.ReleaseDate, f.VoteAverage, f.RunTime, f.PosterPath, Comments));
            }
            return (ListFilm);
        }

        public FullFilmDTO GetFullFilmDetailsByIdFilm(int IDF)
        {
            Film film = dalmanager.SelectFilmWithId(IDF);

            List<FilmTypeDTO> FilmTypes = new List<FilmTypeDTO>();
            foreach (FilmType ft in film.FilmTypes)
            {
                FilmTypes.Add(new FilmTypeDTO(ft.IdFilmType, ft.Name));
            }
            List<ActorDTO> Actors = new List<ActorDTO>();
            foreach (Actor a in film.Actors)
            {
                Actors.Add(new ActorDTO(a.IdActor, a.Name, a.Surname, a.Films.Count));
            }
            List<CommentDTO> Comments = new List<CommentDTO>();
            foreach (Comment c in film.Comments)
            {
                Comments.Add(new CommentDTO(c.Content, c.Rate, c.Username, c.Date));
            }

            return (new FullFilmDTO(film.IdFilm, film.Title, film.ReleaseDate, film.VoteAverage, film.RunTime, film.PosterPath, FilmTypes, Actors, Comments));
        }

        public Boolean InsertCommentOnFilmId(int IDF, CommentDTO c)
        {
            Film f = dalmanager.SelectFilmWithId(IDF);
            if (f != null)
                dalmanager.InsertComment(new Comment(c.Content, c.Rate, c.Username, c.Date, f));
            else
                return (false);
            return (true);
        }

        public void Dispose() { }
    }
}

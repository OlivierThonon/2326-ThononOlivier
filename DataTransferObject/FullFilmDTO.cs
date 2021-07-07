using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class FullFilmDTO
    {
        public FullFilmDTO()
        {
            FilmTypes = new List<FilmTypeDTO>();
            Actors = new List<ActorDTO>();
            Comments = new List<CommentDTO>();
        }
        public FullFilmDTO(int id, String title, DateTime releaseDate, float voteaverage, int runtime, String posterpath, List<FilmTypeDTO> filmtypes, List<ActorDTO> actors, List<CommentDTO> comments)
        {
            IdFilm = id;
            Title = title;
            RealseaseDate = releaseDate;
            VoteAverage = voteaverage;
            RunTime = runtime;
            PosterPath = posterpath;
            FilmTypes = filmtypes;
            Actors = actors;
            Comments = comments;
        }

        public int IdFilm { get; set; }
        public String Title { get; set; }
        public DateTime RealseaseDate { get; set; }
        public float VoteAverage { get; set; }
        public int RunTime { get; set; }
        public String PosterPath { get; set; }
        public ICollection<FilmTypeDTO> FilmTypes { get; set; }
        public ICollection<ActorDTO> Actors { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        override public String ToString()
        {
            return ("Id Film : " + IdFilm + "\nTitle : " + Title);
        }
    }
}

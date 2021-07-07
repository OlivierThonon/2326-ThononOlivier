using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Text;

namespace DataAccessLayer
{
    public class DalManager
    {
        public FilmContext filmContext;

        /*
         * https://stackoverflow.com/questions/40643238/entity-framework-not-returning-related-objects
         * https://docs.microsoft.com/fr-fr/ef/ef6/querying/related-data?redirectedfrom=MSDN
         * https://docs.microsoft.com/fr-fr/ef/ef6/querying/related-data?redirectedfrom=MSDN
         * https://www.entityframeworktutorial.net/lazyloading-in-entity-framework.aspx
         * https://stackoverflow.com/questions/11469432/entity-framework-code-first-lazy-loading
         * 
         * 
         * */
        public DalManager()
        {
            filmContext = new FilmContext();
        }

        public Film SelectFilmWithId(int IDF)
        {
            return (filmContext.Films.Include("Actors").Include("FilmTypes").Include("Comments").FirstOrDefault(f => f.IdFilm == IDF));
        }

        public IQueryable<Film> GetPageOfFilmOrderByTitle(int index, int numberbypage)
        {
            return filmContext.Films.OrderBy(f => f.Title).Skip(index).Take(numberbypage);
        }

        public IQueryable<Film> GetFilmListWithName(string name, int index, int numberbypage)
        {
            return filmContext.Films.OrderBy(f => f.Title).Where(f => f.Title.ToLower().Contains(name.ToLower())).Skip(index).Take(numberbypage);
        }

        public IQueryable<Actor> SelectActorWithName(String name)
        {
            return filmContext.Actors.Include("Films").Where(a => a.Name.ToLower().Contains(name.ToLower()));
        }

        public IQueryable<Actor> SelectActorNbFilmMin(int NbFilmMin)
        {
            return filmContext.Actors.Include("Films").Where(a => a.Films.Count >= NbFilmMin).OrderBy(a => a.Films.Count);
        }

        public void InsertComment(Comment c)
        {
            filmContext.Comments.Add(c);
            filmContext.SaveChanges();
        }

        public void LoadTextFileInDB(String file, int NbFilmToLoad)
        {
            Console.WriteLine("Test lecture fichier");

            var f = new StreamReader(file);
            //Console.WriteLine("Data peut se co : " + CtxDB.Database.CanConnect());

            List<Film> TempLFilm = new List<Film>();
            List<FilmType> TempLTypeFilm = new List<FilmType>();
            List<Actor> TempLActor = new List<Actor>();


            for (int i = 0; i < NbFilmToLoad; i++)
            {
                var line = f.ReadLine();
                if (line == null);
                else
                {
                    //Console.WriteLine("----------------------------\n Nouveau film !!! \n");
                    Char[] delimiterChars = { '\u2023' };
                    var filmdetailwords = line.Split(delimiterChars);

                    Film film = new Film();

                    //Console.WriteLine("f.Id "+ Int32.Parse(filmdetailwords[0]));
                    film.IdFilm = Int32.Parse(filmdetailwords[0], 0);
                    Console.WriteLine("N°Ligne : " + i + "f.Title " + filmdetailwords[1]);
                    film.Title = filmdetailwords[1];
                    //Console.WriteLine("f.Date " + filmdetailwords[3]);
                    try
                    {
                        film.ReleaseDate = Convert.ToDateTime(filmdetailwords[3]);
                    }
                    catch (System.FormatException) { };
                    //Console.WriteLine("f.Runtime " + Int32.Parse(filmdetailwords[7]));
                    film.RunTime = Int32.Parse(filmdetailwords[7], 0);
                    //Console.WriteLine("f.Posterpath " + filmdetailwords[9]);
                    film.PosterPath = filmdetailwords[9];

                    delimiterChars[0] = '\u2016';
                    if (filmdetailwords.Length == 15)
                    {
                        var genres = filmdetailwords[12].Split(delimiterChars);
                        //Console.WriteLine("Genre : ");
                        foreach (string s in genres)
                        {
                            if (s.Length > 0)
                            {
                                FilmType filmtype = new FilmType(s);

                                int IndexFT = TempLTypeFilm.FindIndex(genre => genre.IdFilmType == filmtype.IdFilmType);
                                if (IndexFT == -1)
                                {
                                    //Console.WriteLine("Ajout type de film : " + filmtype);
                                    TempLTypeFilm.Add(filmtype);
                                    film.FilmTypes.Add(TempLTypeFilm[TempLTypeFilm.Count - 1]);
                                }
                                else
                                {
                                    //Console.WriteLine("Utilisation type de film : " + TempLTypeFilm[IndexFT]);
                                    film.FilmTypes.Add(TempLTypeFilm[IndexFT]);
                                }
                            }

                        }
                        var acteurs = filmdetailwords[14].Split(delimiterChars);
                        //Console.WriteLine("Acteur : ");
                        foreach (string s in acteurs)
                        {
                            if (s.Length > 0)
                            {
                                Actor acteur = new Actor(s);

                                int IndexActor = TempLActor.FindIndex(act => act.IdActor == acteur.IdActor);
                                if (IndexActor == -1)
                                {
                                    //Console.WriteLine("Ajout d'un acteur : " + acteur);
                                    TempLActor.Add(acteur);
                                    film.Actors.Add(TempLActor[TempLActor.Count - 1]);
                                }
                                else
                                {
                                    //Console.WriteLine("Utilisation d'un acteur : " + TempLActor[IndexActor]);
                                    film.Actors.Add(TempLActor[IndexActor]);
                                }
                            }
                        }
                    }
                    TempLFilm.Add(film);
                }
            }
            using (FilmContext CtxDB = new FilmContext())
            {
                CtxDB.Database.EnsureDeleted();
                CtxDB.Database.EnsureCreated();
                CtxDB.AddRange(TempLTypeFilm);
                CtxDB.AddRange(TempLActor);
                CtxDB.SaveChanges();

                CtxDB.AddRange(TempLFilm);
                CtxDB.SaveChanges();
                CtxDB.Dispose();
            }
        }
    }
}

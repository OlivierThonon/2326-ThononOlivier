using System;
using System.Collections.Generic;
using System.Text;

namespace DTOClasses
{
    public class Film
    {
        public Film()
        {
            FilmTypes = new List<FilmType>();
            Actors = new List<Actor>();
            Comments = new List<Comment>();
        }
        public Film(String Filmdata)
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdFilm { get; set; }
        public String Title { get; set; }
        public DateTime RealseaseDate { get; set; }
        public float VoteAverage { get; set; }
        public int RunTime { get; set; }
        public String PosterPath { get; set; }
        public virtual ICollection<FilmType> FilmTypes { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        override public String ToString()
        {
            return ("Id Film : " + IdFilm + "\nTitle : " + Title);
        }
    }
}

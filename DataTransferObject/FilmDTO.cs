using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class FilmDTO
    {
        public FilmDTO()
        {
            Comments = new List<CommentDTO>();
        }
        public FilmDTO(int id, String title, DateTime releaseDate, float voteaverage, int runtime, String posterpath, List<CommentDTO> comments)
        {
            IdFilm = id;
            Title = title;
            RealseaseDate = releaseDate;
            VoteAverage = voteaverage;
            RunTime = runtime;
            PosterPath = posterpath;
            Comments = comments;
        }

        public int IdFilm { get; set; }
        public String Title { get; set; }
        public DateTime RealseaseDate { get; set; }
        public float VoteAverage { get; set; }
        public int RunTime { get; set; }
        public String PosterPath { get; set; }
        public virtual ICollection<CommentDTO> Comments { get; set; }
        override public String ToString()
        {
            return ("Id Film : " + IdFilm + "\nTitle : " + Title);
        }
    }
}

using DataTransferObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;

namespace BrowserApp.Models
{
    public class FilmUiModel
    {
        public FilmUiModel(FilmDTO f)
        {
            IdFilm = f.IdFilm;
            Title = f.Title;
            RealseaseDate = f.RealseaseDate;
            VoteAverage = f.VoteAverage;

            int min = f.RunTime % 60;
            int hours = f.RunTime / 60;
            RunTime = hours.ToString() + "h" + min.ToString();
            PosterPath = f.PosterPath;

            Comments = f.Comments;
        }
        public int IdFilm { get; set; }
        public String Title { get; set; }
        public DateTime RealseaseDate { get; set; }
        public float VoteAverage { get; set; }
        public string RunTime { get; set; }
        public String PosterPath { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        override public String ToString()
        {
            return ("Id Film : " + IdFilm + "\nTitle : " + Title);
        }
    }
}
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfApp.Model
{
    public class FullFilmModel : FullFilmDTO
    {
        public FullFilmModel(FullFilmDTO f)
        {
            IdFilm = f.IdFilm;
            Title = f.Title;
            RealseaseDate = f.RealseaseDate;
            VoteAverage = f.VoteAverage;
            PosterPath = f.PosterPath;
            RunTime = f.RunTime;
            FilmTypes = f.FilmTypes;
            Actors = f.Actors;
            Comments = f.Comments;
            Poster = DataAccess.GetPosterFromTMDB(f.PosterPath);
        }

        public BitmapImage Poster { get; set; }
    }
}

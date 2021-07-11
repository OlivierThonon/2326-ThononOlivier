using DataTransferObject;
using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp.Model
{
    public class FilmModel
    {
        public FilmModel(FilmDTO ftmp)
        {
            IdFilm = ftmp.IdFilm;
            Title = ftmp.Title;
            RealseaseDate = ftmp.RealseaseDate;
            VoteAverage = ftmp.VoteAverage;

            int min = ftmp.RunTime % 60;
            int hours = ftmp.RunTime / 60;
            RunTime = hours.ToString() + "h" + min.ToString();
            Poster = DataAccess.GetPosterFromTMDB(ftmp.PosterPath);

            FilmType = new List<BitmapImage>();
        }
        public int IdFilm { get; set; }
        public String Title { get; set; }
        public DateTime RealseaseDate { get; set; }
        public float VoteAverage { get; set; }
        public string RunTime { get; set; }
        public BitmapImage Poster { get; set; }
        public List<BitmapImage> FilmType { get; set; }
    }
}



/*public FilmModel(FilmDTO ftmp)
        {
            IdFilm = ftmp.IdFilm;
            Title = ftmp.Title;
            RealseaseDate = ftmp.RealseaseDate;
            VoteAverage = ftmp.VoteAverage;
            RunTime = ftmp.RunTime;
            PosterPath = ftmp.PosterPath;
        }
        public int IdFilm {
            get { return IdFilm; }
            set {
                IdFilm = value;
                OnPropertyChanged("IdFilm");
            }
        }
        public String Title
        {
            get { return Title; }
            set
            {
                Title = value;
                OnPropertyChanged("Title");
            }
        }
        public DateTime RealseaseDate
        {
            get { return RealseaseDate; }
            set
            {
                RealseaseDate = value;
                OnPropertyChanged("RealseaseDate");
            }
        }
        public float VoteAverage
        {
            get { return VoteAverage; }
            set
            {
                VoteAverage = value;
                OnPropertyChanged("VoteAverage");
            }
        }
        public int RunTime
        {
            get { return RunTime; }
            set
            {
                RunTime = value;
                OnPropertyChanged("RunTime");
            }
        }
        public String PosterPath
        {
            get { return PosterPath; }
            set
            {
                PosterPath = value;
                OnPropertyChanged("PosterPath");
            }
        }*/
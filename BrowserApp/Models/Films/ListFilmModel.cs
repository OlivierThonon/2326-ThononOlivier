using DataTransferObject;
using System.Collections.Generic;

namespace BrowserApp.Models
{
    public class ListFilmModel
    {
        public ListFilmModel(List<FilmDTO> films)
        {
            Films = new List<FilmUiModel>();

            foreach (FilmDTO f in films)
            {
                Films.Add(new FilmUiModel(f));
            }
        }
        public ListFilmModel(List<FilmUiModel> films)
        {
            Films = films;
        }
        public ListFilmModel()
        {
            Films = new List<FilmUiModel>();
        }



        public List<FilmUiModel> Films { get; set; }



        public override string ToString()
        {
            return base.ToString();
        }
    }
}
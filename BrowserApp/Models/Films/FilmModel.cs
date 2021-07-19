using DataTransferObject;
using System.Collections.Generic;

namespace BrowserApp.Models
{
    public class FilmModel
    {
        public FilmModel(List<FilmDTO> films)
        {
            Films = new List<FilmUiModel>();

            foreach (FilmDTO f in films)
            {
                Films.Add(new FilmUiModel(f));
            }
        }
        public FilmModel(List<FilmUiModel> films)
        {
            Films = films;
        }
        public FilmModel()
        {
            Films = new List<FilmUiModel>();
        }



        public List<FilmUiModel> Films { get; set; }
        public int SelectedFilm { get; set; }



        public override string ToString()
        {
            return base.ToString();
        }
    }
}
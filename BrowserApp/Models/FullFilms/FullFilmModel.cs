using DataTransferObject;
using System.Collections.Generic;

namespace BrowserApp.Models
{
    public class FullFilmModel
    {
        public FullFilmModel(FullFilmDTO films)
        {
            Film = films;
        }

        public FullFilmModel()
        {
            Film = new FullFilmDTO();
        }



        public FullFilmDTO Film { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
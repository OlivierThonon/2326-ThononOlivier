using DataTransferObject;
using System.Collections.Generic;

namespace BrowserApp.Models
{
    public class FullFilmModel
    {
        public FullFilmModel(List<FullFilmDTO> films)
        {
            Films = films;
        }
        public FullFilmModel()
        {
            Films = new List<FullFilmDTO>();
        }



        public List<FullFilmDTO> Films { get; set; }



        public override string ToString()
        {
            return base.ToString();
        }
    }
}
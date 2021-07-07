using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class FilmTypeDTO
    {
        public FilmTypeDTO()
        {

        }
        public FilmTypeDTO(int id, String name)
        {
            IdFilmType = id;
            Name = name;
        }

        public int IdFilmType { get; set; }
        public String Name { get; set; }

        public override string ToString()
        {
            return ("Id : " + IdFilmType + " || Nom : " + Name);
        }
    }
}

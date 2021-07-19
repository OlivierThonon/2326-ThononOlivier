using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class ActorDTO
    {
        public ActorDTO()
        {

        }
        public ActorDTO(int id, String name, String surname, int filmcount)
        {
            IdActor = id;
            Name = name;
            Surname = surname;
            NbFilm = filmcount;
        }
        public int IdActor { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public int NbFilm { get; set; }
        public override string ToString()
        {
            return (Name + " " + Surname);
        }
    }
}

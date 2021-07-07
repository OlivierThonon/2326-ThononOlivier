using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class LightActorDTO
    {
        public LightActorDTO()
        {

        }
        public LightActorDTO(int id, String name, String surname)
        {
            IdActor = id;
            Name = name;
            Surname = surname;
        }
        public int IdActor { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }

        public override string ToString()
        {
            return ("Id acteur : " + IdActor + " || Prenom : " + Surname + " || Nom : " + Name);
        }
    }
}

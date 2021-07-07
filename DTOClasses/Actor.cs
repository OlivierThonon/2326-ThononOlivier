using System;
using System.Collections.Generic;
using System.Text;

namespace DTOClasses
{
    public class Actor
    {
        public Actor()
        {

        }
        public Actor(String AData)
        {
            var infoacteur = AData.Split('\u2024');
            IdActor = Int32.Parse(infoacteur[0], 0);
            var prenom = infoacteur[1].Split(" ");
            Surname = prenom[0];
            if(prenom.Length>1)
                Name = prenom[1];
            Films = new List<Film>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdActor { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public virtual ICollection<Film> Films { get; set; }

        public override string ToString()
        {
            return ("Id acteur : " + IdActor + " || Prenom : " + Surname + " || Nom : " + Name);
        }

    }
}

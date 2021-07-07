using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    public class FilmType
    {
        public FilmType()
        {

        }
        public FilmType(String GenreData)
        {
            var infogenre = GenreData.Split('\u2024');
            IdFilmType = Int32.Parse(infogenre[0], 0);
            Name = infogenre[1];
            Films = new List<Film>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdFilmType { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Film> Films { get; set; }

        public override string ToString()
        {
            return ("Id : " + IdFilmType + " || Nom : " + Name);
        }
    }
}

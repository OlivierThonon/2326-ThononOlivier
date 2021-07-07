using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DALClass
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(string content, int rate, string username, DateTime date, Film f)
        {
            Content = content;
            Rate = rate;
            Username = username;
            Date = date;
            film = f;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComment { get; set; }
        public String Content { get; set; }
        public int Rate { get; set; }
        public String Username { get; set; }
        public DateTime Date { get; set; }
        public virtual Film film { get; set; }

    }
}

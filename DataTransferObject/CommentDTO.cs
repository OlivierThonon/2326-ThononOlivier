using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class CommentDTO
    {
        public CommentDTO()
        {

        }
        public CommentDTO(CommentDTO c)
        {
            Content = c.Content;
            Rate = c.Rate;
            Username = c.Username;
            Date = c.Date;
        }

        public CommentDTO(string content, int rate, string username, DateTime date)
        {
            Content = content;
            Rate = rate;
            Username = username;
            Date = date;
        }


        public String Content { get; set; }
        public int Rate { get; set; }
        public String Username { get; set; }
        public DateTime Date { get; set; }
    }
}

using DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class FullFilmViewModel
    {
        public FullFilmModel film;
        public FullFilmViewModel(int id)
        {
            //Get the data from webapi
            var f = DataAccess.GetFullFilmFromApiWithId(id);
            film = new FullFilmModel(f);
        }

        public void AjouterCommentaire(int id, string Content, int Rate, string username)
        {
            DataAccess.InsertComment(id, Content, Rate, username);
            film.Comments.Add(new CommentDTO(Content, Rate, username, DateTime.Now));
        }
    }
}

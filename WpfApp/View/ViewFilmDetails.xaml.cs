using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.ViewModel;

namespace WpfApp.View
{
    /// <summary>
    /// Logique d'interaction pour FilmDetails.xaml
    /// </summary>
    public partial class ViewFilmDetails : Window
    {
        private FullFilmViewModel ffvm;
        public ViewFilmDetails()
        {
            InitializeComponent();
        }
        public ViewFilmDetails(FullFilmViewModel ffvm)
        {
            InitializeComponent();
            this.ffvm = ffvm;
            DataContext = ffvm.film;

            Genres.FontSize = 10;
            foreach(FilmTypeDTO ft in ffvm.film.FilmTypes)
            {
                Genres.Text = Genres.Text + ft.Name + "\n";
            }
        }

        private void AjouterCommentaire_Click(object sender, RoutedEventArgs e)
        {
            AjouterCommentaire.IsEnabled = false;
            ffvm.AjouterCommentaire(ffvm.film.IdFilm, TextComment.Text, (int)SlideRate.Value, TextUsername.Text);
        }
    }
}

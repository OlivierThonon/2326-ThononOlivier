using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Model;
using WpfApp.View;
using WpfApp.ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FilmViewModel fvm = new FilmViewModel();
        public MainWindow()
        {
            InitializeComponent();
            ViewFilm.FilmGrid.ItemsSource = fvm.datasource;
        }

        private void BNextPage_Click(object sender, RoutedEventArgs e)
        {
                fvm.GetNextPage();
        }

        private void BPreviousPage_Click(object sender, RoutedEventArgs e)
        {
                fvm.GetPreviousPage();
        }

        private void ValiderRecherche_Click(object sender, RoutedEventArgs e)
        {
            fvm.RechercherFilm(TextBoxRechercheFilm.Text);
        }

        private void ButtonDetails_Click(object sender, RoutedEventArgs e)
        {
            DataGridCellInfo sc = ViewFilm.FilmGrid.SelectedCells.FirstOrDefault();
            FilmModel SelectedFilm = (FilmModel)sc.Item;
            if(SelectedFilm != null)
            {
                FullFilmViewModel ffvm = new FullFilmViewModel(SelectedFilm.IdFilm);
                ViewFilmDetails fd = new ViewFilmDetails(ffvm);
                fd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un film !","Error");
            }
        }

        private void AnnulerRecherche_Click(object sender, RoutedEventArgs e)
        {
            fvm.StopResearch();
            TextBoxRechercheFilm.Text = "";
        }
    }
}

using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class FilmViewModel
    {
        private int index = 0;
        private int type = 0; //0 = Affichage par titre -- 1 = Affichage par recherche
        private int indexrecherche = 0;
        public FilmViewModel()
        {
            //Get the data from webapi
            List<FilmDTO> lf = DataAccess.GetFilmPageFromApi(index,5);

            datasource = new ObservableCollection<FilmModel>();

            UpdateData(lf);
        }

        public void RechercherFilm(string title)
        {
            if (title == "" || title == null)
            {
                StopResearch();
            }
            else
            {
                if (titleencours != title)
                {
                    type = 1;
                    indexrecherche = 0;
                    titleencours = title;

                    List<FilmDTO> lf;
                    lf = DataAccess.GetListFilmWithName(titleencours, indexrecherche, 5);
                    UpdateData(lf);
                }
            }
        }
        public void StopResearch()
        {
            type = 0;
            indexrecherche = 0;
            titleencours = null;

            List<FilmDTO> lf;
            lf = DataAccess.GetFilmPageFromApi(index, 5);
            UpdateData(lf);
        }

        public void GetNextPage()
        {
            List<FilmDTO> lf;
            if (type == 0)
            {
                index += 5;
                lf = DataAccess.GetFilmPageFromApi(index, 5);
            }
            else
            {
                indexrecherche += 5;
                lf = DataAccess.GetListFilmWithName(titleencours, indexrecherche, 5);
            }

            UpdateData(lf);
        }

        public void GetPreviousPage()
        {
            List<FilmDTO> lf;
            if (type == 0)
            {
                index -= 5;
                if (index < 0)
                    index = 0;
                lf = DataAccess.GetFilmPageFromApi(index, 5);
            }
            else
            {
                indexrecherche -= 5;
                if (indexrecherche < 0)
                    indexrecherche = 0;
                lf = DataAccess.GetListFilmWithName(titleencours, indexrecherche, 5);
            }

            UpdateData(lf);
        }

        private void UpdateData(List<FilmDTO> lf)
        {
            datasource.Clear();

            foreach (var f in lf)
            {
                var tmp = new FilmModel(f);

                List<FilmTypeDTO> lft = DataAccess.GetFilmTypeFromApi(tmp.IdFilm);
                foreach (FilmTypeDTO ft in lft)
                {
                    tmp.FilmType.Add(DataAccess.GetFilmTypeIconFromData(ft.Name));
                }

                datasource.Add(tmp);
            }
        }

        public ObservableCollection<FilmModel> datasource { get; }
        private string titleencours;
    }
}

using BrowserApp.Models;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net;

namespace BrowserApp.Controllers
{
    public class FilmController : Controller
    {
        private ListFilmModel filmModel = new ListFilmModel();

        private int index = 0;
        private int nbFilmByPage = 10;


        public FilmController()
        {
            GetFilmFromApi();
        }

        public IActionResult Index()
        {
            return View(filmModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }








        private void NextPage()
        {
            index += nbFilmByPage;

            GetFilmFromApi();
        }
        private void PreviousPage()
        {
            index -= nbFilmByPage;
            if (index <= 0)
                index = 0;

            GetFilmFromApi();
        }

        private void GetFilmFromApi ()
        {
            string querytype = "films/";
            string query = "?index=" + index + "&numberfilmbypage=" + nbFilmByPage;

            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (ConfigurationManager.AppSettings["ApiURL"] + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                List<FilmDTO> lf = JsonConvert.DeserializeObject<List<FilmDTO>>(rawJson);

                filmModel = new ListFilmModel(lf);

            }
        }
    }
}

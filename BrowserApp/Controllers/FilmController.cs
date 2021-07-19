using BrowserApp.Models;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;

namespace BrowserApp.Controllers
{
    public class FilmController : Controller
    {
        private FilmModel filmModel = new FilmModel();

        private static int index;
        private static int nbFilmByPage = 10;




        public FilmController() { }

        public IActionResult Index()
        {
            GetFilmFromApi();

            return View(filmModel);
        }

        public IActionResult NextPage()
        {
            index += nbFilmByPage;

            GetFilmFromApi();

            return View("Index", filmModel);
        }
        public IActionResult PreviousPage()
        {
            index -= nbFilmByPage;
            if (index <= 0)
                index = 0;

            GetFilmFromApi();

            return View("Index", filmModel);
        }


        private void GetFilmFromApi()
        {
            List<FilmDTO> lf;

            string querytype = "films/";
            string query = "?index=" + index + "&numberfilmbypage=" + nbFilmByPage;

            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (ConfigurationManager.AppSettings["ApiURL"] + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                lf = JsonConvert.DeserializeObject<List<FilmDTO>>(rawJson);
            }

            filmModel = new FilmModel(lf);
        }
    }
}

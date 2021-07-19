using BrowserApp.Models;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;

namespace BrowserApp.Controllers
{
    public class ResearchController : Controller
    {
        private ResearchModel rmodel;

        private static int FilmIndex;
        private static int ActorIndex;
        private static int nbByPage = 10;

        private static string Title;
        private static string Name;

        public ResearchController() { }

        public IActionResult Index()
        {
            rmodel = new ResearchModel();

            return View(rmodel);
        }

        public IActionResult Research(string title, string name)
        {
            Title = title;
            Name = name;

            if (title != null)
                GetFilmsFromApi();
            else
                GetActorFromApi();

            return View("Index", rmodel);
        }

        public IActionResult PreviousFilmPage()
        {
            FilmIndex -= nbByPage;
            if (FilmIndex < 0)
                FilmIndex = 0;

            GetFilmsFromApi();

            return View("Index", rmodel);
        }

        public IActionResult NextFilmPage()
        {
            FilmIndex += nbByPage;

            GetFilmsFromApi();

            return View("Index", rmodel);
        }

        public IActionResult PreviousActorPage()
        {
            ActorIndex -= nbByPage;
            if (ActorIndex < 0)
                ActorIndex = 0;

            GetActorFromApi();

            return View("Index", rmodel);
        }

        public IActionResult NextActorPage()
        {
            ActorIndex += nbByPage;

            GetActorFromApi();

            return View("Index", rmodel);
        }


        private void GetActorFromApi()
        {
            string querytype = "actors/";
            string query = "name=" + Name + "?index=" + ActorIndex + "&numberactorbypage=" + nbByPage;

            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (ConfigurationManager.AppSettings["ApiURL"] + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                rmodel = new ResearchModel(JsonConvert.DeserializeObject<List<ActorDTO>>(rawJson));
            }
        }
        private void GetFilmsFromApi()
        {
            string querytype = "films/";
            string query = "title=" + Title + "?index=" + FilmIndex + "&numberfilmbypage=" + nbByPage;

            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (ConfigurationManager.AppSettings["ApiURL"] + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                rmodel = new ResearchModel(JsonConvert.DeserializeObject<List<FilmDTO>>(rawJson));
            }
        }
    }
}

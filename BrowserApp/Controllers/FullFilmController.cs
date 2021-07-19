using BrowserApp.Models;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;

namespace BrowserApp.Controllers
{
    public class FullFilmController : Controller
    {
        public FullFilmController() { }

        public IActionResult Index(int idfilm)
        {
            ffmodel = new FullFilmModel(GetFullFilmFromApi(idfilm));

            return View(ffmodel);
        }

        public IActionResult AddComment(string pseudo, string content, int rate)
        {
            InsertComment(ffmodel.Film.IdFilm, content, rate, pseudo);

            return View("Index", ffmodel);
        }


        private FullFilmDTO GetFullFilmFromApi(int id)
        {
            string querytype = "films/details/";
            string query = "idfilm=" + id;

            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (ConfigurationManager.AppSettings["ApiURL"] + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                return JsonConvert.DeserializeObject<FullFilmDTO>(rawJson);
            }
        }

        private void InsertComment(int id, string Content, int Rate, string username)
        {
            string querytype = "comments/";
            string querystring = "?username=" + username + "&content=" + Content + "&rate=" + Rate + "&idfilm=" + id;

            using (var client = new HttpClient())
            {
                var q = ConfigurationManager.AppSettings["ApiURL"] + querytype + querystring;
                HttpResponseMessage r = client.PostAsync(q, null).Result;

                if (!r.IsSuccessStatusCode)
                {
                    Console.WriteLine("[ShellModel][getImage]Api error");
                }
            }
        }

        public static FullFilmModel ffmodel { get; set; }
    }
}

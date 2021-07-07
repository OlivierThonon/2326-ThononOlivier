using DataTransferObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Media.Imaging;
using WpfApp.Model;

namespace WpfApp
{
    static class DataAccess
    {
        static string TheMovieDbKey = "9edd5c4cf5ae54ee66319017c75668fc";
        static string HostWebApi = "http://localhost:5000/filmapi/";
        static string HostTMDB = "https://api.themoviedb.org/3/movie/";
        static string HostPosters = "https://image.tmdb.org/t/p/original";

        // NOTE: Replace this example key with a valid subscription key.

        public static List<FilmDTO> GetFilmPageFromApi(int index, int nbFilmByPage)
        {
            string querytype = "films/details/";
            string query = "?index=" + index + "&numberfilmbypage=" + nbFilmByPage;
            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (HostWebApi + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                List<FilmDTO> lf = JsonConvert.DeserializeObject<List<FilmDTO>>(rawJson);

                return (lf);
            }
        }

        public static void InsertComment(int id,string Content, int Rate)
        {
            string querytype = "comments/";

            var query = new
            {
                content = Content,
                rate = Rate,
                idfilm = id
            };
            string querystring = JsonConvert.SerializeObject(query);

            using (var client = new HttpClient())
            {
                HttpResponseMessage r = client.PostAsync(HostWebApi + querytype, new StringContent(querystring)).Result;

                if (!r.IsSuccessStatusCode)
                {
                    Console.WriteLine("[ShellModel][getImage]Api error");
                }
            }
        }

        public static FullFilmDTO GetFullFilmFromApiWithId(int id)
        {
            string querytype = "films/details/";
            string query = "idfilm=" + id;
            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (HostWebApi + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                FullFilmDTO f = JsonConvert.DeserializeObject<FullFilmDTO>(rawJson);

                return (f);
            }
        }

        public static List<FilmTypeDTO> GetFilmTypeFromApi(int id)
        {
            string querytype = "filmtypes/";
            string query = "idfilm=" + id;
            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (HostWebApi + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                List<FilmTypeDTO> lf = JsonConvert.DeserializeObject<List<FilmTypeDTO>>(rawJson);

                return (lf);
            }
        }

        public static List<FilmDTO> GetListFilmWithName(string title, int index, int nbFilmByPage)
        {
            string querytype = "films/";
            string query = "title=" + title + "?index=" + index + "&numberfilmbypage=" + nbFilmByPage;
            using (var client = new WebClient())
            {
                //Get a string representation of the Json
                String finalQuery = (HostWebApi + querytype + query);
                String rawJson = client.DownloadString(finalQuery);

                List<FilmDTO> lf = JsonConvert.DeserializeObject<List<FilmDTO>>(rawJson);

                return (lf);
            }
        }

        public static BitmapImage GetPosterFromTMDB(int id)
        {
            string query = id + "?api_key=" + TheMovieDbKey;

            using (var client = new HttpClient())
            {
                HttpResponseMessage r = client.GetAsync(HostTMDB + query).Result;

                if(!r.IsSuccessStatusCode)
                {
                    Console.WriteLine("[ShellModel][getImage]Api error");
                    return null;
                }

                //String rawJson = client.DownloadString(finalQuery);
                string rawJson = r.Content.ReadAsStringAsync().Result;

                var data = (JObject)JsonConvert.DeserializeObject(rawJson);
                String newPath = data["poster_path"].Value<string>();

                return new BitmapImage(new Uri(HostPosters + newPath));
            }
        }

        public static BitmapImage GetFilmTypeIconFromData(string name)
        {
            //AppContext.BaseDirectory +"/"+ name +".jpg"
            var a = new Uri("C:\\Users\\Oli\\source\\repos\\hepl-csa-student20\\laboprognet-2326-thononolivier\\WpfApp\\Image\\" + name.ToLower() + ".png");
            Console.WriteLine(a.AbsolutePath);
            try
            {
                var image = new BitmapImage(a);
                return (image);
            }
            catch(System.IO.FileNotFoundException)
            {
                return (new BitmapImage());
            }
        }
    }
}

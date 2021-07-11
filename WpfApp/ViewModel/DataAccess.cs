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
            string querytype = "films/";
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
            string querystring = "?content=" + Content + "&rate=" + Rate + "&idfilm=" + id;

            using (var client = new HttpClient())
            {
                var q = HostWebApi + querytype + querystring;
                HttpResponseMessage r = client.PostAsync(q, null).Result;

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

        public static BitmapImage GetPosterFromTMDB(String posterpath)
        {
            if (posterpath != null)
            {
                using (var client = new HttpClient())
                {
                    return new BitmapImage(new Uri(posterpath));
                }
            }
            else
                return (new BitmapImage());
           
        }

        public static BitmapImage GetFilmTypeIconFromData(string name)
        {
            //AppContext.BaseDirectory +"/"+ name +".jpg"
            var a = new Uri("C:\\Users\\Oli\\source\\repos\\2326-ThononOlivier\\WpfApp\\Image\\" + name.ToLower() + ".png");
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

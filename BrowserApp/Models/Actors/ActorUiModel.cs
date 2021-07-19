using DataTransferObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;

namespace BrowserApp.Models
{
    public class ActorUiModel
    {
        public ActorUiModel()
        {

        }

        public ActorUiModel(ActorDTO actor)
        {
            var data = GetActorFromApi(actor.IdActor);

            String bio = null;
            String profile_path = null;
            Nullable<DateTime> birthdate = null;
            Nullable<DateTime> deathdate = null;

            JToken token;

            token = data["biography"];
            if (!IsNullOrEmpty(token))
                bio = data.Value<string>("biography");
            token = data["profile_path"];
            if (!IsNullOrEmpty(token))
                profile_path = data.Value<string>("profile_path");

            token = data["birthday"];
            if (!IsNullOrEmpty(token))
                birthdate = data.Value<DateTime>("birthday");
            token = data["deathday"];
            if (!IsNullOrEmpty(token))
                deathdate = data.Value<DateTime>("deathday");


            IdActor = actor.IdActor;
            Name = actor.Name;
            Surname = actor.Surname;
            NbFilm = actor.NbFilm;
            ProfileImagePath = ConfigurationManager.AppSettings["HostPosters"] + profile_path;
            Bio = bio;
            BirthDate = birthdate;
            DeathDate = deathdate;
        }

        public ActorUiModel(int id, String name, String surname, int filmcount, string profileimagepath, string bio, Nullable<DateTime> birthdate, Nullable<DateTime> deathdate)
        {
            IdActor = id;
            Name = name;
            Surname = surname;
            NbFilm = filmcount;
            ProfileImagePath = ConfigurationManager.AppSettings["HostPosters"] + profileimagepath;
            Bio = bio;
            BirthDate = birthdate;
            DeathDate = deathdate;
        }


        public int IdActor { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public int NbFilm { get; set; }
        public String ProfileImagePath { get; set; }
        public String Bio { get; set; }

        public Nullable<DateTime> BirthDate { get; set; }
        private Nullable<DateTime> DeathDate { get; set; }
        public String Age {
            get
            {
                if (BirthDate.HasValue)
                {
                    var calculatedage = DateTime.Now.Subtract(BirthDate.Value);

                    if (DeathDate.HasValue)
                        return "Mort(e) a l'age de " + ((new DateTime(1, 1, 1) + calculatedage).Year - 1) + "ans";
                    else
                        return "" + ((new DateTime(1, 1, 1) + calculatedage).Year - 1) + "ans";
                }
                else
                    return "Date de naissance inconnue";
            }
        }
        
        public override string ToString()
        {
            return (Name + " " + Surname);
        }
        private JObject GetActorFromApi(int idactor)
        {
            string querytype = "person/";

            string query = querytype + idactor + "?api_key=" + ConfigurationManager.AppSettings["TheMovieDbKey"];

            using (var client = new HttpClient())
            {
                HttpResponseMessage r = client.GetAsync(ConfigurationManager.AppSettings["HostTMDB"] + query).Result;

                if (!r.IsSuccessStatusCode)
                {
                    Console.WriteLine("[ShellModel][getImage]Api error");
                    return null;
                }
                else
                {
                    string rawJson = r.Content.ReadAsStringAsync().Result;

                    return (JObject)JsonConvert.DeserializeObject(rawJson);
                }
            }
        }
        public bool IsNullOrEmpty(JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                   (token.Type == JTokenType.Null);
        }
    }
}
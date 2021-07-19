using DataTransferObject;
using System.Collections.Generic;

namespace BrowserApp.Models
{
    public class ResearchModel
    {
        public ResearchModel(List<FilmDTO> films, List<ActorDTO> actors)
        {
            Films = new List<FilmUiModel>();
            foreach (FilmDTO f in films)
            {
                Films.Add(new FilmUiModel(f));
            }

            Actors = new List<ActorUiModel>();
            foreach(ActorDTO a in actors)
            {
                Actors.Add(new ActorUiModel(a));
            }
        }
        public ResearchModel(List<FilmDTO> films)
        {
            Films = new List<FilmUiModel>();
            foreach (FilmDTO f in films)
            {
                Films.Add(new FilmUiModel(f));
            }

            Actors = new List<ActorUiModel>();
        }
        public ResearchModel(List<ActorDTO> actors)
        {
            Actors = new List<ActorUiModel>();
            foreach (ActorDTO a in actors)
            {
                Actors.Add(new ActorUiModel(a));
            }

            Films = new List<FilmUiModel>();
        }

        public ResearchModel()
        {
            Films = new List<FilmUiModel>();
            Actors = new List<ActorUiModel>();
        }

        public List<FilmUiModel> Films { get; set; }
        public List<ActorUiModel> Actors { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
using DataTransferObject;
using System.Collections.Generic;

namespace BrowserApp.Models
{
    public class ActorModel
    {
        public ActorModel(ActorUiModel actor)
        {
            Actor = actor;
        }

        public ActorUiModel Actor { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
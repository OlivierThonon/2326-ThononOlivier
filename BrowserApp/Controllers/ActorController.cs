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
    public class ActorController : Controller
    {
        private ActorModel actorModel;


        public ActorController() { }

        public IActionResult Index(ActorDTO actor)
        {
            actorModel = new ActorModel(new ActorUiModel(actor));

            return View(actorModel);
        }
    }
}

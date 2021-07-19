using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("filmapi/actors")]
    public class ActorController : Controller
    {
        //http://localhost:5000/actors/35
        [HttpGet("idactor={id}")]
        public ActionResult GetListActorsByIdFilm(int id)
        {
            using (BllManager bllm = new BllManager())
            {
                var ret = bllm.GetListActorsByIdFilm(id);
                if (ret != null)
                    return Ok(ret);
                else
                    return BadRequest("NoResultFoud");
            }
        }

        //http://localhost:5000/actors/fav/50
        [HttpGet("fav/minfilm={NbFilm}")]
        public ActionResult GetFavoriteActors(int NbFilm)
        {
            using (BllManager bllm = new BllManager())
            {
                var ret = bllm.GetFavoriteActors(NbFilm, 20);
                if (ret != null)
                    return Ok(ret);
                else
                    return BadRequest("NoResultFoud");
            }
        }

        //http://localhost:5000/actors/name=fred
        [HttpGet("name={name}")]
        public ActionResult GetListActorsByName(string name, int index, int numberactorbypage)
        {
            using (BllManager bllm = new BllManager())
            {
                var ret = bllm.GetListActorsByName(name, index, numberactorbypage);
                if (ret != null)
                    return Ok(ret);
                else
                    return BadRequest("NoResultFoud");
            }
        }
    }
}

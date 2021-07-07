using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("filmapi/films")]
    public class FilmController : Controller
    {
        //http://localhost:5000/films/details/?index=0&numberfilmbypage=10
        [HttpGet("details")]
        public ActionResult GetPageOfFullFilmDetailsOrderByTitle(int index, int numberfilmbypage)
        {
            if (numberfilmbypage == 0)
                return BadRequest("Error in the request ! \nExemple : /films/details/?index=0&numberfilmbypage=10 || /films/details/2");

            using (BllManager bllm = new BllManager())
            {
                var ret = bllm.GetPageOfFilmDTOOrderByTitle(index, numberfilmbypage);
                if (ret != null)
                    return Ok(ret);
                else
                    return BadRequest("NoResultFoud");
            }
        }

        //http://localhost:5000/films/details/idfilm=2
        [HttpGet("details/idfilm={id}")]
        public ActionResult GetFullFilmDetailsByIdFilm(int id)
        {
            using (BllManager bllm = new BllManager())
            {
                var ret = bllm.GetFullFilmDetailsByIdFilm(id);
                if (ret != null)
                    return Ok(ret);
                else
                    return BadRequest("NoResultFoud");
            }
        }

        //http://localhost:5000/films/actorname=ste
        [HttpGet("actorname={actorname}")]
        public ActionResult FindListFilmByPartialActorName(string actorname, int maxfilm = 10)
        {
            using (BllManager bllm = new BllManager())
            {
                var ret = bllm.FindListFilmByPartialActorName(actorname, maxfilm);
                if (ret != null)
                    return Ok(ret);
                else
                    return BadRequest("NoResultFoud");
            }
        }

        //http://localhost:5000/films/title=si
        [HttpGet("title={title}")]
        public ActionResult GetFilmListWithName(string title, int index, int numberfilmbypage)
        {
            using (BllManager bllm = new BllManager())
            {
                var ret = bllm.GetFilmListWithName(title, index, numberfilmbypage);
                if (ret != null)
                    return Ok(ret);
                else
                    return BadRequest("NoResultFoud");
            }
        }
    }
}

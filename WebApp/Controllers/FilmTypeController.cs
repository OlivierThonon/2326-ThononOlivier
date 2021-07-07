using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("filmapi/filmtypes")]
    public class FilmTypeController : Controller
    {
        //http://localhost:5000/filmtypes/idfilm=2
        [HttpGet("idfilm={idfilm}")]
        public ActionResult GetListFilmTypesByIdFilm(int idfilm)
        {
            using (BllManager bllm = new BllManager())
            {
                var ret = bllm.GetListFilmTypesByIdFilm(idfilm);
                if (ret != null)
                    return Ok(ret);
                else
                    return BadRequest("NoResultFoud");
            }
        }
    }
}

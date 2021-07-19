using BusinessLogicLayer;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("filmapi/comments")]
    public class CommentController : Controller
    {
        //http://localhost:5000/comments/?username=Frizzzer&content=Test2k21&rate=3&idfilm=2
        [HttpPost]
        public ActionResult InsertCommentOnFilmId(String username, String content, int rate, int idfilm)
        {
            if (content == null || idfilm == 0)
                return BadRequest("Error in the request ! \nExemple : /films/?content=Exemple&rate=3&idfilm=2");

            using (BllManager bllm = new BllManager())
            {
                bllm.InsertCommentOnFilmId(idfilm, new CommentDTO(content, rate, username, DateTime.Now));
                return Ok("Commentaire inséré !");
            }
        }
    }
}

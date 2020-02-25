using DraterNew.Models.Class;
using DraterNew.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraterNew.Controllers.API
{
    public class VoteAPIController : Controller
    {
        [Route("Api/Vote/getNbVoteByRetard/{idRetard}")]
        [HttpGet]
        public ActionResult Index(int idRetard)
        {
            return Json(Vote.GetValueFromList(VoteRequest.getVoteByRetard(idRetard)));
        }

        [Route("Api/Vote/upVote")]
        [HttpPost]
        public ActionResult upVote(int idRetard, int idEleve)
        {
            return Json(Vote.GetValueFromList(VoteRequest.upVote(idRetard,idEleve)));
        }
    }
}
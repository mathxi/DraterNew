using DraterNew.Models.Class;
using DraterNew.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraterNew.Controllers.API
{
    [Authorize]
    public class VoteAPIController : Controller
    {
        [Route("Api/Vote/getNbVoteByRetard/{idRetard}")]
        [HttpGet]
        public ActionResult Index(int idRetard)
        {
            return Json(Vote.GetValueFromList(VoteRequest.getVoteByRetard(idRetard)), JsonRequestBehavior.AllowGet);
        }

        [Route("Api/Vote/upVote")]
        [HttpPost]
        public ActionResult upVote(int idRetard, int idEleve)
        {
            return Json(Vote.GetValueFromList(VoteRequest.changeVote(idRetard, long.Parse(User.Identity.Name), 1)));
        }

        [Route("Api/Vote/downVote")]
        [HttpPost]
        public ActionResult DownVote(int idRetard, int idEleve)
        {
            return Json(Vote.GetValueFromList(VoteRequest.changeVote(idRetard, long.Parse(User.Identity.Name), -1)));
        }

        [Route("Api/Vote/delete")]
        [HttpPost]
        public ActionResult DeleteVote(int idRetard)
        {
            return Json(Vote.GetValueFromList(VoteRequest.DeleteVote(idRetard, Convert.ToInt32(User.Identity.Name))));
        }

        [Route("Api/Vote/GetByRetard")]
        [HttpGet]
        public ActionResult GetByIdRetard(int idRetard)
        {
            return Json(VoteRequest.getVoteByRetard(idRetard), JsonRequestBehavior.AllowGet);
        }
    }
}
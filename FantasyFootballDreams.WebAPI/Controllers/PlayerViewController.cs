using FantasyFD.Models.Player;
using FantasyFD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FantasyFootballDreams.WebAPI.Controllers
{
    //[Authorize]
    public class PlayerViewController : Controller
    {
        /// <summary>GET: PlayerView </summary>
        public ActionResult Index()
        {
            PlayerService playerService = new PlayerService();
            return View(playerService.GetPlayer());
        }

        /// <summary>This is where I get html from </summary> Create
        [HttpGet] //
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] /// <summary>This is where it posts upon submit </summary>
        public ActionResult Create(CreatePlayer cp)
        {
            if (this.ModelState.IsValid)
            {
                PlayerController pc = new PlayerController();
                pc.Post(cp);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(cp);
            }
        }

        //Update
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(EditPlayer ep)
        {
            if (this.ModelState.IsValid)
            {
                PlayerController pc = new PlayerController();
                pc.Put(ep);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(ep);
            }
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            PlayerService playerService = new PlayerService();
            return View(playerService.GetPlayerByID(id));
        }
        [HttpPost]
        public ActionResult DeletePlayer(int id)
        {
            if (this.ModelState.IsValid)
            {
                PlayerController pc = new PlayerController();
                pc.Delete(id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(id);
            }
        }
    }
}
using FantasyFD.Models;
using FantasyFD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace FantasyFootballDreams.WebAPI.Controllers
{
    public class GameViewController : Controller
    {
        public ActionResult Index()
        {
            GameService gameService = new GameService();
            return View(gameService.GetGames());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GameCreate cg)
        {
            if(this.ModelState.IsValid)
            {
                GameController pc = new GameController();
                pc.Post(cg);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(cg);
            }
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(GameEdit ge)
        {
            if(this.ModelState.IsValid)
            {
                GameController pc = new GameController();
                pc.Put(ge);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(ge);
            }
        }
        [HttpGet]
        public ActionResult Delete(int gameId)
        {
            GameService gameService = new GameService();
            return View(gameService.GetGameById(gameId));
        }
        [HttpPost]
        public ActionResult DeleteGame(int id)
        {
            if(this.ModelState.IsValid)
            {
                GameController pc = new GameController();
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
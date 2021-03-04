using FantasyFD.Models.PlayerStats;
using FantasyFD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FantasyFootballDreams.WebAPI.Controllers
{
    public class PlayerStatsViewController : Controller
    {
        // GET: PlayerStatsView
        public ActionResult Index()
        {
            PlayerStatsService playerStatsService = new PlayerStatsService();
            return View(playerStatsService.GetPlayerStats());
        }

        //Create
        /// <summary>
        /// LOOKUP: redirect to action (take to another page)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreatePlayerStats cps)
        {
            if (this.ModelState.IsValid)
            {
                PlayerStatsController psc = new PlayerStatsController();
                psc.Post(cps);
                return RedirectToAction("Index", "Home");  
            }
            else
            {
                return View(cps);
            }
        }

        //Update
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(EditPlayerStats cps)
        {
            if (this.ModelState.IsValid)
            {
                PlayerStatsController psc = new PlayerStatsController();
                psc.Put(cps);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(cps);
            }
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            PlayerStatsService playerStatsService = new PlayerStatsService();
            return View(playerStatsService.GetPlayerStatsByID(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePlayerStats(int id)
        {
            if (this.ModelState.IsValid)
            {
                PlayerStatsController psc = new PlayerStatsController();
                psc.Delete(id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(id);
            }
        }
    }
}
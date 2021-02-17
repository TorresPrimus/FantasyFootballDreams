using FantasyFD.Models.PlayerStats;
using FantasyFD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FantasyFootballDreams.WebAPI.Controllers
{
    public class PlayerStatsController : ApiController
    {
        private PlayerStatsService CreatePlayerStatsService()
        {
            //var playerStatsID = Guid.Parse(User.Identity.GetUserId());
            //var playerStatsService = new PlayerStatsService(playerStatsID);
            //return playerStatsService;
            return new PlayerStatsService();
        }
        /// Looks up all Player Stats.
        public IHttpActionResult Get()
        {
            PlayerStatsService playerStatsService = CreatePlayerStatsService();
            var playerStats = playerStatsService.GetPlayerStats();
            return Ok(playerStats);
        }
        /// Creates a Player Stat with specific information.
        public IHttpActionResult Post(CreatePlayerStats playerStats)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlayerStatsService();
            if (!service.CreatePlayerStats(playerStats))
                return InternalServerError();
            return Ok();
        }
        /// Looks up a Player Stat by its ID.
        public IHttpActionResult Get(int id)
        {
            PlayerStatsService playerStatsService = CreatePlayerStatsService();
            var playerStats = playerStatsService.GetPlayerStatsByID(id);
            return Ok(playerStats);
        }
        /// Changes details about a Player Stat.
        public IHttpActionResult Put(EditPlayerStats playerStats)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlayerStatsService();
            if (!service.UpdatePlayerStats(playerStats))
                return InternalServerError();
            return Ok();
        }
        /// Deletes Player Stats by their ID.
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlayerStatsService();
            if (!service.DeletePlayerStats(id))
                return InternalServerError();
            return Ok();
        }
    }
}

using FantasyFD.Models;
using FantasyFD.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FantasyFootballDreams.WebAPI.Controllers
{
    /// <summary>
    /// The Main Team Controller Class
    /// </summary>
    [Authorize]
    public class TeamController : ApiController
    {
        private TeamService CreateTeamService()
        {
            var userName = Guid.Parse(User.Identity.GetUserId());
            var teamService = new TeamService(userName);
            return teamService;
        }

        /// <summary>
        /// This allows you to get all the Teams from the database.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            TeamService teamService = CreateTeamService();
            var teams = teamService.GetTeams();
            return Ok(teams);
        }
        /// <summary>
        /// This allows you to create a new team in the database.
        /// </summary>
        public IHttpActionResult Post(TeamCreate team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.CreateTeam(team))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// This allows you to get a specific team by their ID.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int teamId)
        {
            TeamService teamService = CreateTeamService();
            var team = teamService.GetTeamById(teamId);
            return Ok(team);
        }
        /// <summary>
        /// This allows you to update a teams name.
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public IHttpActionResult Put(TeamEdit team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var teamService = CreateTeamService();

            if (teamService.UpdateTeam(team))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// This allows you to delete a team from the database by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var teamService = CreateTeamService();
            if (!teamService.DeleteTeam(id))
                return InternalServerError();

            return Ok();
        }
    }
}

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
    [Authorize]
    public class TeamController : ApiController
    {
        private TeamService CreateTeamService()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var teamService = new TeamService(userId);
            return teamService;
        }
        public IHttpActionResult Get()
        {
            TeamService teamService = CreateTeamService();
            var teams = teamService.GetTeams();
            return Ok(teams);
        }
        public IHttpActionResult Post(TeamCreate team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.CreateTeam(team))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int teamId)
        {
            TeamService teamService = CreateTeamService();
            var team = teamService.GetTeamById(teamId);
            return Ok(team);
        }
        public IHttpActionResult Put(TeamEdit team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var teamService = CreateTeamService();

            if (teamService.UpdateTeam(team))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var teamService = CreateTeamService();
            if (!teamService.DeleteTeam(id))
                return InternalServerError();

            return Ok();
        }
    }
}

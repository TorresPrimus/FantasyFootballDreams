using FantasyFD.Models;
using Microsoft.AspNet.Identity;
using FantasyFD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace FantasyFootballDreams.WebAPI.Controllers
{
    [Authorize]
    public class GameController : ApiController
    {
        private GameService CreateGameService()
        {
            var gameId = int.Parse(User.Identity.GetUserId());
            var gameService = new GameService(gameId);
            return  new GameService();
        }
        public IHttpActionResult PutTeamsWithAGame(int gameId, AwayHome model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameService();
            if (!service.ConnectTeamWithGame(gameId,model))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get()
        {
            GameService gameService = CreateGameService();
            var games = gameService.GetGames();
            return Ok(games);
        }

        public IHttpActionResult Post(GameCreate games)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.CreateGame(games))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int gameId)
        {
            GameService gameService = CreateGameService();
            var games = gameService.GetGameById(gameId);
            return Ok(games);
        }

        public IHttpActionResult Put(GameEdit game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameService();
            if (!service.UpdateGame(game))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int gameId)
        {
            var service = CreateGameService();
            if (!service.DeleteGame(gameId))
                return InternalServerError();

            return Ok();
        }
    }
}
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
    /// <summary>
    /// Game Controller
    /// </summary>
    [Authorize]
    public class GameController : ApiController
    {
        private GameService CreateGameService()
        {
            //var gameId = int.Parse(User.Identity.GetUserId());
            //var gameService = new GameService(gameId);
            return new GameService();
        }
        /// <summary>
        /// Allows you to get a certian game by its ID. 
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public IHttpActionResult PutTeamsWithAGame(int gameId, AwayHome model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameService();
            if (!service.ConnectTeamWithGame(gameId,model))
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Places teams as Home and Away teams in a given game. 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            GameService gameService = CreateGameService();
            var games = gameService.GetGames();
            return Ok(games);
        }
        /// <summary>
        /// Shows a list of games.  
        /// </summary>
        /// <param name="games"></param>
        /// <returns></returns>
        public IHttpActionResult Post(GameCreate games)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.CreateGame(games))
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Posts the game results.
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int gameId)
        {
            GameService gameService = CreateGameService();
            var games = gameService.GetGameById(gameId);
            return Ok(games);
        }
        /// <summary>
        /// Allows you to get a game by its ID. 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public IHttpActionResult Put(GameEdit game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameService();
            if (!service.UpdateGame(game))
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Allows you to edit a game.
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int gameId)
        {
            var service = CreateGameService();
            if (!service.DeleteGame(gameId))
                return InternalServerError();

            return Ok();
        }
    }
}
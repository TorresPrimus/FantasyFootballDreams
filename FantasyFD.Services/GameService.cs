using FantasyFD.Data;
using FantasyFD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FantasyFD.Services
{
    public class GameService
    {
        private readonly int _gameId;

        public GameService(int gameId)
        {
            _gameId = gameId;
        }
        public GameService()
        {

        }
        public bool ConnectTeamWithGame(int gameId, AwayHome model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //grabbing a specific game via the URI
                var game =
                ctx
                .Games
                .Single(g => g.GameId == gameId);

                //grabbing the two specific teams from  our model that the user specifies 
                var homeTeam =
                    ctx
                    .Teams
                    .Single(h => h.TeamId == model.HomeTeamId);
                var awayTeam =
                    ctx
                    .Teams
                    .Single(a => a.TeamId == model.AwayTeamId);

                //adding the teams to our collection inside of the specific game
                game.ListOfTeams.Add(homeTeam);
                game.ListOfTeams.Add(awayTeam);
                //because of the many to many relationship I don't have to add the game to my list of games inside of team

                //set the specfic home team id to be just that inside of our database
                game.HomeTeamId = model.HomeTeamId;
                game.AwayTeamId = model.AwayTeamId;

                return ctx.SaveChanges() >= 1;
            }

        }
        public bool CreateGame(GameCreate Model)
        {
            var entity =
                new Games()
                {
                    DateOfGame = Model.DateOfGame,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Select(
                        e =>
                            new GameItem
                            {
                                GameId = e.GameId,
                                HomeTeamId = e.HomeTeamId,
                                AwayTeamId = e.AwayTeamId,
                                HomeScore = e.HomeScore,
                                AwayScore = e.AwayScore,
                                DateOfGame = e.DateOfGame,
                            }
                    );

                return query.ToArray();
            }

        }

        public GameDetail GetGameById(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == gameId);
                return
                    new GameDetail
                    {
                        GameId = entity.GameId,
                        HomeTeamId = entity.HomeTeamId,
                        HomeScore = entity.HomeScore,
                        AwayTeamId = (int)entity.AwayTeamId,
                        AwayScore = entity.AwayScore,
                        DateOfGame = entity.DateOfGame,
                    };
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == model.GameId);


                entity.HomeTeamId = model.HomeTeamId;
                entity.HomeScore = model.HomeScore;
                entity.AwayTeamId = model.AwayTeamId;
                entity.AwayScore = model.AwayScore;
                entity.DateOfGame = model.DateOfGame;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == gameId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

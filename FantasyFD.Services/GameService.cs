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

        public bool CreateGame(GameCreate Model)
        {
            var entity =
                new Games()
                {
                    HomeTeamId = Model.HomeTeamId,
                    HomeScore = Model.HomeScore,
                    AwayTeamId = Model.AwayTeamId,
                    AwayScore = Model.AwayScore,
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
                        .Where(e => e.GameId == _gameId)
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
                            AwayTeamId = entity.AwayTeamId,
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

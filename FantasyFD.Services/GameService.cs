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
            public IEnumerable<GameItem> GetGame()
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
                            Id = e.Id,
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
            public GameDetail GetGameById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Games
                        .Single(e => e.Id == id);
                return
                    new GameDetail
                    {
                        Id = entity.Id,
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
                    .Single(e => e.Id == model.Id);

                entity.HomeTeamId = model.HomeTeamId;
                entity.HomeScore = model.HomeScore;
                entity.AwayTeamId = model.AwayTeamId;
                entity.AwayScore = model.AwayScore;
                entity.DateOfGame = model.DateOfGame;

                return ctx.SaveChanges() == 1;
                }
            }
            
            public bool DeleteGame(int Id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.Id == Id);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
                }
            }
    }
}

using FantasyFD.Data;
using FantasyFD.Models.Player;
using FantasyFD.Models.PlayerStats;
using Fluent.Infrastructure.FluentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDbContext = FantasyFD.Data.ApplicationDbContext;

namespace FantasyFD.Services
{
    public class PlayerService
    {
        private readonly Guid _userId;
        public PlayerService(Guid userId)
        {
            _userId = userId;
        }

        public PlayerService()
        {
        }

        public bool CreatePlayer(CreatePlayer model)
        {
            var entity = new Player()
            {
                TeamId = model.TeamId,
                PlayerFirstName = model.PlayerFirstName,
                PlayerLastName = model.PlayerLastName,
                PlayerPosition = model.PlayerPosition,
                PlayerJerseyNumber = model.PlayerJerseyNumber,
                PlayerHeightByInches = model.PlayerHeightByInches,
                PlayerWeightByPounds = model.PlayerWeightByPounds
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ListPlayer> GetPlayer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Select(
                            e =>
                                new ListPlayer
                                {
                                    PlayerId = e.PlayerId,
                                    TeamID = e.TeamId,
                                    TeamName = e.Team.TeamName, //available because of 'virtual'
                                    PlayerFirstName = e.PlayerFirstName,
                                    PlayerLastName = e.PlayerLastName,
                                }
                        );
                return query.ToArray();
            }
        }
        public DetailPlayer GetPlayerByID(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == playerId);
                List<ListPlayerStats> roster = entity.PlayerStats
                .Select(
                    e =>
                        new ListPlayerStats
                        {
                            PlayerStatsId = e.PlayerStatsId,
                            PlayerId = e.PlayerId,
                            PassingYards = e.PassingYards,
                            PassingTouchdowns = e.PassingTouchdowns,
                            InterceptionThrown = e.InterceptionThrown,
                            RushingYards = e.RushingYards,
                            RushingAttempts = e.RushingAttempts,
                            RushingTouchDowns = e.RushingTouchDowns,
                            ReceivingYards = e.ReceivingYards,
                            Catches = e.Catches,
                            ReceivingTouchDowns = e.ReceivingTouchDowns,
                            Fumbles = e.Fumbles,
                            Tackles = e.Tackles,
                            Sacks = e.Sacks,
                            Interceptions = e.Interceptions,
                            ForcedFumbles = e.ForcedFumbles,
                            FumbleRecovery = e.FumbleRecovery,
                            Safety = e.Safety,
                            BlockedKick = e.BlockedKick,
                            ReturnTouchDown = e.ReturnTouchDown
                        }
                    ).ToList();
                return
                    new DetailPlayer
                    {
                        PlayerId = entity.PlayerId,
                        TeamId = entity.TeamId,
                        TeamName = entity.Team.TeamName,
                        PlayerFirstName = entity.PlayerFirstName,
                        PlayerLastName = entity.PlayerLastName,
                        PlayerPosition = entity.PlayerPosition,
                        PlayerJerseyNumber = entity.PlayerJerseyNumber,
                        PlayerHeightByInches = entity.PlayerHeightByInches,
                        PlayerWeightByPounds = entity.PlayerWeightByPounds,
                        PlayerStats = roster
                    };
            }
        }
        public bool UpdatePlayer(EditPlayer model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == model.PlayerId);
                entity.PlayerId = model.PlayerId;
                entity.TeamId = model.TeamId;
                entity.PlayerFirstName = model.PlayerFirstName;
                entity.PlayerLastName = model.PlayerLastName;
                entity.PlayerPosition = model.PlayerPosition;
                entity.PlayerJerseyNumber = model.PlayerJerseyNumber;
                entity.PlayerHeightByInches = model.PlayerHeightByInches;
                entity.PlayerWeightByPounds = model.PlayerWeightByPounds;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePlayer(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerId == playerId);
                ctx.Players.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
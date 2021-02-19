using FantasyFD.Data;
using FantasyFD.Models.PlayerStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Services
{
    public class PlayerStatsService
    {
        private readonly Guid _userId;
        public PlayerStatsService(Guid userId)
        {
            _userId = userId;
        }

        public PlayerStatsService()
        {
        }

        public bool CreatePlayerStats(CreatePlayerStats model)
        {
            var entity = new PlayerStats()
            {
                PlayerStatsId = model.PlayerStatsId,
                PlayerId = model.PlayerId,
                PassingYards = model.PassingYards,
                PassingTouchdowns = model.PassingTouchdowns,
                InterceptionThrown = model.InterceptionThrown,
                RushingYards = model.RushingYards,
                RushingAttempts = model.RushingAttempts,
                RushingTouchDowns = model.RushingTouchDowns,
                ReceivingYards = model.ReceivingYards,
                Catches = model.Catches,
                ReceivingTouchDowns = model.ReceivingTouchDowns,
                Fumbles = model.Fumbles,
                Tackles = model.Tackles,
                Sacks = model.Sacks,
                Interceptions = model.Interceptions,
                ForcedFumbles = model.ForcedFumbles,
                FumbleRecovery = model.FumbleRecovery,
                Safety = model.Safety,
                BlockedKick = model.BlockedKick,
                ReturnTouchDown = model.ReturnTouchDown
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PlayerStats.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ListPlayerStats> GetPlayerStats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PlayerStats
                        .Select(
                            e =>
                                new ListPlayerStats
                                {
                                    PlayerStatsId = e.PlayerStatsId,
                                    PlayerId = e.PlayerId,
                                    PlayerName = e.Player.PlayerFirstName + " " + e.Player.PlayerLastName,
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
                        );
                return query.ToArray();
            }
        }
        public DetailPlayerStats GetPlayerStatsByID(int playerStatsId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlayerStats
                        .Single(e => e.PlayerStatsId == playerStatsId);
                return
                    new DetailPlayerStats
                    {
                        PlayerStatsId = entity.PlayerStatsId,
                        PlayerID = entity.PlayerId,
                        PassingYards = entity.PassingYards,
                        PassingTouchdowns = entity.PassingTouchdowns,
                        InterceptionThrown = entity.InterceptionThrown,
                        RushingYards = entity.RushingYards,
                        RushingAttempts = entity.RushingAttempts,
                        RushingTouchDowns = entity.RushingTouchDowns,
                        ReceivingYards = entity.ReceivingYards,
                        Catches = entity.Catches,
                        ReceivingTouchDowns = entity.ReceivingTouchDowns,
                        Fumbles = entity.Fumbles,
                        Tackles = entity.Tackles,
                        Sacks = entity.Sacks,
                        Interceptions = entity.Interceptions,
                        ForcedFumbles = entity.ForcedFumbles,
                        FumbleRecovery = entity.FumbleRecovery,
                        Safety = entity.Safety,
                        BlockedKick = entity.BlockedKick,
                        ReturnTouchDown = entity.ReturnTouchDown
                    };
            }
        }
        public bool UpdatePlayerStats(EditPlayerStats model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlayerStats
                        .Single(e => e.PlayerStatsId == model.PlayerStatsId);
                entity.PlayerStatsId = model.PlayerStatsId;
                entity.PlayerId = model.PlayerId;
                entity.PassingYards = model.PassingYards;
                entity.PassingTouchdowns = model.PassingTouchdowns;
                entity.InterceptionThrown = model.InterceptionThrown;
                entity.RushingYards = model.RushingYards;
                entity.RushingAttempts = model.RushingAttempts;
                entity.RushingTouchDowns = model.RushingTouchDowns;
                entity.ReceivingYards = model.ReceivingYards;
                entity.Catches = model.Catches;
                entity.ReceivingTouchDowns = model.ReceivingTouchDowns;
                entity.Fumbles = model.Fumbles;
                entity.Tackles = model.Tackles;
                entity.Sacks = model.Sacks;
                entity.Interceptions = model.Interceptions;
                entity.ForcedFumbles = model.ForcedFumbles;
                entity.FumbleRecovery = model.FumbleRecovery;
                entity.Safety = model.Safety;
                entity.BlockedKick = model.BlockedKick;
                entity.ReturnTouchDown = model.ReturnTouchDown;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePlayerStats(int playerStatsId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlayerStats
                        .Single(e => e.PlayerStatsId == playerStatsId);
                ctx.PlayerStats.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
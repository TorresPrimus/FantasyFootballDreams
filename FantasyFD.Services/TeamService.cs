using FantasyFD.Data;
using FantasyFD.Models;
using FantasyFD.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Services
{
    public class TeamService
    {
        private readonly Guid _userId;

        public TeamService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                new Team()
                {
                    UserId = _userId,
                    TeamName = model.TeamName,
                    CreatedUtc = DateTimeOffset.Now,
                    ModifiedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamId = e.TeamId,
                                    TeamName = e.TeamName,
                                    UserId = e.UserId
                                }
                        );

                return query.ToArray();
            }
        }

        public TeamDetail GetTeamById(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == teamId);
                ICollection<ListPlayer> player = entity.ListOfPlayers
        .Select(
            e =>
                new ListPlayer
                {
                    PlayerId = e.PlayerId,
                    TeamID = e.TeamId,
                    TeamName = e.Team.TeamName,
                    PlayerFirstName = e.PlayerFirstName,
                    PlayerLastName = e.PlayerLastName
                }
            ).ToList();
                ICollection<GameItem> game = entity.ListOfGames
        .Select(
                    e =>
                new GameItem
                {
                    GameId = e.GameId
                }
            ).ToList();
                return
                    new TeamDetail
                    {
                        TeamId = entity.TeamId,
                        TeamName = entity.TeamName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        ListOfPlayers = player,
                        ListOfGames = game,
                    };
            }
        }
        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == model.TeamId);

                entity.TeamName = model.TeamName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTeam(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == teamId);

                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
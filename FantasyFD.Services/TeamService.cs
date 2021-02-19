using FantasyFD.Data;
using FantasyFD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Services
{
    public class TeamService
    {
        private readonly int _teamId;

        public TeamService(int teamId)
        {
            _teamId = teamId;
        }

        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                new Team()
                {
                    TeamName = model.TeamName
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
                        .Where(e => e.TeamId == _teamId)
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamId = e.TeamId,
                                    TeamName = e.TeamName,
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
                return
                    new TeamDetail
                    {
                        TeamId = entity.TeamId,
                        TeamName = entity.TeamName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        ListOfPlayers = (ICollection<Models.Player.ListPlayer>)entity.ListOfPlayers,
                        ListOfGames = (ICollection<GameItem>)entity.ListOfGames,
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

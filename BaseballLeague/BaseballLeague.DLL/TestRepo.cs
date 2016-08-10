using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.Models;

namespace BaseballLeague.DLL
{
    public class TestRepo : IBaseballRepo
    {   
        static TestRepo()
        {
            _positions =  new List<Position>()
            {
                new Position
                {
                    PositionId = 1,
                    PositionName = "Pitcher",
                },

                new Position
                {
                    PositionId = 2,
                    PositionName = "Catcher",
                }
            };

            _leagues = new List<League>()
                {
                    new League
                    {
                        LeagueId = 1,
                        Name = "Red",
                    },

                    new League
                    {
                        LeagueId = 2,
                        Name = "Blue",
                    },
                };

            _players = new List<Player>()
                {
                new Player
                {
                    PlayerId = 1,
                    FirstName = "Tom",
                    LastName = "Smith",
                    JerseyNumber = 1,
                    Position = new Position
                    {
                        PositionId = 1,
                        PositionName = "Catcher"
                    },
                    PreviousYearsBattingAverage = (decimal).500,
                    YearsPlayed = 4,
                    Team = new Team
                    {
                        TeamId = 1,
                        Name = "SaltySailors"
                    }
                },

                new Player
                {
                    PlayerId = 2,
                    FirstName = "Bob",
                    LastName = "Dole",
                    JerseyNumber = 2,
                    Position = new Position
                    {
                        PositionId = 2,
                        PositionName = "Pitcher"
                    },
                    PreviousYearsBattingAverage = (decimal).500,
                    YearsPlayed = 4,
                    Team = new Team
                    {
                        TeamId = 2,
                        Name = "Pretzels"
                    }
                },
            };

            _teams = new List<Team>()
                {
                    new Team
                    {
                        TeamId = 1,
                        Name = "SaltySailors",
                        ManagerFirstName = "Bob",
                        ManagerLastName = "Sagot",
                        LeagueId = 1,
                        PlayersList = _players.FindAll(p => p.Team.TeamId == 1),
                    },

                    new Team
                    {
                        TeamId = 2,
                        Name = "Pretzels",
                        ManagerFirstName = "Eric",
                        ManagerLastName = "Smith",
                        LeagueId = 1,
                        PlayersList = _players.FindAll(p => p.Team.TeamId == 2),
                    },

                };
        }
        
        public void AddPlayer(Player player)
        {

            var playerListForCount = GetAllPlayers();
            var playerIdCount = playerListForCount.Max(p => p.PlayerId);


            player.PlayerId = playerIdCount + 1;

            _players.Add(player);
        }

        public void AddTeam(Team team)
        {
            var teamListForCount = GetAllPlayers();
            var teamIdCount = teamListForCount.Max(p => p.Team.TeamId);


            team.TeamId = teamIdCount + 1;

            _teams.Add(team);
        }

        public void DeletePlayer(int playerId)
        {
            Player player = new Player();

            _players.RemoveAll(p => p.PlayerId == playerId);
        }

        public List<League> GetAllLeagues()
        {
            return _leagues;
        }

        public List<Player> GetAllPlayers()
        {
            return _players;
        }

        public List<Position> GetAllPositions()
        {
            return _positions;
        }

        public List<Team> GetAllTeams()
        {
            return _teams;
        }

        public Player GetIndivdualPlayer(int PlayerId)
        {
            var player = _players.First(p => p.PlayerId == PlayerId);

            return player;
        }

        public Team GetIndividualTeam(Player player)
        {
            var team = _teams.First(p => p.TeamId == player.Team.TeamId);

            return team;
        }

        public Position GetPositionName(Player player)
        {
            Position position = new Position();
            var positionName = _positions.First(p => p.PositionId == player.PlayerId).PositionName;
            position.PositionName = positionName;

            return position;
        }

        public void TradePlayer(Player player)
        {
            var playerFromList = GetIndivdualPlayer(player.PlayerId);
            playerFromList.Team.TeamId = player.Team.TeamId;
        
        }

        private static List<Player> _players;
        
        private static List<Team> _teams;

        private static List<League> _leagues;

        private static List<Position> _positions; 


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.Models;
using System.Data.SqlClient;
using BaseballLeague.DLL.Config;
using System.Data;

namespace BaseballLeague.DLL
{
    public class BaseballRepo : IBaseballRepo
    {
        public void TradePlayer(Player player)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "TradePlayer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlayerId", player.PlayerId);
                cmd.Parameters.AddWithValue("@TeamId", player.Team.TeamId);

                try
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record updated successfully");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DeletePlayer(int PlayerId)
        {

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DeletePlayer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlayerId", PlayerId);

                try
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record deleted successfully");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void AddTeam(Team team)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "CreateTeam";
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Name", team.Name);
                cmd.Parameters.AddWithValue("@ManagerFirstName", team.ManagerFirstName);
                cmd.Parameters.AddWithValue("@ManagerLastName", team.ManagerLastName);
                cmd.Parameters.AddWithValue("@LeagueId", team.LeagueId);

                try
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record inserted successfully");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public List<League> GetAllLeagues()
        {
            List<League> leagues = new List<League>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetAllLeagues";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        leagues.Add(PopulateLeagueFromDataReader(dr));
                    }
                }
                return leagues;
            }

        }

        private League PopulateLeagueFromDataReader(SqlDataReader dr)
        {
            League league = new League();

            league.LeagueId= (int)dr["LeagueId"];
            league.Name = dr["Name"].ToString();

            return league;

        }

        public List<Position> GetAllPositions()
        {
            List<Position> positions = new List<Position>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetAllPositions";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        positions.Add(PopulatePositionFromDataReader(dr));
                    }
                }
                return positions;
            }
        }

        public List<Team> GetAllTeams()
        {
            List<Team> teams = new List<Team>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetAllTeams";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        teams.Add(PopulateTeamFromDataReader(dr));
                    }
                }
                return teams;
            }
        }

        public void AddPlayer(Player player)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "CreatePlayer";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@DVDId", dvd.DVDId);not needed because I am adding a new one? 
                //Auto count from identity in SQL?
                cmd.Parameters.AddWithValue("@FirstName", player.FirstName);
                cmd.Parameters.AddWithValue("@LastName", player.LastName);
                cmd.Parameters.AddWithValue("@JerseyNumber", player.JerseyNumber);
                cmd.Parameters.AddWithValue("@PreviousYearsBattingAverage", player.PreviousYearsBattingAverage).Value = (object)player.Position.PositionId ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@YearsPlayed", player.YearsPlayed);
                cmd.Parameters.AddWithValue("@TeamId", player.Team.TeamId);
                cmd.Parameters.AddWithValue("@PositionId", player.Position.PositionId);

                try
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record inserted successfully");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public List<Player> GetAllPlayers()
        {
            List<Player> players = new List<Player>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetAllPlayers";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        players.Add(PopulatePlayerFromDataReader(dr));
                    }
                }
                return players;
            }
        }

        public Player GetIndivdualPlayer(int PlayerId)
        {
            Player player = new Player();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetPlayer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlayerId", PlayerId);
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        player = PopulatePlayerFromDataReader(dr);
                    }
                }
                return player;

            }
        }

        private Player PopulatePlayerFromDataReader(SqlDataReader dr)
        {
            Player player = new Player();

            player.PlayerId = (int)dr["PlayerId"];
            player.FirstName = dr["FirstName"].ToString();
            player.LastName = dr["LastName"].ToString();
            player.JerseyNumber = (int)dr["JerseyNumber"];
            player.Position.PositionId = (int)dr["PositionId"];
            player.Position.PositionName = dr["PositionName"].ToString();
            player.Team.TeamId = (int)dr["TeamId"];
            player.Team.Name = dr["Name"].ToString();
            if (dr["PreviousYearsBattingAverage"] != DBNull.Value)
            {
                player.PreviousYearsBattingAverage = (decimal)dr["PreviousYearsBattingAverage"];
            }
            player.YearsPlayed = (int)dr["YearsPlayed"];

            return player;
        }

        private Team PopulateTeamFromDataReader(SqlDataReader dr)
        {
            Team team = new Team();

            team.TeamId = (int)dr["TeamId"];
            team.Name = dr["Name"].ToString();
            team.ManagerFirstName = dr["ManagerFirstName"].ToString();
            team.ManagerLastName = dr["ManagerLastName"].ToString();

            return team;
        }

        private Position PopulatePositionFromDataReader(SqlDataReader dr)
        {
            Position position = new Position();

            position.PositionId = (int)dr["PositionId"];
            position.PositionName = dr["PositionName"].ToString();
          

            return position;
        }

        public Team GetIndividualTeam(Player player)
        {
            Team team = new Team();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetIndividualTeam";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeamId", player.Team.TeamId);
                cmd.Parameters.AddWithValue("@Name", player.Team.Name);
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        team.TeamId = player.Team.TeamId;
                        team.Name = player.Team.Name;
                        team.ManagerFirstName = dr["ManagerFirstName"].ToString();
                        team.ManagerLastName = dr["ManagerLastName"].ToString();
                    }
                }

                return team;
            }
        }

        public Position GetPositionName(Player player)
        {
            Position position = new Position();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetPositionName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PositionId", player.Position.PositionId);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        position.PositionId = player.Position.PositionId;
                        position.PositionName = dr["PositionName"].ToString();
                    }
                }

                return position;
            }
        }






    }
 }

//public int PlayerId { get; set; }
//public string FirstName { get; set; }
//public string LastName { get; set; }
//public int JerseyNumber { get; set; }
//public int PositionId { get; set; }
//public decimal? PreviousYearsBattingAverage { get; set; }
//public int YearsPlayed { get; set; }
//public int TeamId { get; set; }

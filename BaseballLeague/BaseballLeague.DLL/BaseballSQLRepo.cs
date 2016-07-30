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
    public class BaseballSQLRepo
    {
        public List<Player> GetAll()
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

        private Player PopulatePlayerFromDataReader(SqlDataReader dr)
        {
            Player player = new Player();

            player.PlayerId = (int)dr["PlayerId"];
            player.FirstName = dr["FirstName"].ToString();
            player.LastName = dr["LastName"].ToString();
            player.JerseyNumber = (int)dr["JerseyNumber"];
            player.PositionId = (int)dr["PositionId"];
            player.TeamId = (int)dr["TeamId"];
            if (dr["PreviousYearsBattingAverage"] != DBNull.Value)
            {
                player.PreviousYearsBattingAverage = (decimal)dr["PreviousYearsBattingAverage"];
            }
            player.YearsPlayed = (int)dr["YearsPlayed"];

            return player;
        }

        public Team GetTeamName(Player player)
        {
            Team team = new Team();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetTeamName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeamId", player.TeamId);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        team.TeamId = player.TeamId;
                        team.Name = dr["Name"].ToString();
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
                cmd.Parameters.AddWithValue("@PositionId", player.PositionId);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        position.PositionId = player.PositionId;
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

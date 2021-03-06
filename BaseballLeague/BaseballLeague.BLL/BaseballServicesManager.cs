﻿using BaseballLeague.DLL;
using BaseballLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.BLL
{
    public class BaseballServicesManager
    {
        private IBaseballRepo _repo;

        public BaseballServicesManager(IBaseballRepo repo)
        {
            _repo = repo;
        }

        public void AddPlayer(Player player)
        {
            _repo.AddPlayer(player);
        }

        public List<Position> GetAllPositions()
        {
            var positionList = _repo.GetAllPositions();

            return positionList;
        }

        public List<Player> GetAllPlayers()
        {
            var playerList = _repo.GetAllPlayers();

            return playerList;
        }

        public Player GetPlayer(int playerId)
        {
            var player = _repo.GetIndivdualPlayer(playerId);

            return player;
        }

        public Team GetTeam(Player player)
        {
            var team = _repo.GetIndividualTeam(player);

            return team;
        }

        public void TradePlayer(int playerId, int teamId)
        {
            var player = _repo.GetIndivdualPlayer(playerId);

            player.Team.TeamId = teamId;

            _repo.TradePlayer(player);
        }

        public void DeletePlayer(int playerId)
        {
            _repo.DeletePlayer(playerId);
        }

        public List<Team> GetAllTeams()
        {
            var teams = _repo.GetAllTeams();

            return teams;
        }

        public void AddTeam(Team team)
        {
            _repo.AddTeam(team);
        }

        public List<League> GetAllLeagues()
        {
            var leagues = _repo.GetAllLeagues();

            return leagues;
        }

    }
}

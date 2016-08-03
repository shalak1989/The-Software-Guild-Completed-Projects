using System.Collections.Generic;
using BaseballLeague.Models;

namespace BaseballLeague.DLL
{
    public interface IBaseballRepo
    {
        void AddPlayer(Player player);
        void AddTeam(Team team);
        void DeletePlayer(int PlayerId);
        List<League> GetAllLeagues();
        List<Player> GetAllPlayers();
        List<Position> GetAllPositions();
        List<Team> GetAllTeams();
        Player GetIndivdualPlayer(int PlayerId);
        Position GetPositionName(Player player);
        Team GetIndividualTeam(Player player);
        void TradePlayer(Player player);
    }
}
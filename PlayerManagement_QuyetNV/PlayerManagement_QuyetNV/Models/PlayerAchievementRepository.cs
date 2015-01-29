using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PlayerManagement.Models
{
    public class PlayerAchievementRepository : IPlayerAchievementRepository
    {

        public List<PlayerAchievement> allPlayerAchievements;
        private XDocument playerAchievementData;

        public PlayerAchievementRepository()
        {
            allPlayerAchievements = new List<PlayerAchievement>();

            playerAchievementData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/player_management.xml"));
            var playerAchievements = from playerAchievement in playerAchievementData.Descendants("player_achievement")                                     
                          select new PlayerAchievement((int) playerAchievement.Element("number"), playerAchievement.Element("playerID").Value, 
                              playerAchievement.Element("achievementName").Value);

            allPlayerAchievements.AddRange(playerAchievements.ToList<PlayerAchievement>());
            
        }

        public IEnumerable<PlayerAchievement> GetPlayerAchievementsByPlayerID(String playerID)
        {
            XDocument achievementData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/player_management.xml"));
            var achievements = from achievement in playerAchievementData.Descendants("player_achievement")
                               where String.Equals(achievement.Element("playerID").Value, playerID)
                                     select new PlayerAchievement((int)achievement.Element("number"), achievement.Element("playerID").Value,
                                         achievement.Element("achievementName").Value);

            List<PlayerAchievement> allAchievements = new List<PlayerAchievement>();
            allAchievements.AddRange(achievements.ToList<PlayerAchievement>());
            return allAchievements;            
        }

        public PlayerAchievement GetPlayerAchievementByAchievementName(String playerID, String achievementName)
        {
            
            return allPlayerAchievements.Find(item => (item.achievementName.Equals(achievementName)) &&
                                                        (item.achievementName.Equals(playerID)));
        }

        public void InsertPlayerAchievement(PlayerAchievement playerAchievement)
        {
            
            
            playerAchievementData.Descendants("player_achievement").FirstOrDefault().Add(new XElement("player_achievement", 
                new XElement("number", playerAchievement.number), new XElement("playerID"), playerAchievement.playerID),
                new XElement("achievementName"), playerAchievement.achievementName);

            playerAchievementData.Save(HttpContext.Current.Server.MapPath("~/App_Data/player_management.xml"));
        }


        public void DeletePlayerAchievement(String playerID, String achievementName)
        {
            throw new NotImplementedException();
        }

        public void EditPlayerAchievement(PlayerAchievement playerAchievement)
        {
            throw new NotImplementedException();
        }
    }
}
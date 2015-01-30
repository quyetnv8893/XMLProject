using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerManagement.Models
{
    public class PlayerAchievement
    {
        [Key]
        [Required]
        public String playerID { get; set; }               
        [Required]
        public String achievementName { get; set; }
        [Required]
        public int number { get; set; }

        public PlayerAchievement()
        {
            this.playerID = null;
            this.achievementName = null;
            this.number = 0;
        }

        public PlayerAchievement(  int number, String playerID, String achievementName){
            this.playerID = playerID;
            this.achievementName = achievementName;
            this.number = number;
        }
        
    }

}
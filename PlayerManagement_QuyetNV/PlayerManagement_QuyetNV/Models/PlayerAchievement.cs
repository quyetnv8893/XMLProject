using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerManagement.Models
{
    public class PlayerAchievement{

        [Required]       
        public String achievementName { get; set; }

        [Required]
        public String playerID { get; set; }
        public int number { get; set; }

        [Key]
        public String playerId { get; set; }

               
        public PlayerAchievement()
        {
            this.playerId = null;
            this.achievementName = null;
            this.number = 0;
        }

        public PlayerAchievement(  int number, String playerID, String achievementName){
            this.playerId = playerID;
            this.achievementName = achievementName;
            this.number = number;
        }
        
    }

}
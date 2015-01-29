using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerManagement.Models
{
    public class PlayerAchievement
    {
<<<<<<< HEAD
        
        [Required]       
        public String achievementName { get; set; }

        [Required]
=======
        public String playerID { get; set; }
        public String achievementName { get; set; }
>>>>>>> parent of a6bfc22... Added [Key] for id
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
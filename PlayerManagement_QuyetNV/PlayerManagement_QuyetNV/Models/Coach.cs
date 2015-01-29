using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerManagement_QuyetNV.Models
{
    public class Coach
    {
        [Required]
        public String id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public DateTime dateOfBirth { get; set; }
        [Required]
        public String imageLink { get; set; }
        [Required]
        public String position { get; set; }
        [Required]
        public String clubName { get; set; }

        public Coach()
        {
            this.id = null;
            this.name = null;
            this.dateOfBirth = DateTime.Now;
            this.imageLink = null;
            this.position = null;
            this.clubName = null;
        }
        public Coach(String id, String name, DateTime dateOfBirth, String imageLink, String position, String clubName)
        {
            this.id = id;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.imageLink = imageLink;
            this.position = position;
            this.clubName = clubName;
        }

    }
}
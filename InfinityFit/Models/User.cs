using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace InfinityFit.Models
{
    public class User : IdentityUser
    {

        public int Level {get;set;} = 1;

        public int TotalPoints {get;set;}
        

        public float Daily_Distance_Goal {get;set;}



        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Appreciation> Apreciations { get; set; } = new List<Appreciation>();
        public ICollection<Badge> UserBadges { get; set; } = new List<Badge>();
    }
    
}

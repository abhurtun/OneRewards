using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneRewardsMvc.Models
{
    //Company class
    //desribes the company database table
    //A company has the following attributes:
    //int RewardAccountID (part primary key)
    //int CompanyID (part primary key)
    //int UserID (part primary key)
    //decimal Points for current points accumulated
    //decimal? TotalPoints for current points accumulated
    //one Company 
    //one User 
    public class RewardAccount
    {
        [Required(ErrorMessage = "A account number is required"), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RewardAccountID { get; set; }
        [Required(ErrorMessage = "A Company is required")]
        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }
        [Required(ErrorMessage = "A user is required")]
        public String UserName { get; set; }
        public decimal? Points { get; set; }
        public decimal? TotalPoints { get; set; }

    }
}
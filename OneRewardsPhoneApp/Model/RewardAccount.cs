using System;
using System.Collections.Generic;
using System.Linq;

namespace OneRewardsPhoneApp.Model
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
        public long RewardAccountID { get; set; }
        public int CompanyID { get; set; }
        public String UserName { get; set; }
        public decimal? Points { get; set; }
        public decimal? TotalPoints { get; set; }

    }
}
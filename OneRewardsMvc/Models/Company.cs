using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace OneRewardsMvc.Models
{
    //Company class
    //desribes the company database table
    //A company has the following attributes:
    //int CompanyID (primary key)
    //String CompanyName 
    //Bitmap CompanyLogo 

    public class Company
    {
        [Key] public int CompanyID { get; set; }
        public String CompanyName { get; set; }
        public byte[] CompanyLogo { get; set; }
        public String CompanyRewardsLink { get; set; }

        }


}
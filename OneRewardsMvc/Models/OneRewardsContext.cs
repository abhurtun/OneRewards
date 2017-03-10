using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.Security;

namespace OneRewardsMvc.Models
{
    //Coordinates Entity Framework functionality for OneRewards data model 
    public class OneRewardsContext : DbContext
    {
        //Creates a DbSet property for each entity set. 
        //In Entity Framework terminology, an entity set typically corresponds to a database table, 
        //and an entity corresponds to a row in the table.
        public DbSet<RewardAccount> RewardAccounts { get; set; }
        public DbSet<Company> Companys { get; set; }



        public OneRewardsContext()
            : base("DefaultConnection")
        {
        }

        //The statement in the OnModelCreating method prevents table names from being pluralized. 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}
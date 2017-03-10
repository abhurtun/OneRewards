using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OneRewardsMvc.Models;
using System.Drawing;
using System.Data.Entity.Infrastructure;
using System.Web.Security;

namespace OneRewardsMvc.DAL
{

     public class OneRewardsInitializer : IDatabaseInitializer<OneRewardsContext>
    {
         private enum UserRoles
         {
             Administrator = 0,
             User = 1
         }

         /// <summary>
         /// Checks if user is authenticated.
         /// </summary>
         /// <param></param>
         /// <returns></returns>
         /// <remarks></remarks>
         public static bool checkUser
         {
             get
             {
                 return
                    HttpContext.Current.User != null &&
                    HttpContext.Current.User.Identity.IsAuthenticated;
             }
         }


         /// <summary>
         /// Checks if superUser is authenticated.
         /// </summary>
         /// <param></param>
         /// <returns></returns>
         /// <remarks></remarks>
         public static bool superUser
         {
             get
             {
                 return
                    HttpContext.Current.User != null &&
                    HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.IsInRole("Administrator");
             }
         }
    
       //check that the the database exists if not an exception will be thrown. 
       //If database exists use SQL Server stored procedure 
       //sp_MSforeachtable in order to drop all the existing tables. 
       //get the context’s underlining ObjectContext in order to 
       //get the script that will generate the database using the CreateDatabaseScript method. 
       //run the script using the ExecuteSqlCommand method. 
       //run the Seed method in order to enable the insertion of seed data into the database.

         public void InitializeDatabase(OneRewardsContext context)
    {
      bool dbExists;
      dbExists = context.Database.Exists();


      if (dbExists)
      {

          // remove all tables
          context.Database.ExecuteSqlCommand("IF EXISTS(SELECT name FROM OneRewards..sysobjects WHERE name = N'RewardAccount' AND xtype='U') DROP TABLE dbo.RewardAccount");
          context.Database.ExecuteSqlCommand("IF EXISTS(SELECT name FROM OneRewards..sysobjects WHERE name = N'Company' AND xtype='U') DROP TABLE dbo.Company");


          context.SaveChanges();
 
        // create all tables
        var dbCreationScript = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
        context.Database.ExecuteSqlCommand(dbCreationScript);
            
        Seed(context);
        context.SaveChanges();
      }
      else
      {
           throw new ApplicationException("No database instance");
      }
    }


        protected  void Seed(OneRewardsContext context)
        {
            MembershipCreateStatus createStatus;

            //create appropriate roles if not already present
              if (!Roles.RoleExists(UserRoles.Administrator.ToString("G")))
              {
                  Roles.CreateRole(UserRoles.Administrator.ToString("G"));
              }

              if (!Roles.RoleExists(UserRoles.User.ToString("G")))
              {
                  Roles.CreateRole(UserRoles.User.ToString("G"));
              }

            //create appropriate users if not already present
              if (Membership.GetUser("atbneo") == null)
              {
                  Membership.CreateUser("atbneo", "pooja160", "atbneo@gmail.com", passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);
              }

              if (Membership.GetUser("user1") == null)
              {
                  Membership.CreateUser("user1", "pooja160", "a@hotmail.com", passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);
              }


            //add users to appropriate roles
              if (!Roles.IsUserInRole("atbneo", UserRoles.Administrator.ToString("G")))
            {
                Roles.AddUserToRole("atbneo", UserRoles.Administrator.ToString("G"));
            }
              if (!Roles.IsUserInRole("user1", UserRoles.User.ToString("G")))
            {
                Roles.AddUserToRole("user1", UserRoles.User.ToString("G"));
            }

              Utilities util = new Utilities();

            var Company = new List<Company>
            {
               new Company { CompanyID =1 , CompanyName="Sainsbury" , CompanyLogo = util.ConvertImageFiletoBytes(HttpContext.Current.Server.MapPath("/Images/Sainsburys-logo.gif")), CompanyRewardsLink= "https://www.nectar.com" },
               new Company {  CompanyID =2 , CompanyName="M&S" , CompanyLogo = util.ConvertImageFiletoBytes(HttpContext.Current.Server.MapPath("/Images/mands_logo.jpg")),CompanyRewardsLink=  "http://money.marksandspencer.com"},
               new Company {  CompanyID =3 , CompanyName="Boots" , CompanyLogo = util.ConvertImageFiletoBytes(HttpContext.Current.Server.MapPath("/Images/boots-logo.jpg")),CompanyRewardsLink=  "http://www.boots.com"}
               
            };
            Company.ForEach(s => context.Companys.Add(s));
            context.SaveChanges();

            var RewardAccount = new List<RewardAccount>
            {
                new RewardAccount {  RewardAccountID = 1000 , CompanyID = 1 , UserName = "atbneo" ,Points = 0 ,TotalPoints = 10   },
                new RewardAccount { RewardAccountID = 1015 , CompanyID = 2 ,UserName = "atbneo" ,Points = 0 ,TotalPoints = 20 },
                new RewardAccount { RewardAccountID = 2000 , CompanyID = 2 ,UserName = "user1" ,Points = 0 ,TotalPoints = 30 },
            };
            RewardAccount.ForEach(s => context.RewardAccounts.Add(s));
            context.SaveChanges();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OneRewardsWcfService
{
    public class OneRewardsService : IOneRewardsService
    {


       //userlogin
        public Boolean autenticate(String Email)
        {
            Boolean result;
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    var x = (from u in DBContext.Memberships where u.Email == Email select u).First();
                    result = !String.IsNullOrEmpty(x.Email);
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }

        //get all reward accounts per user
        public List<RewardAccount> getAllRewardsAccount(String email)
        {
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    var x = (from u in DBContext.Memberships where u.Email == email select u).Single();
                    return (from u in DBContext.RewardAccounts.Include("Company") where u.UserName == x.UserReference.Value.UserName select u).ToList();
                }
                catch (Exception )
                {
                    return null;
                }
            }
        }

        //get all companys
        public List<Company> getCompanys()
        {
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    return (from u in DBContext.Companies select u).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        //get all company names
        public List<String> getCompanyNames()
        {
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    return (from u in DBContext.Companies select u.CompanyName).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        //get reward account
        public RewardAccount getRewardsAccount(long accid, int cid)
        {
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    return (from u in DBContext.RewardAccounts.Include("Company") where u.RewardAccountID == accid && u.CompanyID == cid select u).Single();
                    

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        //allow user to add accounts
        public Boolean addRewardsAccount(long accid, int cid, String email )
        {
            Boolean result=true;
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    var x = (from u in DBContext.Memberships where u.Email == email select u).First();
                    RewardAccount s = new RewardAccount { RewardAccountID = accid, CompanyID = cid, UserName = x.UserReference.Value.UserName, Points = 0, TotalPoints = 0 };
                    DBContext.RewardAccounts.AddObject(s);
                    DBContext.SaveChanges();
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }
        //get total points per user per account compnay
        public double getTPoints(long accid, int cid)
        {
            double result;
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    result = System.Convert.ToDouble((from u in DBContext.RewardAccounts where u.RewardAccountID == accid && u.CompanyID == cid select u.TotalPoints).First());
                     
                }
                catch (Exception)
                {
                    result = 0;
                }
            }
            return result;
        }

        //get latest accumulated points per user per account compnay
        public double getAPoints(long accid, int cid)
        {
            double result = 0;
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    result = System.Convert.ToDouble((from u in DBContext.RewardAccounts where u.RewardAccountID == accid && u.CompanyID == cid select u.Points).First());

                }
                catch (Exception)
                {
                    
                }
            }
            return result;
        }

        //update the points per user per company
        //collect = +
        //redeem = -
        public Boolean updatePoints(long accid, int cid, double points)
        {
            Boolean result= false;
            int res = 0;
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    RewardAccount acc = getRewardsAccount(accid, cid); 
                    acc.Points = Convert.ToDecimal(points);
                    acc.TotalPoints += Convert.ToDecimal(points);
                    //donot allow for total points to be negative
                    if (acc.TotalPoints > 0)
                    {
                        DBContext.Attach(acc);
                        DBContext.ObjectStateManager.ChangeObjectState(acc, System.Data.EntityState.Modified);
                        res = DBContext.SaveChanges();
                    }

                    if (res > 0)
                    {
                        result = true;
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        //remove user rewards account
        public Boolean removeRewardsAccount(long accid, int cid)
        {

            Boolean result = true;
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    
                    RewardAccount s = getRewardsAccount(accid, cid);
                    DBContext.Attach(s);
                    DBContext.RewardAccounts.DeleteObject(s);
                    DBContext.SaveChanges();
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }

        //get CompanyLogo
        public byte[] getCompanyLogo(String name)
        {
            byte[] result;
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    result = (from u in DBContext.Companies where u.CompanyName.ToLower() == name.ToLower() select u.CompanyLogo).First();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        //get CompanyLogo
        public byte[] getCompanyLogoID(int cid)
        {
            byte[] result;
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    result = (from u in DBContext.Companies where u.CompanyID == cid select u.CompanyLogo).First();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }


        //get comapny id
        public int getCompanyID(String cname)
        {
            int result;
            using (OneRewardsEntities DBContext = new OneRewardsEntities())
            {
                try
                {
                    result = (from u in DBContext.Companies where u.CompanyName.ToLower() == cname.ToLower() select u.CompanyID).First();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

    }
}

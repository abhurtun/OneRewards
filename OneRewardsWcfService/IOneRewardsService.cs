using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OneRewardsWcfService
{
    //Interface definiton for the One Rewards Service
    [ServiceContract(Namespace = "http://onerewardswcf.azurewebsites.net/")]
    [XmlSerializerFormat(SupportFaults = true)]
    public interface IOneRewardsService
    {
            //userlogin
            [OperationContract]
            Boolean autenticate(String Email);
            //get all reward accounts per user
            [OperationContract]
            [FaultContract(typeof(RewardAccount))]
            List<RewardAccount> getAllRewardsAccount(String email);
            //get all reward accounts per user
            [OperationContract]
            [FaultContract(typeof(Company))]
            List<Company> getCompanys();
            //get reward account
            [OperationContract]
            RewardAccount getRewardsAccount(long accid, int cid);
            //get all company id
            [OperationContract]
            int getCompanyID(String cname);
            //get all company names
            [OperationContract]
            List<String> getCompanyNames();
            //allow user to register
            [OperationContract]
            Boolean addRewardsAccount(long accid, int cid, String email);
            //get totalpoints per user per compnay
            [OperationContract]
            double getTPoints(long accid, int cid);
            //get latest accumulated points per user per compnay
            [OperationContract]
            double getAPoints(long accid, int cid);
            //update the points per user per company
            //collect = +
            //redeem = -
            [OperationContract]
            Boolean updatePoints(long accid, int cid,double points);
            //remove user account
            [OperationContract]
            Boolean removeRewardsAccount(long accid, int cid);
            //get CompanyLogo
            [OperationContract]
            byte[] getCompanyLogo(String name);
            //get CompanyLogo
            [OperationContract]
            byte[] getCompanyLogoID(int cid);
    }


}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneRewardsMvc.Models;


namespace OneRewardsMvc.Controllers
{
    public class RewardAccountController : Controller
    {
        private OneRewardsContext db = new OneRewardsContext();

        //
        // GET: /RewardAccount/

        public ActionResult Index()
        {
              return View(db.RewardAccounts.ToList());
        }


        //
        // GET: /RewardAccount/Create

        public ActionResult Create()
        {
            ViewData["CompanyList"] = new SelectList(db.Companys, "CompanyID", "CompanyName");
            return View();
        }

        //
        // POST: /RewardAccount/Create

        [HttpPost]
        public ActionResult Create(RewardAccount rewardaccount, FormCollection frmCollection)
        {
            if (ModelState.IsValid)
            {
                //set comapnyid from drop down
                rewardaccount.CompanyID = Convert.ToInt32(frmCollection.Get("CompanyList"));
                db.RewardAccounts.Add(rewardaccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(rewardaccount);
        }

        //
        // GET: /RewardAccount/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RewardAccount rewardaccount = db.RewardAccounts.Find(id);
            if (rewardaccount == null)
            {
                return HttpNotFound();
            }
            return View(rewardaccount);
        }

        //
        // POST: /RewardAccount/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, long ReceiptNum)
        {
 
            RewardAccount rewardaccount = db.RewardAccounts.Find(id);
            if (ModelState.IsValid)
            {
                long randompoints = randomNumber(ReceiptNum);
                rewardaccount.Points = randompoints;
                rewardaccount.TotalPoints += randompoints;
                db.Entry(rewardaccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rewardaccount);
        }

        //
        // GET: /RewardAccount/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RewardAccount rewardaccount = db.RewardAccounts.Find(id);
            if (rewardaccount == null)
            {
                return HttpNotFound();
            }
            return View(rewardaccount);
        }

        //
        // POST: /RewardAccount/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RewardAccount rewardaccount = db.RewardAccounts.Find(id);
            db.RewardAccounts.Remove(rewardaccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // To convert the Byte Array to the author Image
        public FileContentResult getImg(int id)
        {
            byte[] byteArray = db.Companys.Find(id).CompanyLogo;
            if (byteArray != null)
            {
                return new FileContentResult(byteArray, "image/jpeg");
            }
            else
            {
                return null;
            }
        }


        // Generate dummy redeem points data
        public long randomNumber(long number)
        {
            String num = number.ToString();
             int i = Convert.ToInt32(num.Substring(num.Length - 2));
            return (i + new Random().Next(500));
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneRewardsMvc.Models;
using System.Web.Security;
using System.Data;

namespace OneRewardsMvc.Controllers
{
            [HandleError]
    public class ManageUserController : Controller
    {
        private OneRewardsContext db = new OneRewardsContext();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View(Membership.GetAllUsers());
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(String User, String role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (role == "User")
                    {
                        Roles.RemoveUserFromRole(User,"Administrator");
                    }
                    else
                    {
                        Roles.AddUserToRole(User, role);
                    }
                }
                //error can be ignored in this instance
                catch(Exception)
                {
                }
                return RedirectToAction("Index");
            }

            return View(User);
        }


        //
        // GET: /Users/Delete/5

        public ActionResult Delete(String id)
        {
            MembershipUser User = Membership.GetUser(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(String id)
        {
            Membership.DeleteUser(id,true);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}

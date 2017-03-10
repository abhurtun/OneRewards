using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneRewardsMvc.Models;
using System.IO;
using System.Web.Helpers;

namespace OneRewardsMvc.Controllers
{
        [HandleError]
    public class CompanyController : Controller
    {
        private OneRewardsContext db = new OneRewardsContext();

        //
        // GET: /Company/

        public ActionResult Index()
        {
            return View(db.Companys.ToList());
        }


        //
        // GET: /Company/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Company/Create

        [HttpPost]
        public ActionResult Create(Company company, HttpPostedFileBase image)
        {

                if (ModelState.IsValid)
                {
                    if (image != null)
                    {

                        MemoryStream target = new MemoryStream();
                        image.InputStream.CopyTo(target);
                        company.CompanyLogo = target.ToArray();
                    }

                    db.Companys.Add(company);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            
            return View(company);
        }

        //
        // GET: /Company/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Company company = db.Companys.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        //
        // GET: /Company/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Company company = db.Companys.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        //
        // POST: /Company/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companys.Find(id);
            db.Companys.Remove(company);
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
        
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyHousingSolutions.Models;

namespace EasyHousingSolutions.Controllers
{
    public class AdminController : Controller
    {
        private Training_12Dec18_BangaloreEntities1 db = new Training_12Dec18_BangaloreEntities1();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Properties.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult VerifyUser(int Id)
        {
            Property prop = db.Properties.FirstOrDefault(p => p.PropertyId == p.PropertyId);
            return View(prop);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult VerifyProperty(Property property)
        {
            Property prop = db.Properties.FirstOrDefault(p => p.PropertyId == property.PropertyId);

            prop.IsActive = true;
            db.SaveChanges();
            return View(prop);
        }
        public ActionResult DeActivateProperty(int Id)
        {
            Property property = db.Properties.FirstOrDefault(p => p.PropertyId == Id);

            return View(property);
        }
        [HttpPost]
        public ActionResult DeActivateProperty(Property property)
        {
            Property prop = db.Properties.FirstOrDefault(p => p.PropertyId == property.PropertyId);

            prop.IsActive = false;
            db.SaveChanges();
            return View(prop);
        }


        public ActionResult Delete(int Id)
        {
            Property property = db.Properties.FirstOrDefault(p => p.PropertyId == Id);
            db.Properties.Remove(property);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

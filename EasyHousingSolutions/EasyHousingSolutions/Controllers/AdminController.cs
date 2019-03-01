using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyHousingSolutions.Controllers
{
    public class AdminController : Controller
    {
        Training_12Dec18_BangaloreEntities1 db = new Training_12Dec18_BangaloreEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Properties.ToList());
        }

        public ActionResult VerifyProperty(int Id)
        {
            Property property = db.Properties.FirstOrDefault(p => p.PropertyId == Id);

            return View(property);
        }
        [HttpPost]
        public ActionResult VerifyProperty(Property property)
        {
             Property prop =db.Properties.FirstOrDefault(p => p.PropertyId == property.PropertyId);
           
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

    }
}

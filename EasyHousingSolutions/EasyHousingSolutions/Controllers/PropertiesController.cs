using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyHousingSolutions;

namespace EasyHousingSolutions.Controllers
{
    public class PropertiesController : Controller
    {
        private Training_12Dec18_BangaloreEntities1 db = new Training_12Dec18_BangaloreEntities1();

        //// GET: Properties
        //public ActionResult Index()
        //{
        //    var properties = db.Properties.Include(p => p.Seller);
        //    return View(properties.ToList());
        //}

        //// GET: Properties/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Property property = db.Properties.Find(id);
        //    if (property == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(property);
        //}

        //// GET: Properties/Create
        //public ActionResult Create()
        //{
        //    ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "UserName");
        //    return View();
        //}

        //// POST: Properties/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PropertyId,PropertyName,PropertyType,Descript,Adress,PriceRange,InitialDeposit,LandMark,IsActive,SellerId")] Property property)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Properties.Add(property);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "UserName", property.SellerId);
        //    return View(property);
        //}

        //// GET: Properties/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Property property = db.Properties.Find(id);
        //    if (property == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "UserName", property.SellerId);
        //    return View(property);
        //}

        //// POST: Properties/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PropertyId,PropertyName,PropertyType,Descript,Adress,PriceRange,InitialDeposit,LandMark,IsActive,SellerId")] Property property)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(property).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "UserName", property.SellerId);
        //    return View(property);
        //}

        //// GET: Properties/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Property property = db.Properties.Find(id);
        //    if (property == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(property);
        //}

        //// POST: Properties/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Property property = db.Properties.Find(id);
        //    db.Properties.Remove(property);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        //EHSContext eHSContext = new EHSContext();
        // GET: Property
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {

            var properties = db.Properties.Include(p => p.Seller);
            return View(db.Properties.ToList());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Property property)
        {
            try
            {
                property.IsActive = false;
                string username = "Divya";
                Seller seller = db.Sellers.FirstOrDefault(p => p.UserName == username);
                property.SellerId = seller.SellerId;
                db.Properties.Add(property);
                db.SaveChanges();
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            Property property = db.Properties.FirstOrDefault(p => p.PropertyId == id);
            return View(property);
        }
        [HttpPost]
        public ActionResult Edit(Property property)
        {
            Property properties = db.Properties.FirstOrDefault(p => p.PropertyId == property.PropertyId);
            properties.PropertyName = property.PropertyName;
            properties.PropertyType = property.PropertyType;
            properties.Descript = property.Descript;
            properties.Adress = property.Adress;
            properties.PriceRange = property.PriceRange;
            properties.InitialDeposit = property.InitialDeposit;
            properties.LandMark = property.LandMark;
            properties.IsActive = property.IsActive;
            properties.SellerId = property.SellerId;
            db.SaveChanges();
            return View();
        }
        public ActionResult Details(int id)
        {
            Property property = db.Properties.FirstOrDefault(p => p.PropertyId == id);
            return View(property);
        }
        [HttpPost]
        public ActionResult Details(Property property)
        {
            Property properties = db.Properties.FirstOrDefault(p => p.PropertyId == property.PropertyId);
            properties.PropertyName = property.PropertyName;
            properties.PropertyType = property.PropertyType;
            properties.Descript = property.Descript;
            properties.Adress = property.Adress;
            properties.PriceRange = property.PriceRange;
            properties.InitialDeposit = property.InitialDeposit;
            properties.LandMark = property.LandMark;
            properties.IsActive = property.IsActive;
            properties.SellerId = property.SellerId;
            db.SaveChanges();
            return View();
        }
    }
}

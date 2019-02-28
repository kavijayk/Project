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
    public class BuyersController : Controller
    {
        private Training_12Dec18_BangaloreEntities1 db = new Training_12Dec18_BangaloreEntities1();

        // GET: Buyers
        public ActionResult Index()
        {
            var buyers = db.Buyers.Include(b => b.City).Include(b => b.State);
            return View(buyers.ToList());
        }        

        public JsonResult GetCities(string state)
        {
            var cities = new List<string>();
            switch (state)
            {
                case "Telangana":
                    cities.Add("Hyderabad");
                    cities.Add("Warangal");
                    cities.Add("Nizamabad");
                    break;
                case "Andhra Pradesh":
                    cities.Add("Vishakapatnam");
                    cities.Add("Vijayawada");
                    break;
                case "Karnataka":
                    cities.Add("Bangalore");
                    cities.Add("Mysore");
                    break;
            }
            //Add JsonRequest behavior to allow retrieving states over http get  
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        // GET: Buyers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buyer buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            return View(buyer);
        }

        // GET: Buyers/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            var states = new List<string> { "Telangana", "Andhra Pradesh", "Karnataka" };
            var stateOptions = new SelectList(states);
            ViewBag.States = stateOptions;
            return View();
        }

        // POST: Buyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuyerId,UserName,FirstName,LastName,Password,DateOfBirth,PhoneNumber,EmailId,Adress,StateId,CityId")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                db.Buyers.Add(buyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", buyer.CityId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", buyer.StateId);
            return View(buyer);
        }

        // GET: Buyers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buyer buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", buyer.CityId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", buyer.StateId);
            return View(buyer);
        }

        // POST: Buyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuyerId,UserName,FirstName,LastName,Password,DateOfBirth,PhoneNumber,EmailId,Adress,StateId,CityId")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", buyer.CityId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", buyer.StateId);
            return View(buyer);
        }

        // GET: Buyers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buyer buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return HttpNotFound();
            }
            return View(buyer);
        }

        // POST: Buyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buyer buyer = db.Buyers.Find(id);
            db.Buyers.Remove(buyer);
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

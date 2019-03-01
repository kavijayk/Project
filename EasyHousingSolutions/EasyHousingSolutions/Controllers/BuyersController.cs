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
    public class BuyersController : Controller
    {
        private Training_12Dec18_BangaloreEntities1 db = new Training_12Dec18_BangaloreEntities1();

        // GET: Buyers
        public ActionResult Index()
        {
            return View();
        }
 
        public ActionResult ViewProperties()
        {
            return View(db.Properties.ToList());
        }


        // GET: Sellers/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SellerId,UserName,FirstName,LastName,password,DateOfBirth,PhoneNumber,Adress,StateId,CityId,EmailId")] Seller seller)
        {
            User newUser = new User();
            newUser.UserName = seller.UserName;
            newUser.Pasword = seller.password.ToString();
            newUser.UserType = "Seller";
            db.Users.Add(newUser);
            if (ModelState.IsValid)
            {
                db.Sellers.Add(seller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", seller.City);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", seller.State);
            return View(seller);
        }

        public ActionResult AddToCart(int id)
        {
            Cart cart = new Cart();
            cart.PropertyId = id;
            string test = Session["userName"].ToString();
            //string test =""
            cart.BuyerId = db.Buyers.Where(x => x.UserName == test).Select(x => x.BuyerId).FirstOrDefault();
            db.Carts.Add(cart);
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("DisplayCart", "Buyer");
        }

        public ActionResult DisplayCart()
        {
            List<Cart> carts = db.Carts.ToList();
            List<Property> CartProperties = null;
            foreach (var prop in carts)
            {
                CartProperties = db.Properties.Where(p => p.PropertyId == prop.PropertyId).ToList();
            }
            return View(CartProperties);
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

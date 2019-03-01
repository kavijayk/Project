using EasyHousingSolutions.Models;
using System;
using System.Collections.Generic;

using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyHousingSolutions.Controllers
{
    public class RegistrationController : Controller
    {
        Training_12Dec18_BangaloreEntities1 db = new Training_12Dec18_BangaloreEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterSeller()
        {
            MultipleModels mymodel = new Models.MultipleModels();

            return View(mymodel);
        }
        [HttpPost]
        public ActionResult RegisterSeller(MultipleModels multipleModel)
        {
            try
            {
                State stateId = null;
                City cityId = null;
                Seller seller = new Seller();
                User user = new User();
                user.UserName = multipleModel.userModel.UserName;
                user.Pasword = multipleModel.userModel.Pasword;
                user.UserType = "Seller";
                db.Users.Add(user);
                if (multipleModel.stateModel.StateName != null)
                {
                    stateId = db.States.Single(s => s.StateName == multipleModel.stateModel.StateName);
                }
                if (multipleModel.cityModel.CityName != null)
                {
                    cityId = db.Cities.Single(s => s.CityName == multipleModel.cityModel.CityName);
                }
                if (cityId != null && stateId != null)
                {
                    seller.UserName = multipleModel.userModel.UserName;
                    seller.FirstName = multipleModel.sellerModel.FirstName;
                    seller.LastName = multipleModel.sellerModel.LastName;
                    seller.DateOfBirth = multipleModel.sellerModel.DateOfBirth;
                    seller.PhoneNumber = multipleModel.sellerModel.PhoneNumber;
                    seller.Adress = multipleModel.sellerModel.Adress;
                    seller.EmailId = multipleModel.sellerModel.EmailId;
                    seller.CityId = cityId.CityId;
                    seller.StateId = stateId.StateId;
                    db.Sellers.Add(seller);
                }

                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("LoginUser", "LoginUser");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        public ActionResult RegisterBuyer()
        {
            MultipleModels mymodel = new MultipleModels();

            return View(mymodel);
        }
        [HttpPost]
        public ActionResult RegisterBuyer(MultipleModels multipleModel)
        {
            try
            {
                Buyer buyer = new Buyer();
                User user = new User();
                user.UserName = multipleModel.userModel.UserName;
                user.Pasword = multipleModel.userModel.Pasword;
                user.UserType = "Buyer";
                db.Users.Add(user);
                buyer.UserName = multipleModel.userModel.UserName;
                buyer.FirstName = multipleModel.buyerModel.FirstName;
                buyer.LastName = multipleModel.buyerModel.LastName;
                buyer.DateOfBirth = multipleModel.buyerModel.DateOfBirth;
                buyer.PhoneNumber = multipleModel.buyerModel.PhoneNumber;
                buyer.Adress = multipleModel.buyerModel.Adress;
                buyer.EmailId = multipleModel.buyerModel.EmailId;
                db.Buyers.Add(buyer);

                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("LoginUser", "LoginUser");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

    }
}
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector2._0.Models;

namespace TrashCollector2._0.Controllers
{
    public class CustomerAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerAccounts
        public ActionResult CustomerMenu()
        {
            var aspUserId = User.Identity.GetUserId();
            var customer = db.CustomerAccount.Where(c => c.AspUserId == aspUserId).SingleOrDefault();
            customer.Address = db.Addresses.Where(c => c.Id == customer.CustomerAddressId).SingleOrDefault();
            //ViewModel viewModel = new ViewModel()
            //{
            //    CustomerAccount = new CustomerAccount(),
            //    Address = new Address()
            //};
            //viewModel.CustomerAccount = customer;
            //viewModel.Address = customer.Address;
            return View(customer);
        }
     

        // GET: CustomerAccounts/Create
        public ActionResult Create()
        {
            ViewModel Viewmodel = new ViewModel()
            {
                CustomerAccount = new CustomerAccount(),
                Address = new Address(),


            };
            return View(Viewmodel);
        }

        // POST: CustomerAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModel viewModel)
        {

            db.Addresses.Add(viewModel.Address);
            db.SaveChanges();

            viewModel.CustomerAccount.CustomerAddressId = viewModel.Address.Id;
            viewModel.CustomerAccount.AspUserId = User.Identity.GetUserId();

            db.CustomerAccount.Add(viewModel.CustomerAccount);
            db.SaveChanges();

            return RedirectToAction("CustomerMenu");

            //ViewBag.CustomerAddressId = new SelectList(db.Addresses, "Id", "StreetAddress", viewModel.CustomerAccount.CustomerAddressId);
            //return View(viewModel.CustomerAccount);
        }

        // GET: CustomerAccounts/Edit/5
        public ActionResult ManagePickup()
        {
            try
            {
                var userLoggedIn = User.Identity.GetUserId();
                var customer = db.CustomerAccount.Where(c => c.AspUserId == userLoggedIn).Single();
                if (customer == null)
                {
                    return View();
                }
                var pickup = db.PickupDay.Where(e => e.CustomerID == customer.CustomerId).Single();

                if (pickup == null)
                {
                    return View();
                }
                return View(pickup);
            }
            catch
            {
                return View();
            }
            //var userLoggedIn = User.Identity.GetUserId();
            //var customer = db.CustomerAccount.Where(c => c.AspUserId == userLoggedIn).Single();
            //if (customer == null)
            //{
            //    return View();
            //}
            //var pickup = db.PickupDay.Where(e => e.CustomerID == customer.CustomerId).Single();

            //if(pickup == null)
            //{
            //    return View();
            //}
            //return View(pickup);

        }

        // POST: CustomerAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManagePickup(PickupDay PickupDay)
        {
            var userLoggedIn = User.Identity.GetUserId();
            var customer = db.CustomerAccount.Where(c => c.AspUserId == userLoggedIn).Single();
            var pickup = db.PickupDay.Where(e => e.CustomerID == customer.CustomerId).Single();
            db.PickupDay.Add(PickupDay);

            pickup.PickUpDay = PickupDay.PickUpDay;
            pickup.SuspendedStartDay = PickupDay.SuspendedStartDay;
            pickup.SuspendedEndDay = PickupDay.SuspendedEndDay;
            pickup.ExtraPickUp = PickupDay.ExtraPickUp;
            db.SaveChanges();
            return View(PickupDay);
        }
        //public ActionResult MakeAPayment()
        //{
        //    var aspUserId = User.Identity.GetUserId();
        //    var balance = db.AccountBalance.Where(b => b.AspUserId.Equals(aspUserId)).FirstOrDefault();
        //    //balance.TotalBalance = 0;
        //    db.SaveChanges();
        //    return View(balance);
        //}
    }
}


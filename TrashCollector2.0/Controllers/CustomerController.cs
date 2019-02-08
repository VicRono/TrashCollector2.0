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
        public ActionResult Index()
        {
            var aspUserId = User.Identity.GetUserId();
            var customer = db.CustomerAccount.Where(c => c.AspUserId == aspUserId).SingleOrDefault();
            customer.Address = db.Addresses.Where(c => c.Id == customer.CustomerAddressId).SingleOrDefault();
            //ViewModel viewModel = new ViewModel()
            //{
            //    CustomerList = new List<CustomerAccount>(),
            //    AddressList = new List<Address>()
            //};
            //viewModel.CustomerList = db.CustomerAccount.ToList();
            //viewModel.AddressList = db.Addresses.ToList();
            return View(customer);
        }

        // GET: CustomerAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAccount customerAccount = db.CustomerAccount.Find(id);
            if (customerAccount == null)
            {
                return HttpNotFound();
            }
            return View(customerAccount);
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

            return View(viewModel.CustomerAccount);

            //ViewBag.CustomerAddressId = new SelectList(db.Addresses, "Id", "StreetAddress", viewModel.CustomerAccount.CustomerAddressId);
            //return View(viewModel.CustomerAccount);
        }

        // GET: CustomerAccounts/Edit/5
        public ActionResult ManagePickup()
        {
            try {
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

            pickup.PickUpDay = PickupDay.PickUpDay;
            pickup.SuspendedStartDay = PickupDay.SuspendedStartDay;
            pickup.SuspendedEndDate = PickupDay.SuspendedEndDate;
            pickup.ExtraPickUp = PickupDay.ExtraPickUp;
            db.SaveChanges();
            return View(PickupDay);
        }
        
        // GET: CustomerAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAccount customerAccount = db.CustomerAccount.Find(id);
            if (customerAccount == null)
            {
                return HttpNotFound();
            }
            return View(customerAccount);
        }

        // POST: CustomerAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerAccount customerAccount = db.CustomerAccount.Find(id);
            db.CustomerAccount.Remove(customerAccount);
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

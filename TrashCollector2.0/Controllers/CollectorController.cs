using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector2._0.Models;

namespace TrashCollector2._0.Controllers
{
    //[Authorize(Roles = "Collector")]
    public class CollectorController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CollectorAccounts
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();
            var dbemployee = db.CollectorAccount.Where(u => u.AspUserId == userid).Single();
            dbemployee.Address = db.Addresses.Where(s => s.Id == dbemployee.CollectorAddressId).Single();
            var  matchingZipcodes = db.CustomerAccount.Where(c=>c.Address.ZipCode == dbemployee.Address.ZipCode).ToList();  
          return View(matchingZipcodes);

        }
        [HttpPost]
        public ActionResult Index(string DayOfWeek)
        {
            var userid = User.Identity.GetUserId();
            var dbemployee = db.CollectorAccount.Where(u => u.AspUserId == userid).Single();
            dbemployee.Address = db.Addresses.Where(s => s.Id == dbemployee.CollectorAddressId).Single();
            var CurrentDaySelected = db.PickupDay.Include(c => c.CustomerID).Where(e => e.PickUpDay == DayOfWeek).ToList();
            //Value.DayOfWeek.ToString() == DayOfWeek).ToList();
            //var customerList = db.PickupDay.Where(c => c == userid).Single();
            //var customerList = db.PickupDay.Where(l => l.PickUpDay = userid.CurrentDaySelected).Tolist();

            
            //has to return a list<Customers>
            return View("DailyPickUps",CurrentDaySelected);
        }

        // GET: CollectorAccounts/Details/5
        public ActionResult MyPickup(int id)
        {
            return View();
        }

        // GET: CollectorAccounts/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewModel Viewmodel = new ViewModel()
            {
                CollectorAccount = new CollectorAccount(),
                Address = new Address()
            };
            return View(Viewmodel);
        }

        // POST: CollectorAccounts/Create
        [HttpPost]
        public ActionResult Create(ViewModel ViewModel)
        {
            db.Addresses.Add(ViewModel.Address);
            db.SaveChanges();

            ViewModel.CollectorAccount.CollectorAddressId = ViewModel.Address.Id;
            ViewModel.CollectorAccount.AspUserId = User.Identity.GetUserId();

            db.CollectorAccount.Add(ViewModel.CollectorAccount);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: CollectorAccounts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CollectorAccounts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CollectorAccounts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CollectorAccounts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

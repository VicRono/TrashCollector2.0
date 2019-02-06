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
            var customerAccount = db.CustomerAccount.Include(c => c.Address);
            return View(customerAccount.ToList());
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
                Address = new Address()
                
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
            if (ModelState.IsValid)
            {
                var AspUserID = User.Identity.GetUserId();
                viewModel.CustomerAccount.AspUserId = AspUserID;
                db.CustomerAccount.Add(viewModel.CustomerAccount);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerAddressId = new SelectList(db.Addresses, "Id", "StreetAddress", viewModel.CustomerAccount.CustomerAddressId);
            return View(viewModel.CustomerAccount);
        }

        // GET: CustomerAccounts/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CustomerAddressId = new SelectList(db.Addresses, "Id", "StreetAddress", customerAccount.CustomerAddressId);
            return View(customerAccount);
        }

        // POST: CustomerAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerName,CustomerAddressId")] CustomerAccount customerAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerAddressId = new SelectList(db.Addresses, "Id", "StreetAddress", customerAccount.CustomerAddressId);
            return View(customerAccount);
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

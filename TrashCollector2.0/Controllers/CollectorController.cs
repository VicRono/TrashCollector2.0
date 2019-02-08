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
    public class CollectorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CollectorAccounts
        public ActionResult Index()
        {
            ViewModel viewModel = new ViewModel()
            {
                CustomerAccount = new CustomerAccount(),
                Address = new Address()
            };
            viewModel.CustomerList = db.CustomerAccount.ToList();
            viewModel.AddressList = db.Addresses.ToList();
            return View(viewModel);
        }

        // GET: CollectorAccounts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CollectorAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CollectorAccounts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RSML_web_app.Data;
using RSML_web_app.Models;

namespace RSML_web_app.Controllers
{
    public class ConfirmedDevicesInStoresController : Controller
    {
        private RSML_web_appdbContext db = new RSML_web_appdbContext();

        // GET: ConfirmedDevicesInStores
        public ActionResult Index()
        {
            return View(db.ConfirmedDevicesInStores.ToList());
        }

        // GET: ConfirmedDevicesInStores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmedDevicesInStore confirmedDevicesInStore = db.ConfirmedDevicesInStores.Find(id);
            if (confirmedDevicesInStore == null)
            {
                return HttpNotFound();
            }
            return View(confirmedDevicesInStore);
        }

        // GET: ConfirmedDevicesInStores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfirmedDevicesInStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeviceId,LastSeenDepartment,LastSeenTime")] ConfirmedDevicesInStore confirmedDevicesInStore)
        {
            if (ModelState.IsValid)
            {
                db.ConfirmedDevicesInStores.Add(confirmedDevicesInStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(confirmedDevicesInStore);
        }

        // GET: ConfirmedDevicesInStores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmedDevicesInStore confirmedDevicesInStore = db.ConfirmedDevicesInStores.Find(id);
            if (confirmedDevicesInStore == null)
            {
                return HttpNotFound();
            }
            return View(confirmedDevicesInStore);
        }

        // POST: ConfirmedDevicesInStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceId,LastSeenDepartment,LastSeenTime")] ConfirmedDevicesInStore confirmedDevicesInStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(confirmedDevicesInStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(confirmedDevicesInStore);
        }

        // GET: ConfirmedDevicesInStores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmedDevicesInStore confirmedDevicesInStore = db.ConfirmedDevicesInStores.Find(id);
            if (confirmedDevicesInStore == null)
            {
                return HttpNotFound();
            }
            return View(confirmedDevicesInStore);
        }

        // POST: ConfirmedDevicesInStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConfirmedDevicesInStore confirmedDevicesInStore = db.ConfirmedDevicesInStores.Find(id);
            db.ConfirmedDevicesInStores.Remove(confirmedDevicesInStore);
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

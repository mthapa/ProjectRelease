﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectRelease;
using ProjectRelease.Models;

namespace ProjectRelease.Controllers
{
    public class DeploymentsController : Controller
    {
        private ProjectReleaseContext db = new ProjectReleaseContext();

        // GET: Deployments
        public ActionResult Index()
        {
            return View(db.Deployments.ToList());
        }

        // GET: Deployments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deployment deployment = db.Deployments.Find(id);
            if (deployment == null)
            {
                return HttpNotFound();
            }
            return View(deployment);
        }

        // GET: Deployments/Create
        public ActionResult Create()
        {
            ViewBag.Agencies = new SelectList(db.Agencies, "AgencyId", "AgencyCode");
            return View();
        }

        // POST: Deployments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgencyId, DeploymentId,Version,Date,Environment,Remarks")] Deployment deployment)
        {
            if (ModelState.IsValid)
            {
                db.Deployments.Add(deployment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deployment);
        }

        // GET: Deployments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deployment deployment = db.Deployments.Find(id);
            if (deployment == null)
            {
                return HttpNotFound();
            }
            return View(deployment);
        }

        // POST: Deployments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeploymentId,Version,Date,Environment,Remarks")] Deployment deployment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deployment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deployment);
        }

        // GET: Deployments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deployment deployment = db.Deployments.Find(id);
            if (deployment == null)
            {
                return HttpNotFound();
            }
            return View(deployment);
        }

        // POST: Deployments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deployment deployment = db.Deployments.Find(id);
            db.Deployments.Remove(deployment);
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

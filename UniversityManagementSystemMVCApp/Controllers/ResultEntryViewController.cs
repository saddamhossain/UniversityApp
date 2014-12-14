using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemMVCApp.Models;
using UniversityManagementSystemMVCApp.Context;

namespace UniversityManagementSystemMVCApp.Controllers
{
    public class ResultEntryViewController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: /ResultEntryView/
        public ActionResult Index()
        {
            var resultentryviews = db.ResultEntryViews.Include(r => r.StudentRegistration);
            return View(resultentryviews.ToList());
        }

        // GET: /ResultEntryView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultEntryView resultentryview = db.ResultEntryViews.Find(id);
            if (resultentryview == null)
            {
                return HttpNotFound();
            }
            return View(resultentryview);
        }

        // GET: /ResultEntryView/Create
        public ActionResult Create()
        {
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "StudentRegistrationId", "RegistrationNumber");
            return View();
        }

        // POST: /ResultEntryView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ViewResultId,StudentRegistrationId,Name,Email,Department")] ResultEntryView resultentryview)
        {
            if (ModelState.IsValid)
            {
                db.ResultEntryViews.Add(resultentryview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "StudentRegistrationId", "Name", resultentryview.StudentRegistrationId);
            return View(resultentryview);
        }

        // GET: /ResultEntryView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultEntryView resultentryview = db.ResultEntryViews.Find(id);
            if (resultentryview == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "StudentRegistrationId", "Name", resultentryview.StudentRegistrationId);
            return View(resultentryview);
        }

        // POST: /ResultEntryView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ViewResultId,StudentRegistrationId,Name,Email,Department")] ResultEntryView resultentryview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultentryview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "StudentRegistrationId", "Name", resultentryview.StudentRegistrationId);
            return View(resultentryview);
        }

        // GET: /ResultEntryView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultEntryView resultentryview = db.ResultEntryViews.Find(id);
            if (resultentryview == null)
            {
                return HttpNotFound();
            }
            return View(resultentryview);
        }

        // POST: /ResultEntryView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResultEntryView resultentryview = db.ResultEntryViews.Find(id);
            db.ResultEntryViews.Remove(resultentryview);
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

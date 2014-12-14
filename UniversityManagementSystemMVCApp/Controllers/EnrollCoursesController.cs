using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemMVCApp.Context;
using UniversityManagementSystemMVCApp.Models;

namespace UniversityManagementSystemMVCApp.Controllers
{
    public class EnrollCoursesController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: EnrollCourses
        public ActionResult Index()
        {
            return View(db.EnrollCourses.ToList());
        }

        // GET: EnrollCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollCourse = db.EnrollCourses.Find(id);
            if (enrollCourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollCourse);
        }

        // GET: EnrollCourses/Create
        public ActionResult Create()
        {
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "StudentRegistrationId", "RegistrationNumber");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            return View();
        }

        // POST: EnrollCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollCourseId,StudentRegistrationId,Name,Email,Department,CourseId,EnrollDate")] EnrollCourse enrollCourse)
        {
            List<EnrollCourse> courseEnrolledAlreadyList = (from anEnrolledCourse in db.EnrollCourses
                                                            where anEnrolledCourse.CourseId == enrollCourse.CourseId
                                                            select anEnrolledCourse).ToList();
           
            if (courseEnrolledAlreadyList.Any(aCourse => aCourse.CourseId == enrollCourse.CourseId) 
                && courseEnrolledAlreadyList.Any(acourse=>acourse.StudentRegistrationId==enrollCourse.StudentRegistrationId))
            {
                ViewBag.Message = "This Particular Course  has already been assigned to this registration Number";
            }
            else
            {
                db.EnrollCourses.Add(enrollCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentRegistrationId = new SelectList(db.StudentRegistrations, "StudentRegistrationId", "RegistrationNumber");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            return View(enrollCourse);
        }

        // GET: EnrollCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollCourse = db.EnrollCourses.Find(id);
            if (enrollCourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollCourse);
        }

        // POST: EnrollCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollCourseId,StudentRegistrationId,Name,Email,Department,CourseId,EnrollDate")] EnrollCourse enrollCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enrollCourse);
        }

        // GET: EnrollCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollCourse = db.EnrollCourses.Find(id);
            if (enrollCourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollCourse);
        }

        // POST: EnrollCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollCourse enrollCourse = db.EnrollCourses.Find(id);
            db.EnrollCourses.Remove(enrollCourse);
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
        //public ActionResult GetStudentRegInfoForResultEntry(int regId)
        //{
        //    var reginfo = db.StudentRegistrations.Where(x => x.StudentRegistrationId == regId).FirstOrDefault();
        //    return Json(reginfo, JsonRequestBehavior.AllowGet);
        //}

    }
}

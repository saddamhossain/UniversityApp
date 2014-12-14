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
    public class StudentRegistrationsController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: StudentRegistrations
        public ActionResult Index()
        {
            var studentRegistrations = db.StudentRegistrations.Include(s => s.Department);
            return View(studentRegistrations.ToList());
        }

        // GET: StudentRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return HttpNotFound();
            }
            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="StudentRegistrationId,Name,Email,Contact,RegistrationDate,Address,DepartmentId,RegistrationNumber")] StudentRegistration studentRegistration)
        {
            string departmentCode = db.Departments.Find(studentRegistration.DepartmentId).Code;
            string regNo = string.Format(studentRegistration.RegistrationDate.Year+ "_" + departmentCode + "_");
            var students = (from aStudent in db.StudentRegistrations
                where (aStudent.DepartmentId == studentRegistration.DepartmentId && aStudent.RegistrationDate.Year == studentRegistration.RegistrationDate.Year)
                select aStudent).ToList();
            int totalNoOfStudentInDept = students.Count();
            if (totalNoOfStudentInDept < 10)
            {
                regNo += string.Format("00" +(totalNoOfStudentInDept + 1));
            }
            else if (totalNoOfStudentInDept >= 10)
            {
                regNo += string.Format("0" + (totalNoOfStudentInDept + 1));
            }
            else
            {
                regNo += string.Format("" + (totalNoOfStudentInDept + 1));
            }

            studentRegistration.RegistrationNumber = regNo;

            if (ModelState.IsValid)
            {
                db.StudentRegistrations.Add(studentRegistration);
                db.SaveChanges();
                ViewBag.Message = "Mr/Mrs " + studentRegistration.Name + " your registration no is: " + regNo;
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", studentRegistration.DepartmentId);
            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", studentRegistration.DepartmentId);
            return View(studentRegistration);
        }

        // POST: StudentRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentRegistrationId,Name,Email,Contact,RegistrationDate,Address,DepartmentId,RegistrationNumber")] StudentRegistration studentRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", studentRegistration.DepartmentId);
            return View(studentRegistration);
        }

        // GET: StudentRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return HttpNotFound();
            }
            return View(studentRegistration);
        }

        // POST: StudentRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            db.StudentRegistrations.Remove(studentRegistration);
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
        public ActionResult GetStudentRegInfo(int regId)
        {
            var reginfo = db.StudentRegistrations.Where(x => x.StudentRegistrationId == regId).FirstOrDefault();
            return Json(reginfo, JsonRequestBehavior.AllowGet);
        }

    }
}

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
    public class CourseAssignController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: /CourseAssign/
        public ActionResult Index()
        {
            var courseassigns = db.CourseAssigns.Include(c => c.Course).Include(c => c.Department).Include(c=>c.Teacher);
            return View(courseassigns.ToList());
        }

        // GET: /CourseAssign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // GET: /CourseAssign/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code");
           
            return View();
        }

        // POST: /CourseAssign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CourseAssignId,DepartmentId,TeacherId,CreditToBeTaken,RemainingToBeTaken,CourseId,Name,Credit")] CourseAssign courseassign)
        {

            //int remainingCreditToBeTaken = int.Parse(courseassign.RemainingToBeTaken);
            //int courseCredit = int.Parse(courseassign.Credit);
            List<CourseAssign> courseAlreadyAssignedToATeacherList = (from anAssignedCourse in db.CourseAssigns
                                                                      where anAssignedCourse.TeacherId == courseassign.TeacherId
                                                                      select anAssignedCourse).ToList();

            if ((courseAlreadyAssignedToATeacherList.Any(acourse => acourse.CourseId == courseassign.CourseId))
                && (courseAlreadyAssignedToATeacherList.Any(ateacher => ateacher.TeacherId == courseassign.TeacherId)))
            {
                ViewBag.Message = "Sorry,already assigned";
            }
            else
            {
                courseassign.RemainingToBeTaken = (int.Parse(courseassign.RemainingToBeTaken) - int.Parse(courseassign.Credit)).ToString();
                db.CourseAssigns.Add(courseassign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            return View(courseassign);











            //if (ModelState.IsValid)
            //{
            //    db.CourseAssigns.Add(courseassign);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            //ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name");
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code");
            //return View(courseassign);
        }

        // GET: /CourseAssign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", courseassign.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", courseassign.DepartmentId);
            return View(courseassign);
        }

        // POST: /CourseAssign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CourseAssignId,DepartmentId,TeacherId,CreditToBeTaken,RemainingToBeTaken,CourseId,Name,Credit")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseassign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", courseassign.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", courseassign.DepartmentId);
            return View(courseassign);
        }

        // GET: /CourseAssign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // POST: /CourseAssign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            db.CourseAssigns.Remove(courseassign);
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


        public ActionResult GetAllTeacher(int departmentId)
        {
            var teachers = db.Teachers.Where(x => x.DepartmentId == departmentId).FirstOrDefault();
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllTeacherInfo(int myteacherId)
        {
            var teachersinfo = db.Teachers.Where(x => x.TeacherId == myteacherId).FirstOrDefault();
            return Json(teachersinfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCourseInfo(int mycourseId)
        {
            var courses = db.Courses.Where(x => x.CourseId == mycourseId).FirstOrDefault();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }


        public ViewResult ViewCourseStatus()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            return View();
        }

        public PartialViewResult CourseStatusLoad(int? departmentId)
        {
            List<Course> courseList = new List<Course>();
            if (departmentId != null)
            {
                courseList = db.Courses.Where(r => r.DepartmentId == departmentId).ToList();
                if (courseList.Count == 0)
                {
                    ViewBag.NotAssigned = "Department Empty";
                }
            }


            return PartialView("~/Views/shared/_CourseStatus.cshtml", courseList);
        }
    }
}

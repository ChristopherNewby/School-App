using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentCoursesController : Controller
    {
        private SchoolAppEntities db = new SchoolAppEntities();

        // GET: RentalRecords
        public ActionResult Index()
        {
            
            var SC = db.StudentsCourses.Include(r => r.Student).Include(r => r.Cours);
            return View(SC.ToList());
        }

        // GET: RentalRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsCours studentcourse = db.StudentsCourses.Find(id);
            if (studentcourse == null)
            {
                return HttpNotFound();
            }
            return View(studentcourse);
        }

        // GET: RentalRecords/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName","CourseDescription");
            return View();
        }

        // POST: RentalRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName,CourseId,CourseName,CourseDescription,Something")] StudentsCours StudentCourse)
        {
            if (ModelState.IsValid)
            {
                db.StudentsCourses.Add(StudentCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(StudentCourse);
        }

        // GET: RentalRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsCours studentcourse = db.StudentsCourses.Find(id);
            if (studentcourse == null)
            {
                return HttpNotFound();
            }            
            return View(studentcourse);
        }

        // POST: RentalRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName,CourseId,CourseName,CourseDescription")] StudentsCours StudentCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(StudentCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(StudentCourse);
        }

        // GET: RentalRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsCours studentCourse = db.StudentsCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // POST: RentalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentsCours studentCourse = db.StudentsCourses.Find(id);
            db.StudentsCourses.Remove(studentCourse);
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

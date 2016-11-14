using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentsController : Controller
    {
        private SchoolAppEntities db = new SchoolAppEntities();

        // GET: Students
        public ActionResult Index()
        {
            //var whatever = from d in db.StudentsCourses
            //               join c in db.Students on d.StudentId equals c.StudentId
            //               join m in db.Courses on d.CourseId equals m.CourseId
            //               select new Class2
            //               {
            //                   newStudent = c,
            //                   newCourse = m,
            //                   newStudCourse = d,

            //               };

            //return View(whatever);
            return View(db.Students.ToList());
        }



        public ActionResult Create()
        {            
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: RentalRecords/Details/5
        public ActionResult Details(int? id)
        {
            var whatever = from d in db.StudentsCourses
                           join c in db.Students on d.StudentId equals c.StudentId
                           join m in db.Courses on d.CourseId equals m.CourseId
                           select new Class2
                           {
                               newStudent = c,
                               newCourse = m,
                               newStudCourse = d,

                           };
            return View(whatever);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Student student = db.Students.Find(id);
            //if (student == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(student);
        }

        // GET: RentalRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: RentalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: RentalRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: RentalRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
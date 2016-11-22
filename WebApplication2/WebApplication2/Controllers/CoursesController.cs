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
    public class CoursesController : Controller
    { 

    private SchoolAppEntities db = new SchoolAppEntities();

    // GET: Students
    public ActionResult Index()
    {
        return View(db.Courses.ToList());
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
    public ActionResult Create([Bind(Include = "CourseId,CourseName,CourseDescription")] Cours course)
    {
        if (ModelState.IsValid)
        {
            db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(course);
    }

    // GET: RentalRecords/Details/5
    public ActionResult Details(int? id)
    {            
            var course = (from c in db.Courses
                          where c.CourseId == id
                          select c).FirstOrDefault();

            var studentList = from d in db.StudentsCourses
                              join p in db.Students on d.StudentId equals p.StudentId
                              where d.CourseId == id
                              select p;

            coursesModel cModel = new coursesModel();

            cModel.newCourse = course;
            cModel.newStudent = studentList.ToList();
            return View(cModel);
    }

    // GET: RentalRecords/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Cours course = db.Courses.Find(id);
        if (course == null)
        {
            return HttpNotFound();
        }
        return View(course);
    }

    // POST: RentalRecords/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Cours course = db.Courses.Find(id);
        db.Courses.Remove(course);
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
        Cours course = db.Courses.Find(id);
        if (course == null)
        {
            return HttpNotFound();
        }
        return View(course);
    }

    // POST: RentalRecords/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,CourseDescription")] Cours course)
        {
        if (ModelState.IsValid)
        {
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(course);
    }
}
}
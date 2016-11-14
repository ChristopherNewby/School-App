using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private SchoolAppEntities db = new SchoolAppEntities(); 

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }


    }
}
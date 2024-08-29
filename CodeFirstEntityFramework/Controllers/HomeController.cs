using CodeFirstEntityFramework.Models;
using CodeFirstEntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;

namespace CodeFirstEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        //  Context objcon=new Context();
        clsContext objcon =new clsContext();
        public ActionResult Index()
        {
            var Students = objcon.tblStudents.ToList();
            return View(Students);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Students obj)
        {
          //  Context.Context.tblStudents.Add(obj);
          objcon.tblStudents.Add(obj);  
            objcon.SaveChanges();
            return View();
        }

        public ActionResult Edit(int? id)
        {
            var Student = objcon.tblStudents.SingleOrDefault(e => e.StudentId == id);
            if (Student == null)
            {
                return HttpNotFound();
            }
            return View(Student);
        }

        [HttpPost]
        public ActionResult Edit(Students stud)
        {
            if (ModelState.IsValid)
            {
                objcon.Entry(stud).State = EntityState.Modified;
                objcon.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stud);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var Students = objcon.tblStudents.SingleOrDefault(x => x.StudentId == id);
            objcon.tblStudents.Remove(Students ?? throw new InvalidOperationException());
            objcon.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
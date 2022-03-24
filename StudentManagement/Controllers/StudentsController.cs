using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            StudentList stuList = new StudentList();
            List<Student> obj = stuList.GetStudent(string.Empty).OrderBy(x=>x.FullName).ToList();
            return View(obj);
        }

        //POST: Student
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student stu)
        {
            //kiem tra da nhap du cac truong
            if (ModelState.IsValid)
            {
                StudentList stuList = new StudentList();
                stuList.AddStudent(stu);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    
}
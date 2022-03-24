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
        // Hien thi danh sach sinh vien
        public ActionResult Index()
        {
            StudentList stuList = new StudentList();
            List<Student> obj = stuList.getStudent(string.Empty).OrderBy(x=>x.FullName).ToList();
            return View(obj);
        }

        //Them moi sinh vien
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

        //Cap nhat thong tin sinh vien
        public ActionResult Edit(string id = "")
        {
            StudentList stuList = new StudentList();
            List<Student> obj = stuList.getStudent(id); //.OrderBy(x => x.FullName).ToList()
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Student stu)
        {
            StudentList stuList = new StudentList();
            stuList.UpdateStudent(stu);
            return RedirectToAction("Index");
        }

    }
    
}
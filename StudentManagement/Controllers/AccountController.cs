using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source = NTTRUNG1; database = LoginAcount; Integrated Security=true";
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from login where username='" + acc.Name + "' and password='" + acc.Password + "'";
            dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                con.Close();
                return View("Fail");
            }
            else
            {
                Session["ID"] = acc.ID;
                return RedirectToAction("Index", "Students");
            }

        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}
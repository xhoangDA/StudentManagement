using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static StudentManagement.Models.StudentList;

namespace StudentManagement.Controllers
{
    public class StudentApiController : ApiController
    {
        private SqlConnection con;
        private SqlDataAdapter da;

        // GET: api/StudentApi
        [HttpGet]
        [Route("students")]
        public List<Student> GetStudentList()
        {
            DbConnection db = new DbConnection();
            string sql;
            sql = "SELECT * FROM Students";
            
            List<Student> stuList = new List<Student>();
            DataTable dt = new DataTable();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open(); //Ket noi den database
            da.Fill(dt); //Do du lieu vao data table
            da.Dispose(); //Đóng command
            con.Close(); // huy ket noi database

            Student tmpStu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpStu = new Student();
                tmpStu.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                tmpStu.FullName = dt.Rows[i]["Fullname"].ToString();
                tmpStu.Address = dt.Rows[i]["Address"].ToString();
                tmpStu.Note = dt.Rows[i]["Note"].ToString();
                stuList.Add(tmpStu);
            }
            return stuList;
        }

        //// GET: api/StudentApi/5
        [Route("students/{ID}")]
        public Student GetStudent(int ID)
        {
            string sql = "SELECT * FROM Students WHERE ID = " + ID.ToString();

            DbConnection db = new DbConnection();
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            Student stu = new Student();
            while (dr.Read())
            {
                stu.ID = Convert.ToInt32(dr["ID"]);
                stu.FullName = dr["Fullname"].ToString();
                stu.Address = dr["Address"].ToString();
                stu.Note = dr["Note"].ToString();
            }
            con.Close();
           
            return stu;
        }

        // POST: api/StudentApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/StudentApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StudentApi/5
        public void Delete(int id)
        {
        }
    }
}

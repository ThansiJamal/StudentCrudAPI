using StudentCrudAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace StudentCrudAPI.Controllers
{
    public class StudentController : ApiController
    {
        // GET: Student
        [System.Web.Http.HttpPost]
        public string AddStudent(Student student)
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=DBStudentAPI;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("AddStudent", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Place", student.Place);
            cmd.Parameters.AddWithValue("@MobileNumber", student.MobileNumber);
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Data Saved Successfully";
        }
        [System.Web.Http.HttpGet]
        public Student GetStudent(Student student)
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=DBStudentAPI;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("GetStudent", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", student.Id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                student.Id = (int)dr["Id"];
                student.Name = (string)dr["Name"];
                student.Email = (string)dr["Email"];
                student.Place = (string)dr["Place"];
                student.MobileNumber = (string)dr["MobileNumber"];
            }
            connect.Close();
            return student;
        }
        [System.Web.Http.HttpPut]
        public string UpdateStudent(Student student)
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=DBStudentAPI;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("UpdateStudent", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", student.Id);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Place", student.Place);
            cmd.Parameters.AddWithValue("@MobileNumber", student.MobileNumber);
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Data Update Successfully";
        }
        [System.Web.Http.HttpDelete]
        public string DeleteStudent(int id)
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=DBStudentAPI;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("DeleteStudent", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Data Delete Successfully";
        }
    }
}
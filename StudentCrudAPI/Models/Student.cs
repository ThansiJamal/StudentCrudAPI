using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCrudAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Place { get; set; }
        public string MobileNumber { get; set; }
    }
}
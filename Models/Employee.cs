using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotnet_api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public float Salary { get; set; }

        public bool IsDeveloper { get; set; }

        public DateTime StartWorkingDate { get; set; }

    }
}
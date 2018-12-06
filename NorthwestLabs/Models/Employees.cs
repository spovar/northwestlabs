using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Models
{
    [Table("Employee")]
    public class Employees
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public float HourlyRate { get; set; }

        public string JobRole { get; set; }

    }
}
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Xamarin.Forms;

namespace finalyearproject.AdminDetails
{
   public class Teacher
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FacultyNo { get; set; }
        [Required]
        public string Alias { get;set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.Text;

namespace finalyearproject.AdminDetails
{
    public class Subjects
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CourseType { get; set; }
        public string Department { get; set; }
        public string ClassRoom { get; set; }
    }
}

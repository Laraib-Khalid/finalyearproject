using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xamarin.Forms;

namespace finalyearproject.AdminDetails
{
    public class Classrooms
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace finalyearproject.AdminDetails.Allotment
{
    public class DayTime
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public string Time { get; set; }
    }
}

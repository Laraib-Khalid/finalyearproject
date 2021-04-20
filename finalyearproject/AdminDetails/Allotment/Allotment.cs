using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace finalyearproject.AdminDetails.Allotment
{
    public class Allotment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectTitle { get; set; }
        public string Department { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string ACourseType { get; set; }
        public int ClassRoomID { get; set; }
        public string ClassRoomName { get; set; }
        public string LectureDay { get; set; }
        public string LectureTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace finalyearproject.AdminDetails.Allotment
{
    public class Allotment
    {
        public int SubjectID { get; set; }
        public string SubjectTitle { get; set; }

        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string ACourseType { get; set; }
        public int ClassRoomID { get; set; }
        public string LectureDay { get; set; }
        public string LectureTime { get; set; }
    }
}

using finalyearproject.AdminDetails;
using finalyearproject.AdminDetails.Allotment;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace finalyearproject
{
    public interface SQLiteInterface
    {
        SQLiteConnection GetConnectionwithCreateDatabase();
        bool AddClassroom(Classrooms classroom);
        List<Classrooms> GetClassrooms();
        bool UpdateClassroom(Classrooms classroom);
        void DeleteClassroom(int Id);
        bool AddSubject(Subjects sub);
        List<Subjects> GetSubject();
        bool UpdateSubject(Subjects sub);
        void DeleteSubject(int Id);
        bool AddTeacher(Teacher te);
        bool AddDayTime(DayTime dayTime);
        List<DayTime> GetDayTime();
        void DeleteDayTime(int Id);
        List<Teacher> GetTeacher();
        List<Allotment> GetAllotments();
        List<Allotment> GetClassroomAllotments(int Cid);
        List<Allotment> GetTeacherAllotments(int Tid);
        bool UpdateTeacher(Teacher te);
        bool TeacherPreferences(TeacherAndSubjectTable tesub);
        void DeleteTeacher(int Id);
        void Longtime(string message);
        void Shorttime(string message);
        void DeleteAllotment(int Id);
    }
}

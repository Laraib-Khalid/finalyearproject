using Android.Widget;
using finalyearproject.AdminDetails;
using finalyearproject.AdminDetails.Allotment;
using finalyearproject.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace finalyearproject.Droid
{
    public class SQLite_Android : SQLiteInterface
    {
        SQLiteConnection conn;
        public SQLiteConnection GetConnectionwithCreateDatabase()
        {
            string dbname = "mydatabase.sqlite";
            string dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(dbpath, dbname);
            conn = new SQLiteConnection(path);
            conn.CreateTable<Classrooms>();
            conn.CreateTable<Teacher>();
            conn.CreateTable<DayTime>();
            conn.CreateTable<Subjects>();
            conn.CreateTable<Allotment>();
            conn.CreateTable<TeacherAndSubjectTable>();
            //Console.WriteLine("modified");
            return conn;

        }
        public bool AddClassroom(Classrooms classroom)
        {
            bool res = false;
            try
            {
                conn.Insert(classroom);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }

        public void DeleteClassroom(int Id)
        {
            string sql = $"Delete from Classrooms where Id ={Id}";
            conn.Execute(sql);
        }

        public List<Classrooms> GetClassrooms()
        {
            string sql = $"Select * from Classrooms";
            List<Classrooms> classroom = conn.Query<Classrooms>(sql);
            return classroom;
        }

        public void Longtime(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void Shorttime(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }

        public bool UpdateClassroom(Classrooms classroom)
        {
            bool res = false;
            try
            {
                string sql = $"Update Classrooms set Name='{classroom.Name}', Department='{classroom.Department}' where Id={classroom.Id}";
                conn.Execute(sql);
                res = true;
            }
            catch(Exception ex)
            {
                res = false;
            }
            return res;
        }

        public bool AddSubject(Subjects sub)
        {
            bool res = false;
            try
            {
                conn.Insert(sub);
                res = true;
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public List<Subjects> GetSubject()
        {
            string sql = $"Select * from Subjects";
            List<Subjects> sub = conn.Query<Subjects>(sql);
            return sub;
        }

        public bool UpdateSubject(Subjects sub)
        {
            bool res = false;
            try
            {
                string sql = $"Update Subjects set Name='{sub.Name}',Code='{sub.Code}',CourseType='{sub.CourseType}'," +
                    $"ClassRoom='{sub.ClassRoom}',Department='{sub.Department}' where Id={sub.Id}";
                conn.Execute(sql);
                res = true;
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public void DeleteSubject(int Id)
        {
            string sql = $"Delete from Subjects where Id ={Id}";
            conn.Execute(sql);
        }

        public bool AddTeacher(Teacher te)
        {
            bool res = false;
            try
            {
                conn.Insert(te);
                res = true;
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public List<Teacher> GetTeacher()
        {
            string sql = $"Select * from Teacher";
            List<Teacher> te = conn.Query<Teacher>(sql);
            return te;
        }

        public bool UpdateTeacher(Teacher te)
        {
            bool res = false;
            try
            {
                string sql = $"Update Teacher set Name='{te.Name}',FacultyNo='{te.FacultyNo}'," +
                    $"Alias='{te.Alias}',ContactNo='{te.ContactNo}',Designation='{te.Designation}'," +
                    $"Email='{te.Email}',Password='{te.Password}' where Id={te.ID}";
                conn.Execute(sql);
                res = true;
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public void DeleteTeacher(int Id)
        {
            string sql = $"Delete from Teacher where Id ={Id}";
            conn.Execute(sql);
        }

        List<Allotment> SQLiteInterface.GetAllotments()
        {
            string sql = $"Select * from Allotment";
            List<Allotment> te = conn.Query<Allotment>(sql);
            return te;
        }

        public List<Allotment> GetClassroomAllotments(int Cid)
        {
            string sql = $"Select * from Allotment where ClassRoomID={Cid}";
            List<Allotment> te = conn.Query<Allotment>(sql);
            return te;
        }

        public List<Allotment> GetTeacherAllotments(int Tid)
        {
            string sql = $"Select * from Allotment where TeacherID={Tid}";
            List<Allotment> te = conn.Query<Allotment>(sql);
            return te;
        }

        public bool TeacherPreferences(TeacherAndSubjectTable tesub)
        {
            bool res = false;
            try
            {
                conn.Insert(tesub);
                res = true;
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public void DeleteAllotment(int Id)
        {
            string sql = $"Delete  from Allotment where ID='Id'";
            conn.Execute(sql);
        }

        public bool AddDayTime(DayTime dayTime)
        {
            bool res = false;
            try
            {
                conn.Insert(dayTime);
                res = true;
            }
            catch
            {
                res = false;
            }
            return res;
        }
        public void DeleteDayTime(int Id)
        {
            string sql = $"Delete  from DayTime";
            conn.Execute(sql);
        }

        public List<DayTime> GetDayTime()
        {
            string sql = $"Select * from DayTime";
            List<DayTime> te = conn.Query<DayTime>(sql);
            return te;
        }
    }
}
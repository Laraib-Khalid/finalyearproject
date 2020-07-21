//using Android.Widget;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace finalyearproject.AdminDetails.Allotment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllotmentPage : ContentPage
    {
        public SQLiteConnection conn;
        public Subjects sub;
        public Teacher te;
        public AllotmentPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteInterface>().GetConnectionwithCreateDatabase();
            loadAllPickers();
        }
        private void loadAllPickers()
        {
            getAllotmentDAata();
            setSubject();
            // setTeacher();
            setCourse();
            setClassRooms();
        }
        private void setSubject()
        {
            var getSubject = conn.Query<Subjects>("SELECT Id,Name FROM Subjects");
            SubjectPicker.ItemsSource = getSubject;
        }
        //private void setTeacher()
        //{
        //    var getTeacher = conn.Query<Teacher>("SELECT Id,Name FROM Teacher");
        //    TeacherPicker.ItemsSource = getTeacher;
        //}
        private void setCourse()
        {
            var getCourse = conn.Query<Subjects>("SELECT CourseType FROM Subjects");
            CoursePicker.ItemsSource = getCourse;
        }
        public void setClassRooms()
        {
            var getClassrooms = conn.Query<Classrooms>("SELECT Id,Name FROM Classrooms");
            classPicker.ItemsSource = getClassrooms;
        }
        public bool saveAllotment(Allotment allotment)
        {
            try
            {
                conn.Insert(allotment);
                return true;
            }
            catch (Exception ex)
            {
                DisplayAlert(ex.Message.ToString(), "EXCEPTION", "", "Yes");
                return false;
            }
        }
        public void getAllotmentDAata()
        {
            try
            {
                //                conn.Table<Allotment>.allotments;
                //                var allotments = conn.Query<Allotment>("SELECT * from Allotment");

                list.ItemsSource = null;
                var getAllotments = DependencyService.Get<SQLiteInterface>().GetAllotments();
                list.ItemsSource = getAllotments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        private void Allot_Clicked(object sender, EventArgs e)
        {
            //    if (SubjectPicker.SelectedIndex != -1)
            //    {
            //        //var SelectedItem = (string)SubjectPicker.SelectedItem;
            //        var SelectedItem = SubjectPicker.SelectedItem as Subjects;
            //        string qry = "SELECT Code,Name,CourseType FROM Subjects s where s.Name="+SelectedItem.Name.ToString()+"";
            //        var Subject = conn.Query<Subjects>(qry);
            //        list.ItemsSource = Subject;
            //    }
            //    else
            //    {
            //       // Display();
            //    }
            // var SelectedTeacher = (Teacher)TeacherPicker.SelectedItem;
            var SelectedClassRoom = (Classrooms)classPicker.SelectedItem;
            var SelectedSubject = (Subjects)SubjectPicker.SelectedItem;
            var SelectedType = (Subjects)CoursePicker.SelectedItem;
            var SelectedTime = timePicker.SelectedItem.ToString();
            var Selectedday = dayPicker.SelectedItem.ToString();
            Allotment allotment = new Allotment
            {
                TeacherID = tID,
                SubjectTitle = SelectedSubject.Name,
                TeacherName = tName,
                ClassRoomID = SelectedClassRoom.Id,
                SubjectID = SelectedSubject.Id,
                ACourseType = SelectedType.CourseType,
                LectureTime = SelectedTime,
                LectureDay = Selectedday
            };

            if (saveAllotment(allotment))
            {
                DisplayAlert("Saved Successfully", "Message", "", "Yes");
            }
            else
            {
                DisplayAlert("Error Encountered", "Error", "", "Yes");
            }
        }
        string tName;
        int tID;
        private void SubjectPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSubject = (Subjects)SubjectPicker.SelectedItem;
            string qry = "SELECT tt.TeacherID as ID,t.Name as Name FROM Teacher t " +
                "inner join TeacherAndSubjectTable tt on t.Id=tt.TeacherID " +
                "where tt.Experience=(select max(ty.Experience) from " +
                "TeacherAndSubjectTable ty where ty.SubjectID='" + selectedSubject.Id + "')";
            var getTeacher = conn.Query<Teacher>(qry).FirstOrDefault();
            tName = getTeacher.Name.ToString();
            tID = getTeacher.Id;
            txtTeacherName.Text = tName;

        }
    }
}
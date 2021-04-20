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
        private ViewCell lastCell;
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
            setDay();
            setDepartment();
        }

        private void setDepartment()
        {
            var getDepartment = conn.Query<Classrooms>("SELECT DISTINCT Department FROM Classrooms");
            DepartmentPicker.ItemsSource = getDepartment;
        }

        private void DepartmentPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var department = (Classrooms)DepartmentPicker.SelectedItem;
            var getClass = conn.Query<Classrooms>("SELECT DISTINCT Id,Name FROM Classrooms where Department = '" + department.Department + "'");
            ClassPicker.ItemsSource = getClass;
        }
        private void setDay()
        {
           var getDay = conn.Query<DayTime>("SELECT DISTINCT Day FROM DayTime");
            dayPicker.ItemsSource = getDay;
        }

        private void dayPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var day = (DayTime)dayPicker.SelectedItem;
            var getTime = conn.Query<DayTime>("SELECT Time FROM DayTime  where Day = '" + day.Day + "'");
            timePicker.ItemsSource = getTime;
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
                DisplayAlert("EXCEPTION", ex.Message.ToString(),  "", "Yes");
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
                var SelectedClassRoom = (Classrooms)ClassPicker.SelectedItem;
                var SelectedSubject = (Subjects)SubjectPicker.SelectedItem;
                var SelectedDepartment = (Classrooms)DepartmentPicker.SelectedItem;
                var SelectedTime = (DayTime)timePicker.SelectedItem;
                var Selectedday = (DayTime)dayPicker.SelectedItem;
                if (SelectedClassRoom==null||Selectedday==null||SelectedDepartment==null||SelectedSubject==null||SelectedTime==null)
                {
                    DisplayAlert("Message","Please Fill all data","OK");
                }
                else
                {
                Allotment allotment = new Allotment
                {
                    TeacherID = tID,
                    SubjectTitle = SelectedSubject.Name,
                    TeacherName = tName,
                    ClassRoomID = SelectedClassRoom.Id,
                    ClassRoomName = SelectedClassRoom.Name,
                    SubjectID = SelectedSubject.Id,
                    ACourseType = SelectedSubject.CourseType,
                    LectureTime = SelectedTime.Time,
                    LectureDay = Selectedday.Day
                };
                var chk = conn.Query<Allotment>("select * from Allotment");
                if (chk.FirstOrDefault().TeacherID == allotment.TeacherID && chk.FirstOrDefault().LectureDay == allotment.LectureDay && chk.FirstOrDefault().LectureTime == allotment.LectureTime)
                {
                    DisplayAlert("Message", "The Teacher is already booked for Selected Day and Time", "OK");
                }
                else if (chk.FirstOrDefault().ClassRoomID == allotment.ClassRoomID && chk.FirstOrDefault().LectureDay == allotment.LectureDay && chk.FirstOrDefault().LectureTime == allotment.LectureTime)
                {
                    
                    DisplayAlert("Message", "This Class is already booked for Selected Day and Time", "OK");
                }
                else
                {
                    if (saveAllotment(allotment))
                    {
                        DisplayAlert("Message", "Data Saved Successfully", "", "OK");
                        getAllotmentDAata();
                        Clear();
                    }
                    else
                    {
                        DisplayAlert("Error", "Error found", "", "OK");
                    }
                }
            }
        }
        string tName;
        int tID;
        private void SubjectPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedClass = (Classrooms)ClassPicker.SelectedItem;
            var selectedSubject = (Subjects)SubjectPicker.SelectedItem;
            string qry = "SELECT t.ID as ID,t.Name as Name FROM Teacher t " +
                "inner join TeacherAndSubjectTable tt on t.ID=tt.TeacherID " +
                "where tt.Experience=(select max(tt.Experience) from " +
                "TeacherAndSubjectTable tt where tt.SubjectID='" + selectedSubject.Id + "' and tt.ClassRoom = '"+selectedClass.Name+"')";
            var getTeacher = conn.Query<Teacher>(qry).FirstOrDefault();
            if (getTeacher!=null)
            {
                tName = getTeacher.Name.ToString();
                tID = getTeacher.ID;
                txtTeacherName.Text = tName;
            }
            else
            {
                DisplayAlert("Message", "No Teacher for this Subject", "OK");
            }
        }
        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Do you want to delete Allotment?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                Allotment details = menu.CommandParameter as Allotment;
                DependencyService.Get<SQLiteInterface>().DeleteAllotment(details.ID);
                getAllotmentDAata();
            }
        }
        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewcell = (ViewCell)sender;
            if (viewcell != null)
            {
                viewcell.View.BackgroundColor = Color.LightGray;
                lastCell = viewcell;
            }
        }

        private void classPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Class = (Classrooms)ClassPicker.SelectedItem;
            var getSubject = conn.Query<Subjects>("SELECT Id,Name,CourseType FROM Subjects where ClassRoom = '" + Class.Name + "'");
            SubjectPicker.ItemsSource = getSubject;
        }
       void Clear()
        {
            DepartmentPicker.SelectedItem = "";
            ClassPicker.SelectedItem = "";
            SubjectPicker.SelectedItem = "";
            txtTeacherName.Text = "";
            dayPicker.SelectedItem = "";
            timePicker.SelectedItem = "";

        }

    }
}
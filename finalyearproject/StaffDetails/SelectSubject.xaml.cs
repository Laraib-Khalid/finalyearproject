using finalyearproject.AdminDetails;
using finalyearproject.AdminDetails.Allotment;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.StaffDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectSubject : ContentPage
    {
        public SQLiteConnection conn;
        public SelectSubject()
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteInterface>().GetConnectionwithCreateDatabase();
            setSubject();
            setName();
            Display();
        }

        private void setName()
        {
            var getName = conn.Query<Teacher>("SELECT Id,Name,Experience FROM Teacher");
            NamePicker.ItemsSource = getName;
        }
        private void setSubject()
        {
            var getSubject = conn.Query<Subjects>("SELECT Id,Name FROM Subjects");
            SubjectPicker.ItemsSource = getSubject;
        }
        private void addbtn_Clicked(object sender, EventArgs e)
        {
            TeacherAndSubjectTable tesub = new TeacherAndSubjectTable();
            var SelectedSubject = (Subjects)SubjectPicker.SelectedItem;
            tesub.SubjectID = SelectedSubject.Id;
            var SelectedName = (Teacher)NamePicker.SelectedItem;
            tesub.TeacherID = SelectedName.Id;
            tesub.Experience = Convert.ToInt32(txtExperience.Text);
            bool res = DependencyService.Get<SQLiteInterface>().TeacherPreferences(tesub);
            if (res)
            {
                var message = "Data saved Successfully.";
                DependencyService.Get<SQLiteInterface>().Shorttime(message);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Message", "Data Failed To Save", "OK");
            }
        }

        private void Display()
        {
            var Display = conn.Query<TeacherAndSubjectTable>("SELECT t.Name as TeacherName,s.Name as SubjectName,tt.Experience as Experience from TeacherandSubjectTable tt inner join Teacher t on tt.TeacherID=t.Id inner join Subjects s on tt.SubjectID=s.Id");
            listView.ItemsSource = Display;
        }
    }
}
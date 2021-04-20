using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.StaffDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timetable : ContentPage
    {
        public SQLiteConnection conn;
        public static int teacherId=0;
        public Timetable()
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteInterface>().GetConnectionwithCreateDatabase();
            TeacherActionAsync();
        }
        private void TeacherActionAsync()
        {
            
                var slist =  DependencyService.Get<SQLiteInterface>().GetTeacherAllotments(teacherId);
                list.ItemsSource = null;
               list.ItemsSource = slist;
            
            
        }
    }
}
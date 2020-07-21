using finalyearproject.AdminDetails.Allotment;
using finalyearproject.AdminDetails.Classroom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace finalyearproject.AdminDetails
{

    public class AdminMainPageCSMasterMenuItem : INotifyPropertyChanged
    {
        public AdminMainPageCSMasterMenuItem()
            {
            TargetType = typeof(AdminMainPageCSMasterMenuItem);
            }
            public Type TargetType { get; set; }
            public string Title { get; set; }
            public Color TextColor { get; set; } = Color.Black;
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged()
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            }
    }
}


    

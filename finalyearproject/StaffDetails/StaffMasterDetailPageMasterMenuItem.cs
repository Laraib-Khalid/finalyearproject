using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace finalyearproject.StaffDetails
{

    public class StaffMasterDetailPageMasterMenuItem : INotifyPropertyChanged
    {
        public StaffMasterDetailPageMasterMenuItem()
        {
            TargetType = typeof(StaffMasterDetailPageMasterMenuItem);
        }
        public string Title { get; set; }
        public Color TextColor { get; set; } = Color.Black;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }
        public Type TargetType { get; set; }
    }
}
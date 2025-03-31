using System.Windows.Controls;
using MyProductivityApp.ViewModel;
using System.Linq;
using MyProductivityApp.Services;

namespace MyProductivityApp.View
{
    public partial class CalendarView : UserControl
    {
        public CalendarView()
        {
            InitializeComponent();
            this.DataContext = new CalendarViewModel();
        }
    }
}

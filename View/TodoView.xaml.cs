using System.Windows.Controls;
using MyProductivityApp.ViewModel;

namespace MyProductivityApp.View
{
    public partial class TodoView : UserControl
    {
        public TodoView()
        {
            InitializeComponent();
            this.DataContext = new TodoViewModel();
        }
    }
}

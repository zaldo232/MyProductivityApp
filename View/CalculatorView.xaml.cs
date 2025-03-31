using System.Windows.Controls;
using System.Windows.Input;
using MyProductivityApp.ViewModel;

namespace MyProductivityApp.View
{
    public partial class CalculatorView : UserControl
    {
        public CalculatorView()
        {
            InitializeComponent();
            this.DataContext = new CalculatorViewModel();
        }

        private void HistoryListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem is string history)
            {
                // "식 = 결과" → 식 부분만 추출
                var expression = history.Split('=')[0].Trim();
                ((CalculatorViewModel)this.DataContext).Input = expression;
            }
        }

    }

}

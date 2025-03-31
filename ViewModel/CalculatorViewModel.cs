using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MyProductivityApp.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string input = "";

        public string Input
        {
            get => input;
            set
            {
                input = value;
                OnPropertyChanged();
            }
        }

        public ICommand AppendCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand CalculateCommand { get; }
        public ObservableCollection<string> History { get; set; } = new();

        public CalculatorViewModel()
        {
            AppendCommand = new RelayCommand<string>(Append);
            ClearCommand = new RelayCommand(Clear);
            CalculateCommand = new RelayCommand(Calculate);
        }

        private void Append(string value)
        {
            Input += value;
        }

        private void Clear()
        {
            Input = "";
        }

        private void Calculate()
        {
            try
            {
                var result = new System.Data.DataTable().Compute(Input, null);
                History.Insert(0, $"{Input} = {result}"); // 최신 항목 위에
                Input = result.ToString();
            }
            catch
            {
                Input = "오류";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

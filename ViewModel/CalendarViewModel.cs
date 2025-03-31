using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyProductivityApp.Model;
using MyProductivityApp.Services;

namespace MyProductivityApp.ViewModel
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private DateTime selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => selectedDate;
            set
            {
                selectedDate = value;
                OnPropertyChanged();
                FilterSchedules();
            }
        }
        
        public ObservableCollection<ScheduleItem> AllSchedules { get; set; } = new();
        public ObservableCollection<ScheduleItem> FilteredSchedules { get; set; } = new();

        private string newScheduleTitle;
        public string NewScheduleTitle
        {
            get => newScheduleTitle;
            set
            {
                newScheduleTitle = value;
                OnPropertyChanged();
                (AddCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }

        public CalendarViewModel()
        {
            AddCommand = new RelayCommand(AddSchedule, () => !string.IsNullOrWhiteSpace(NewScheduleTitle));
            RemoveCommand = new RelayCommand<ScheduleItem>(RemoveSchedule);

            var loaded = ScheduleStorageService.Load();
            AllSchedules = new ObservableCollection<ScheduleItem>(loaded);
            FilterSchedules();

            // 변경 감지
            AllSchedules.CollectionChanged += (s, e) => SaveSchedules();
        }

        private void AddSchedule()
        {
            var item = new ScheduleItem { Date = SelectedDate, Title = NewScheduleTitle };
            AllSchedules.Add(item);
            NewScheduleTitle = string.Empty;
            FilterSchedules();
        }

        private void RemoveSchedule(ScheduleItem item)
        {
            if (item != null)
            {
                AllSchedules.Remove(item);
                FilterSchedules();
            }
        }

        private void FilterSchedules()
        {
            FilteredSchedules.Clear();
            foreach (var item in AllSchedules)
            {
                if (item.Date.Date == SelectedDate.Date)
                    FilteredSchedules.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void SaveSchedules()
        {
            ScheduleStorageService.Save(AllSchedules.ToList());
        }
    }
}

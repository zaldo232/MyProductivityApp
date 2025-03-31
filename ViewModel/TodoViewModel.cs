using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyProductivityApp.Model;
using MyProductivityApp.Services;
using System.Linq;

namespace MyProductivityApp.ViewModel
{
    public class TodoViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<TodoItem> todos;
        public ObservableCollection<TodoItem> Todos
        {
            get => todos;
            set
            {
                todos = value;
                OnPropertyChanged();
                SubscribeToCollection();
            }
        }

        private string newTodoText;
        public string NewTodoText
        {
            get => newTodoText;
            set
            {
                newTodoText = value;
                OnPropertyChanged();

                (AddCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }

        public TodoViewModel()
        {
            //시작 시 저장된 To-Do 불러오기
            var loaded = TodoStorageService.Load();
            Todos = new ObservableCollection<TodoItem>(loaded);

            AddCommand = new RelayCommand(AddTodo, () => !string.IsNullOrWhiteSpace(NewTodoText));
            RemoveCommand = new RelayCommand<TodoItem>(RemoveTodo);

            SubscribeToCollection();
        }

        private void AddTodo()
        {
            Todos.Add(new TodoItem { Title = NewTodoText, IsCompleted = false });
            NewTodoText = string.Empty;
        }
        

        private void RemoveTodo(TodoItem item)
        {
            if (item != null)
                Todos.Remove(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void SubscribeToCollection()
        {
            Todos.CollectionChanged += (s, e) => SaveTodos();
        }

        private void SaveTodos()
        {
            TodoStorageService.Save(Todos.ToList());
        }

    }
}

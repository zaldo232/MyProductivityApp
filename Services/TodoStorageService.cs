using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MyProductivityApp.Model;

namespace MyProductivityApp.Services
{
    public static class TodoStorageService
    {
        private static readonly string filePath = "todos.json";

        public static void Save(List<TodoItem> todos)
        {
            var json = JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static List<TodoItem> Load()
        {
            if (!File.Exists(filePath))
                return new List<TodoItem>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
        }
    }
}

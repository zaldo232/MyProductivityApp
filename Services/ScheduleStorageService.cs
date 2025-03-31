using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MyProductivityApp.Model;

namespace MyProductivityApp.Services
{
    public static class ScheduleStorageService
    {
        private static readonly string filePath = "schedules.json";

        public static void Save(List<ScheduleItem> schedules)
        {
            var json = JsonSerializer.Serialize(schedules, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static List<ScheduleItem> Load()
        {
            if (!File.Exists(filePath))
                return new List<ScheduleItem>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<ScheduleItem>>(json) ?? new List<ScheduleItem>();
        }
    }
}

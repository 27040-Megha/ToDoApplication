using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ToDoApplication.Repository
{
    public static class FileRepoService
    {
        public static List<T> ReadFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            string existingJson = File.ReadAllText(filePath);
            var list = JsonSerializer.Deserialize<List<T>>(existingJson) ?? new List<T>();
            return list;
        }

        public static void WriteFile<T>(List<T> listToWrite, string filePath)
        {
            string jsonTextToWrite = JsonSerializer.Serialize(listToWrite);
            File.WriteAllText(filePath, jsonTextToWrite);
        }
    }
}

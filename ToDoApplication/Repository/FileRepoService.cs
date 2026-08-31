using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ToDoApplication.Repository
{
    /// <summary>
    /// Helper class to read and write files
    /// </summary>
    public static class FileRepoService
    {
        /// <summary>
        /// Read from file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns>List of objects</returns>
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

        /// <summary>
        /// Write To File
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listToWrite"></param>
        /// <param name="filePath"></param>
        public static void WriteFile<T>(List<T> listToWrite, string filePath)
        {
            string jsonTextToWrite = JsonSerializer.Serialize(listToWrite);
            File.WriteAllText(filePath, jsonTextToWrite);
        }
    }
}

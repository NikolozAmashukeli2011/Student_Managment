using Student_Managment.Models;
using System.Text.Json;

namespace Student_Managment.Services
{
    static class StudentStorage
    {
        private static readonly string FilePath = "students.json";
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };

        public static void Save(StudentStorageData data)
        {
            string json = JsonSerializer.Serialize(data, options);

            try
            {
                using (var sw = new StreamWriter(FilePath))
                {
                    sw.Write(json);
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine($"Couldn't save. {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"You don't have permission to modify the file. {ex.Message}");
            }

        }

        public static StudentStorageData Load()
        {

            if (!File.Exists(FilePath)) return new StudentStorageData();

            try
            {
                using (var sw = new StreamReader(FilePath))
                {
                    string json = sw.ReadToEnd();
                    return JsonSerializer.Deserialize<StudentStorageData>(json, options) ?? new StudentStorageData();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Couldn't load. {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"You don't have permission to interact with the file. {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"The text isn't valid JSON. {ex.Message}");
            }

            return new StudentStorageData();
        }
    }
}

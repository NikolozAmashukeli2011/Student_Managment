using Student_Managment.Services;

namespace Student_Managment.Models
{
    static class StudentManager
    {
        public static List<Student> studentsList = new List<Student>();
        public static SortedList<char, List<Student>> BestGradeToStudentsMap = new SortedList<char, List<Student>>();
        public static Dictionary<int, List<Student>> RollToStudentsMap = new Dictionary<int, List<Student>>();
        public static Dictionary<int, Student> IdToStudentMap = new Dictionary<int, Student>();

        static StudentManager()
        {
            foreach (Student s in StudentStorage.Load())
            {
                AddToCollections(s);
            }
        }

        private static void AddToCollections(Student s)
        {
            if (!BestGradeToStudentsMap.TryGetValue(s.Grade, out List<Student>? gradeStudents))
            {
                gradeStudents = new List<Student>();
                BestGradeToStudentsMap[s.Grade] = gradeStudents;
            }

            if (!RollToStudentsMap.TryGetValue(s.RollNum, out List<Student>? rollStudents))
            {
                rollStudents = new List<Student>();
                RollToStudentsMap[s.RollNum] = rollStudents;
            }

            gradeStudents.Add(s);
            rollStudents.Add(s);
            studentsList.Add(s);
            IdToStudentMap.Add(s.Id, s);
        }

        public static void DisplayAllStudents()
        {
            if (studentsList.Count == 0)
            {
                Console.WriteLine("\nThere are no students.\n");
            }
            else
            {
                Console.WriteLine("\n[STUDENTS]\n");

                foreach (Student student in studentsList)
                {
                    Console.WriteLine($"{student.ToString()}\n");
                }
            }
        }

        public static void DisplayStudentsByGrade()
        {
            Console.WriteLine("\n[STUDENTS BY GRADE]\n");

            foreach ((char grade, List<Student> students) in BestGradeToStudentsMap)
            {
                foreach (Student student in students)
                {
                    Console.WriteLine($"Grade: [{grade}], Student: {student.ToString()}\n");
                }
            }
        }

        public static bool FindStudentsByRollNum(int rollNum, out List<Student>? foundStudents)
        {
            bool rollFound = RollToStudentsMap.TryGetValue(rollNum, out List<Student>? foundList);
            foundStudents = null;

            if (rollFound)
            {
                if (foundList?.Count == 0)
                {
                    return false;
                }
                else
                {
                    foundStudents = foundList;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool FindStudentById(int id, out Student? foundStudent)
        {
            return IdToStudentMap.TryGetValue(id, out foundStudent);
        }

        private static bool StudentExists(Student student)
        {
            if (IdToStudentMap.ContainsKey(student.Id)) return true;

            return false;
        }

        public static bool AddStudent(Student student)
        {
            if (StudentExists(student))
            {
                return false;
            }
            else
            {
                AddToCollections(student);
                StudentStorage.Save(studentsList);
                return true;
            }
        }

        public static bool RemoveStudent(Student student)
        {
            if (StudentExists(student))
            {
                BestGradeToStudentsMap.TryGetValue(student.Grade, out List<Student> students);
                students.Remove(student);
                studentsList.Remove(student);
                IdToStudentMap.Remove(student.Id);
                RollToStudentsMap[student.RollNum].Remove(student);

                StudentStorage.Save(studentsList);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

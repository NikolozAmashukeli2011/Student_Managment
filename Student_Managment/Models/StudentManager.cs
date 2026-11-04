using Student_Managment.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
            studentsList.Add(s);

            if (!BestGradeToStudentsMap.TryGetValue(s.Grade, out List<Student>? gradeStudents))
            {
                gradeStudents = new List<Student>();
                BestGradeToStudentsMap[s.Grade] = gradeStudents;
            }

            gradeStudents.Add(s);

            if (!RollToStudentsMap.TryGetValue(s.RollNum, out List<Student>? rollStudents))
            {
                rollStudents = new List<Student>();
                RollToStudentsMap[s.RollNum] = gradeStudents;
            }

            IdToStudentMap.Add(s.Id, s);
        }

        public static void DisplayAllStudents()
        {
            Console.WriteLine("\n[STUDENTS]\n");

            foreach (Student student in studentsList)
            {
                Console.WriteLine($"{student.ToString()}\n");
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
                bool gradeListExists = BestGradeToStudentsMap.TryGetValue(student.Grade, out List<Student>? gradeStudents);
                bool rollListExists = RollToStudentsMap.TryGetValue(student.RollNum, out List<Student>? rollStudents);

                if (!gradeListExists)
                {
                    List<Student> newGradeList = new List<Student>();
                    BestGradeToStudentsMap.Add(student.Grade, newGradeList);
                    gradeStudents = newGradeList;
                }

                if (!rollListExists)
                {
                    List<Student> newRollList = new List<Student>();
                    RollToStudentsMap.Add(student.RollNum, newRollList);
                    rollStudents = newRollList;
                }

                StudentStorage.Save(studentsList);

                gradeStudents?.Add(student);
                studentsList.Add(student);
                IdToStudentMap[student.Id] = student;
                rollStudents?.Add(student);
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

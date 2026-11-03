using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Managment.Models
{
    static class StudentManager
    {
        public static HashSet<Student> StudentsSet = new HashSet<Student>();
        public static SortedList<char, List<Student>> BestGradeToStudentsMap = new SortedList<char, List<Student>>(Comparer<char>.Create((x, y) => y.CompareTo(x)));
        public static Dictionary<int, Student> RollToStudentMap = new Dictionary<int, Student>();
        public static Dictionary<int, Student> IdToStudentMap = new Dictionary<int, Student>();

        public static void DisplayAllStudents()
        {
            Console.WriteLine("\n[STUDENTS]\n");

            foreach (Student student in StudentsSet)
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

        public static bool FindStudentByRollNum(int rollNum, out Student? foundStudent)
        {
            return RollToStudentMap.TryGetValue(rollNum, out foundStudent);
        }

        public static bool FindStudentById(int id, out Student? foundStudent)
        {
            return IdToStudentMap.TryGetValue(id, out foundStudent);
        }
       
        private static bool CanAddStudent(Student student)
        {
            //KeyValuePair<char, List<Student>> GradeToStudentKVP = new KeyValuePair<char, List<Student>>();
            //BestGradeToStudentsMap.TryGetValue(student.Grade, out List<Student> students);
            //bool gradeToStudentsContains = students.Contains(student);
            if (StudentsSet.Contains(student)) return false;
            if (IdToStudentMap.ContainsKey(student.Id)) return false;
            if (RollToStudentMap.ContainsKey(student.RollNum)) return false;
            return true;

            //if (setContains || idToStudentContains || rollToStudentContains)
            //{
            //    return false;
            //} else
            //{
            //    return true;
            //}

        } 

        public static bool AddStudent(Student student)
        {
            if (CanAddStudent(student))
            {
                StudentsSet.Add(student);
                IdToStudentMap[student.Id] = student;
                RollToStudentMap[student.RollNum] = student;
                return true;
            } else
            {
                return false;
            }
        }

        public static bool RemoveStudent(Student student)
        {
            if(CanAddStudent(student))
            {
                return false;
            } else {
                StudentsSet.Remove(student);
                IdToStudentMap.Remove(student.Id);
                RollToStudentMap.Remove(student.RollNum);
                return true;
            }
        }
    }
}

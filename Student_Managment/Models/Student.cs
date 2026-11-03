using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Managment.Models
{
    internal class Student
    {
        public static readonly HashSet<char> grades = new HashSet<char>() {'A', 'B', 'C', 'D', 'F'};
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RollNum { get; set; }
        private int count = 0;
        private char _grade;
        public char Grade 
        {
            get
            {
                return _grade;
            }

            set
            {
                if (IsValidGrade(value))
                {
                    _grade = value;
                } else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "argument isn't a grade.");
                }
            }

        }
        public static bool IsValidGrade(char grade)
        {
            if (grades.Contains(grade)) return true; return false;
        }

        public Student(string name, int rollNum, char grade)
        {
            count++;
            Id = count;
            Name = name;
            RollNum = rollNum;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Roll Number: {RollNum}, Grade: {Grade}.";
        }
    }
}

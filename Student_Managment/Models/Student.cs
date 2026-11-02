using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Managment.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RollNum { get; set; }
        public char Grade { get; private set; }

        private int count = 0;

        public Student(string name, int rollNum, char grade)
        {
            count++;
            Id = count;
            Name = name;
            RollNum = rollNum;
            Grade = grade;
        }

        public bool ModifyGrade(char grade)
        {
            if(char.IsAsciiLetter(grade))
            {
                Grade = grade;
                return true;
            } else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Roll Number: {RollNum}, Grade: {Grade}.";
        }
    }
}

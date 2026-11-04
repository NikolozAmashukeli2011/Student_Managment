using Student_Managment.Helpers;
using Student_Managment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Managment.Services
{
    static class MenuActions
    {
        private static int GetIdInput()
        {
            return Prompter.PromptGeneric<int>("Input student's id: ", "Input must be an integer, try again: ");
        }
        private static string GetNameInput()
        {
            return Prompter.PromptString("Input student's name: ", "Input must be a text, try again: ", "Student's name can't be empty, Try again: ").Trim();
        }

        private static int GetRollNumInput()
        {
           return Prompter.PromptGeneric<int>("Input student's roll number: ", "Input must be an integer, try again: ");
        }

        private static char GetGradeInput()
        {
            char grade = char.ToUpper(Prompter.PromptGeneric<char>("Input student's grade: ", "input must be a letter, try again: "));

            while (!Student.IsValidGrade(grade))
            {
                grade = Prompter.PromptGeneric<char>("Input must be a valid grade (A-F, excluding E), try again: ", "Input must be a letter, try again: ");
            }

            return grade;
        }
        private static Student CreateStudent()
        {
            string name = GetNameInput();
            int rollNum = GetRollNumInput();
            char grade = GetGradeInput();

            return new Student(name, rollNum, grade);
        }

        public static void AddStudentAction()
        {
            Student studentToAdd = CreateStudent();

            bool success = StudentManager.AddStudent(studentToAdd);

            if(success)
            {
                Console.WriteLine("Student added successfully!\n");
                Console.WriteLine($"{studentToAdd.ToString()}\n");

            } else
            {
                Console.WriteLine("adding the Student failed!\n");
            }

        }
        public static void RemoveStudentByIdAction()
        {
            int id = GetIdInput();

            bool foundSuccessfully = StudentManager.FindStudentById(id, out Student? student);

            if (foundSuccessfully)
            {
                StudentManager.RemoveStudent(student);
                Console.WriteLine("Student removed successfully!\n");
                Console.WriteLine($"{student.ToString()}\n");
            }
            else
            {
                Console.WriteLine($"Student with id: {id} couldn't be found.");
            }
        }

        public static void FindStudentsByRollNum()
        {
            int rollNum = GetRollNumInput();

           bool success = StudentManager.FindStudentsByRollNum(rollNum, out List<Student>? students);

            if(success)
            {
                {
                    Console.WriteLine("Students found successfully!\n");

                    foreach(Student student in students)
                    {
                        Console.WriteLine($"{student.ToString()}\n");
                    }
                }
              
            } else
            {
                Console.WriteLine($"Students in roll number: {rollNum} couldn't be found/is empty.");
            }
        }
        public static void FindStudentByIdAction()
        {
            int id = GetIdInput();

            bool foundSuccessfully = StudentManager.FindStudentById(id, out Student? student);

            if (foundSuccessfully)
            {
                Console.WriteLine("Student found successfully!\n");
                Console.WriteLine($"{student.ToString()}\n");
            }
            else
            {
                Console.WriteLine($"Student with id: {id} couldn't be found.");
            }
        }

    }
}

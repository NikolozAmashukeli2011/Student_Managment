using Student_Managment.Helpers;
using Student_Managment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Managment
{
    static class MenuActions
    {
        public static Student CreateStudent()
        {
            string name = Prompter.PromptString("Input student's name: ", "Input must be a text, try again: ", "Student's name can't be empty, Try again: ");
            int rollNum = Prompter.PromptGeneric<int>("Input student's roll number: ", "Input must be an integer, try again: ");
            char grade = Prompter.PromptGeneric<char>("Input student's grade: ", "input must be a letter, try again: ");

            Student newStudent = new Student(name, rollNum, grade);
            return newStudent;
        }

        public static void AddStudent()
        {
            Student studentToAdd = CreateStudent();

            bool success = StudentManager.AddStudent(studentToAdd);

            if(success)
            {
                Console.WriteLine("Student added successfully!\n");
                Console.WriteLine($"{studentToAdd.ToString()}\n");
            } else
            {

            }
        }
    }
}

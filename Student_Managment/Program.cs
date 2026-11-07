using Student_Managment.Helpers;
using Student_Managment.Models;
using Student_Managment.Services;

int choice;

do
{
    Console.WriteLine(
        "\n1. Add a student.\n" +
        "2. Display students.\n" +
        "3. Display students by grade.\n" +
        "4. Find students by roll number.\n" +
        "5. Find student by id.\n" +
        "6. Remove a student By Id.\n" +
        "7. Remove all students.\n" +
        "8. Exit.\n");

    string intErrTxt = "Input must be an integer, Try again: ";

    choice = Prompter.PromptGeneric<int>("Input an integer (1-8): ", intErrTxt);

    while(choice < 1 || choice > 8)
    {
        choice = Prompter.PromptGeneric<int>("Input must be an integer (1-8), try again: ", intErrTxt);
    }

    switch(choice)
    {
        case 1: MenuActions.AddStudentAction(); break;
        case 2: StudentManager.DisplayAllStudents(); break;
        case 3: StudentManager.DisplayStudentsByGrade(); break;
        case 4: MenuActions.FindStudentsByRollNum(); break;
        case 5: MenuActions.FindStudentByIdAction(); break;
        case 6: MenuActions.RemoveStudentByIdAction(); break;
        case 7: MenuActions.RemoveAllStudents(); break;
        case 8: break;
    }

} while (choice != 8);
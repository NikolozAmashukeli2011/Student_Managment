using Student_Managment;
using Student_Managment.Helpers;
using Student_Managment.Models;

int choice;

do
{
    Console.WriteLine(
        "\n1. Add a student.\n" +
        "2. Remove a student By Id.\n" +
        "3. Find students by roll number.\n" +
        "4. Find student by id.\n" +
        "5. Display students.\n" +
        "6. Display students by grade.\n" +
        "7. Exit\n");

    string intErrTxt = "Input must be an integer, Try again: ";

    choice = Prompter.PromptGeneric<int>("Input an integer (1-7): ", intErrTxt);

    while(choice < 1 || choice > 7)
    {
        choice = Prompter.PromptGeneric<int>("Input must be an integer (1-7), try again: ", intErrTxt);
    }

    switch(choice)
    {
        case 1: MenuActions.AddStudentAction(); break;
        case 2: MenuActions.RemoveStudentByIdAction(); break;
        case 3: MenuActions.FindStudentsByRollNum(); break;
        case 4: MenuActions.FindStudentByIdAction(); break;
        case 5: StudentManager.DisplayAllStudents(); break;
        case 6: StudentManager.DisplayStudentsByGrade(); break;
        case 7: break;
    }

} while (choice != 7);
using Student_Managment.Helpers;

int choice;

do
{
    Console.WriteLine(
        "\n1. Add a student.\n" +
        "2. Remove a student By Id.\n" +
        "3. Find student by roll number.\n" +
        "4. Find student by id.\n" +
        "5. Display students.\n" +
        "6. Exit.\n");

    string intErrTxt = "Input must be an integer, Try again: ";

    choice = Prompter.PromptGeneric<int>("Input an integer (1-6): ", intErrTxt);

    while(choice < 1 || choice > 6)
    {
        choice = Prompter.PromptGeneric<int>("Input must be an integer (1-6), try again: ", intErrTxt);
    }

    switch(choice)
    {
        case 1: break;
        case 2: break;
        case 3: break;
        case 4: break;
        case 5: break;
        case 6: break;
    }

} while (choice != 6);
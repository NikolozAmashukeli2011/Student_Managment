using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Student_Managment.Helpers
{
    static class Prompter
    {
        public static T PromptGeneric<T>(string startingTxt, string errTxt) where T: IParsable<T>
        {
            T result;
            
            Console.WriteLine(startingTxt);
            string input = Console.ReadLine();

            while(T.TryParse(input, CultureInfo.InvariantCulture, out result))
            {
                Console.WriteLine(errTxt);
                input = Console.ReadLine();
            }

            return result;
        }
    }
}

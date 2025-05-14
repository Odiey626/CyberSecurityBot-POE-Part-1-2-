using System;


class UserInteraction
{
    public static string GetValidUserInput()
    {
        string userInput = "";

        while (true)
        {
            //Removing spaces around user input

            userInput = Console.ReadLine().Trim(); 

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("You didn't enter anything. Please type a question or type 'exit' to end:");
            }
            else
            {
                return userInput;
            }
        }
    }
}

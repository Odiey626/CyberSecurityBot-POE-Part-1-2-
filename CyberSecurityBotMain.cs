using System;
using System.Media;
using System.Collections;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using Imagelogo;


internal class CyberSecurityBot
{
    static void Main(string[] args)
    {
        //Calling Welcoming audio method
        AudioPlayer.PlayWelcomeAudio();

        //Display Image method
        Program.LogoImage();
        
        StartChat();
    }

    static void StartChat()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Hello! What's your name? ");
        Console.ResetColor();
        string name = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Welcome, {name}! I can help you learn about cybersecurity. Ask me anything!");
        Console.ResetColor();

        string userInput;
        bool foundTopic;

        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("User: ");
            Console.ResetColor();

            // Removing case sensitivity
            userInput = UserInteraction.GetValidUserInput().ToLower().Trim();

            // Checking if the user wants to exit before processing anything else
            if (userInput.Contains("exit") || userInput.Contains("bye") || userInput.Contains("later") || userInput.Contains("goodbye"))
            {
                Console.WriteLine("Chatbot: Goodbye! Have a great day!");
                break;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Chatbot: ");
            Console.ResetColor();

            string response = ChatbotResponse.GetResponse(userInput, out foundTopic);

            if (foundTopic)
            {
                // Only display valid responses
                Console.WriteLine(response);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("I didn't understand that. Try asking about passwords, phishing, malware, social engineering, or safe browsing.");
                Console.ResetColor();
            }
        } while (!userInput.Contains("exit") && !userInput.Contains("bye") && !userInput.Contains("later") && !userInput.Contains("goodbye"));
    }
}


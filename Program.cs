using System;
using System.Media;
using System.Collections;

class CyberSecurityBot
{
    static void Main()
    {
        Console.Title = "Cybersecurity Awareness Bot";
        PlayVoiceGreeting();
        DisplayAsciiArt();
        StartChat();
    }

    static void PlayVoiceGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\RC_Student_lab\\Documents\\Cyber Security chat bot welcome.wav");
            player.PlaySync();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error playing audio: " + ex.Message);
            Console.ResetColor();
        }
    }

    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
                    /* ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌ */
                    /* ▐  _____       __               ____                      _  __        ▌ */
                    /* ▐ / ___/__ __ / /  ___  ____   / __/___  ____ __ __ ____ (_)/ /_ __ __ ▌ */
                    /* ▐/ /__ / // // _ \/ =_)/ __/  _\ \ / -_)/ __// // // __// // __// // / ▌ */
                    /* ▐\___/ \_, //_.__/\__/\_/    /___/ \__/ \__/ \_,_//_/  /_/ \__/ \_, /  ▌ */
                    /* ▐   __/___/                                              ___   /___/__ ▌ */
                    /* ▐  / _ | _    __ ___ _ ____ ___  ___  ___  ___  ___     / _ ) ___  / /_▌ */
                    /* ▐ / __ || |/|/ // = `// __// -_)/ _ \/ -_)(_-< (_-<    / =  |/ = \/ __/▌ */
                    /* ▐/_/ |_||__,__/ \_,_//_/   \__//_//_/\__//___//___/   /____/ \___/\__/ ▌ */
                    /* ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌ */
        ");
        Console.ResetColor();
    }

    static void StartChat()
    {
        Console.Write("Hello! What's your name? ");
        string name = Console.ReadLine();
        Console.WriteLine($"Welcome, {name}! I can help you learn about cybersecurity. Ask me anything!");

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("User: ");
            Console.ResetColor();

            string userInput = UserInteraction.GetValidUserInput().ToLower().Trim();

            // Check if the user wants to exit before processing anything else
            if (userInput == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Chatbot: Goodbye! Stay safe online.");
                Console.ResetColor();
                break;
            }

            bool foundTopic;  // Track if a valid topic is found

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Chatbot: ");
            Console.ResetColor();

            string response = ChatbotResponse.GetResponse(userInput, out foundTopic);

            if (foundTopic)
            {
                Console.WriteLine(response); // Only display valid responses
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("I didn't understand that. Try asking about passwords, phishing, malware, social engineering, or safe browsing.");
                Console.ResetColor();
            }
        }
    }
}




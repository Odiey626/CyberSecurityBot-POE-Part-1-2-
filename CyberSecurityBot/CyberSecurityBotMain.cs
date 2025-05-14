using System;
using System.Collections.Generic;
using System.IO;
using Imagelogo;

internal class CyberSecurityBot
{
    static void Main(string[] args)
    {
        // Play welcome audio
        AudioPlayer.PlayWelcomeAudio();

        // Show logo image
        Program.LogoImage();

        // Menu Box
        ShowMenu();

        // Starting chatbot
        StartChat();
    }

    static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(@"
                                      ╔════════════════════════════════════════════╗
                                      ║      **CYBERSECURITY CHATBOT MENU**        ║
                                      ╠════════════════════════════════════════════╣
                                      ║ ** Topics you can ask about:               ║
                                      ║    - Passwords                             ║
                                      ║    - Phishing                              ║
                                      ║    - Malware                               ║
                                      ║    - Privacy                               ║
                                      ║    - Social engineering                    ║
                                      ║    - Ransomware                            ║
                                      ║    - Safe browsing                         ║
                                      ║    - Two-factor authentication             ║
                                      ║                                            ║
                                      ║ ** Sentiment examples (try typing):        ║
                                      ║    - I'm worried                           ║
                                      ║    - I'm curious                           ║
                                      ║    - I'm frustrated                        ║
                                      ║                                            ║
                                      ║ XX To exit the chatbot, type:              ║
                                      ║    - exit                                  ║
                                      ║    - bye                                   ║
                                      ║    - later / goodbye                       ║
                                      ╚════════════════════════════════════════════╝

                          ");
        Console.ResetColor();
    }

    static void StartChat()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Hello! What's your name? ");
        Console.ResetColor();

        string name = Console.ReadLine();
        string memoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "username.txt");
        string topicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"last_topic_{name}.txt");
        string sentimentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"last_sentiment_{name}.txt");

        List<string> rememberedNames = new List<string>();
        if (File.Exists(memoryPath))
        {
            rememberedNames = new List<string>(File.ReadAllLines(memoryPath));
        }

        string lastTopic = "";
        string lastSentiment = "";

        if (rememberedNames.Contains(name))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome back, {name}!!");

            if (File.Exists(topicPath))
            {
                lastTopic = File.ReadAllText(topicPath);
            }

            if (File.Exists(sentimentPath))
            {
                lastSentiment = File.ReadAllText(sentimentPath);
            }

            if (!string.IsNullOrEmpty(lastSentiment) && !string.IsNullOrEmpty(lastTopic))
            {
                Console.WriteLine($"Last time you were {lastSentiment} about {lastTopic}.");
            }
            else if (!string.IsNullOrEmpty(lastTopic))
            {
                Console.WriteLine($"Last time we spoke about: {lastTopic}");
            }

            Console.WriteLine("Would you like to continue or ask something new?");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("User: ");
            Console.ResetColor();

            string continueResponse = Console.ReadLine()?.ToLower().Trim();

            if (continueResponse.Contains("something new") || continueResponse.Contains("new topic") || continueResponse.Contains("new"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sure! I'm ready to talk about something new. What would you like to learn?");
                Console.ResetColor();
            }
            else if (continueResponse.Contains("continue") || continueResponse.Contains("same topic") || continueResponse.Contains("keep going"))
            {
                if (!string.IsNullOrEmpty(lastTopic))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Great! Let's continue talking about {lastTopic}.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Hmm... I couldn't find what we were talking about last time. Let's start fresh.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Alright! You can type a question or a topic when you're ready.");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Nice to meet you, {name}! 👋");
            rememberedNames.Add(name);
            File.WriteAllLines(memoryPath, rememberedNames);
        }

        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("I can help you l" +
            "earn about cybersecurity. Ask me anything!");
        Console.ResetColor();

        string userInput;
        bool foundTopic;

        Dictionary<string, string> sentiments = new Dictionary<string, string>()
        {
            { "worried", "Chatbot: You seem worried. I’ll do my best to explain things clearly." },
            { "scared", "Chatbot: Don't worry. Cybersecurity can feel scary at first, but I'm here to help." },
            { "anxious", "Chatbot: Feeling anxious is okay. Let’s go step-by-step." },
            { "frustrated", "Chatbot: It looks like you're frustrated. Don’t worry—I’ll guide you." },
            { "angry", "Chatbot: I understand your frustration. Let's figure it out together." },
            { "curious", "Chatbot: You seem curious! Great attitude for learning cybersecurity!" },
            { "interested", "Chatbot: Being interested is the first step to becoming cyber smart!" }
        };

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("User: ");
            Console.ResetColor();

            userInput = UserInteraction.GetValidUserInput().ToLower().Trim();

            if (userInput.Contains("exit") || userInput.Contains("bye") || userInput.Contains("goodbye") || userInput.Contains("later"))
            {
                Console.WriteLine("Chatbot: Goodbye! Have a great day!");
                break;
            }

            // Detect sentiment
            bool sentimentFound = false;
            string matchedSentiment = "";
            foreach (var sentiment in sentiments)
            {
                if (userInput.Contains(sentiment.Key))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(sentiment.Value);
                    Console.ResetColor();
                    matchedSentiment = sentiment.Key;
                    sentimentFound = true;

                    // Save this sentiment
                    File.WriteAllText(sentimentPath, matchedSentiment);
                    break;
                }
            }

            // Chatbot response
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Chatbot: ");
            Console.ResetColor();

            string response = ChatbotResponse.GetResponse(userInput, out foundTopic);

            if (foundTopic)
            {
                Console.WriteLine(response);

                // Save topic
                File.WriteAllText(topicPath, userInput);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("I didn't understand that. Try asking about passwords, phishing, malware, or privacy.");
                Console.ResetColor();
            }
        }
    }
}

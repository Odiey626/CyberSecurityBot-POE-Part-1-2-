using System;
using System.Collections;

class ChatbotResponse
{
    private static ArrayList topics = new ArrayList()
    {
        "passwords",
        "phishing",
        "malware",
        "social engineering",
        "safe browsing"
    };

    public static string GetResponse(string input, out bool foundTopic)
    {
        foundTopic = false;  // Reset flag for each new input
        input = input.ToLower();

        // Dictionary for responses
        Hashtable responses = new Hashtable()
        {
            { "passwords", "Passwords should be at least 12 characters long and include numbers, symbols, and uppercase/lowercase letters." },
            { "phishing", "Phishing is a cyber attack where attackers trick you into giving personal information." },
            { "malware", "Malware is software designed to harm or exploit any device, network, or service." },
            { "social engineering", "Social engineering manipulates people into revealing confidential information." },
            { "safe browsing", "Safe browsing means avoiding suspicious websites and using a secure internet connection." }
        };

        // Check if input matches any topic in the ArrayList
        foreach (string topic in topics)
        {
            if (input.Contains(topic))
            {
                foundTopic = true;
                return responses[topic].ToString();
            }
        }

        return ""; // Return empty string if no valid response is found
    }
}

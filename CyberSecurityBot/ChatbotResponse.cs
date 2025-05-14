using System;
using System.Collections.Generic;

public static class ChatbotResponse
{
    private static readonly Dictionary<string, List<string>> topicResponses = new Dictionary<string, List<string>>()
    {
        {
            "password", new List<string>
            {
                "Use strong, unique passwords for each account.",
                "Avoid using personal information in your passwords.",
                "Consider using a password manager to keep track of your credentials."
            }
        },
        {
            "phishing", new List<string>
            {
                "Be careful of emails that ask for personal info.",
                "Check links in emails before clicking—scammers fake websites!",
                "Don't download attachments from unknown senders."
            }
        },
        {
            "privacy", new List<string>
            {
                "Adjust your social media privacy settings.",
                "Use encrypted messaging apps when possible.",
                "Be mindful of what you share online."
            }
        },
        {
            "malware", new List<string>
            {
                "Keep your antivirus software up to date.",
                "Avoid downloading software from untrusted websites.",
                "Regularly scan your devices for threats."
            }
        },
        {
            "social engineering", new List<string>
            {
                "Social engineering tricks people into giving up confidential info.",
                "Always double-check requests for sensitive information, even if they seem to come from someone you know.",
                "Be careful of calls or messages that try to rush you into making decisions."
            }
        },
        {
            "ransomware", new List<string>
            {
                "Ransomware locks your files and asks for money to unlock them.",
                "Avoid clicking on suspicious links and always back up your data.",
                "Keep your system and antivirus updated to reduce the risk of ransomware."
            }
        },
        {
            "safe browsing", new List<string>
            {
                "Only visit secure websites (https).",
                "Avoid downloading unknown files or clicking on ads from sketchy sites.",
                "Use browser extensions that block trackers and popups."
            }
        },
        {
            "two-factor authentication", new List<string>
            {
                "Two-factor authentication adds extra security by requiring a code or device.",
                "Even if someone gets your password, 2FA can stop them from accessing your account.",
                "Use apps like Google Authenticator or receive SMS codes for added safety."
            }
        }
    };

    private static readonly Random random = new Random();

    public static string GetResponse(string input, out bool foundTopic)
    {
        foreach (var topic in topicResponses)
        {
            if (input.Contains(topic.Key))
            {
                foundTopic = true;
                var responses = topic.Value;
                return responses[random.Next(responses.Count)];
            }
        }

        foundTopic = false;
        return "";
    }

    // New method for detecting sentiment
    public static string DetectSentiment(string userInput)
    {
        string[] worriedWords = { "worried", "scared", "anxious", "confused", "fear" };
        string[] curiousWords = { "curious", "wonder", "question", "how", "what", "why" };
        string[] frustratedWords = { "angry", "frustrated", "mad", "annoyed", "hate" };

        foreach (string word in worriedWords)
        {
            if (userInput.Contains(word))
                return "worried";
        }

        foreach (string word in curiousWords)
        {
            if (userInput.Contains(word))
                return "curious";
        }

        foreach (string word in frustratedWords)
        {
            if (userInput.Contains(word))
                return "frustrated";
        }

        return "neutral";
    }
}


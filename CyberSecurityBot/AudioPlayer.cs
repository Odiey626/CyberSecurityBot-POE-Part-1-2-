using System;
using System.IO;
using System.Media;
using System.Reflection;

class AudioPlayer
{
    public static void PlayWelcomeAudio()
    {
        try
        {
            string resourceName = "CyberSecurityBot.Cyber_Security_chat_bot_welcome.wav";

            using (Stream audioStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (audioStream == null)
                {
                    Console.WriteLine("Error: Audio file not found in embedded resources.");
                    return;
                }

                using (SoundPlayer player = new SoundPlayer(audioStream))
                {
                    player.PlaySync(); // Play synchronously
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing audio: " + ex.Message);
        }
    }
}

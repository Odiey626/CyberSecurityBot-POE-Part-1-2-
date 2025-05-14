using System;
using System.IO;
using System.Collections.Generic;

public static class UserMemory
{
    static string filePath;

    static UserMemory()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string newPath = basePath.Replace("bin\\Debug\\", "");
        filePath = Path.Combine(newPath, "username.txt");
    }

    public static string GetSavedName()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines.Length > 0 ? lines[0] : "";
        }
        else
        {
            using (File.Create(filePath)) { }
            return "";
        }
    }

    public static void SaveName(string name)
    {
        File.WriteAllText(filePath, name);
    }
}

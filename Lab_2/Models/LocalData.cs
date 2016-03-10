using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_2
{
    public class LocalData
    {
        public static readonly string BasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");

        public static List<string> Files = new List<string>();

        public static bool AddFile(string name)
        {
            if (Files.Contains(name))
            {
                return false;
            }

            Files.Add(name);

            File.Create(Path.Combine(BasePath, $"{name}.txt"));

            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Lab_2
{
    public class LocalData
    {
        public static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "DB");

        public static List<Notepad> Notepads;

        public static bool AddNotepad(string name)
        {
            if (Notepads.Any(notepad => notepad.Name == name))
            {
                return false;
            }

            Notepads.Add(new Notepad(name));

            UpdateNotepads();

            return true;
        }

        public static string GetContent(string name)
        {
            var notepad = Notepads.FirstOrDefault(item => item.Name == name);

            if (notepad == null)
            {
                return "Error!";
            }

            return notepad.Content ?? "";
        }

        public static bool UpdateContent(string name, string content)
        {
            var notepad = Notepads.FirstOrDefault(item => item.Name == name);

            if (notepad == null)
            {
                return false;
            }

            notepad.Content = content;

            UpdateNotepads();

            return true;
        }

        public static void LoadNotepads()
        {
            if (!File.Exists(FilePath))
            {
                Notepads = new List<Notepad>();

                return;
            }

            var text = File.ReadAllText(FilePath);

            Notepads = JsonConvert.DeserializeObject<List<Notepad>>(text);
        }

        public static void UpdateNotepads()
        {
            var data = JsonConvert.SerializeObject(Notepads);

            File.WriteAllText(FilePath, data);
        }
    }
}
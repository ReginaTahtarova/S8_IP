namespace Lab_2
{
    public class Notepad
    {
        public readonly string Name;
        public string Content { get; set; }

        public Notepad(string name)
        {
            Name = name;
        }
    }
}
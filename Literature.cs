namespace Library1
{
    internal class Literature
    {

        public Literature() { }       

        public Literature(string type, string title, string author, int year, string frequency)
        {
            Type = type;
            Title = title;
            Author = author;
            Year = year;
            Frequency = frequency;
        }

        public string Type { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }        
        public string Frequency { get; set; }
    }
}
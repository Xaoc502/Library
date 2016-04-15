namespace Library1
{
    internal class Literature
    {           
        public Literature(string title, string author, int year, string frequency)
        {            
            Title = title;
            Author = author;
            Year = year;
            Frequency = frequency;
        }
               
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }        
        public string Frequency { get; set; }
    }
}
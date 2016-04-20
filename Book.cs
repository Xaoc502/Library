using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    class Book : Literature
    {
        public Book()
        {
        }

        public Book(string title, string author, int year)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;           
        }
    }
}

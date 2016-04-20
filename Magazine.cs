using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    class Magazine : Literature
    {
        public Magazine()
        {
        }

        public Magazine(string title, string author, int year, string frequency)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.Frequency = frequency;
        }
    }
}

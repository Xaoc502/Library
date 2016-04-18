using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    internal class NewsPaper : Literature
    {       
        public NewsPaper(string title, string author, string frequency, string edition, double price)
        {
            this.Title = title;
            this.Author = author;
            this.Frequency = frequency;
            this.Edition = edition;
            this.Price = price;
        }
    }
}

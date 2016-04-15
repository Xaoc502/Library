using System;
using System.Collections.Generic;

namespace Library1
{
    class Library
    {
        public List<Literature> list = new List<Literature>();

        public Library()
        {
          list = Dao.Load();
        }
        
    }
}
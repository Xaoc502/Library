using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Library1
{
    public static class Dao
    {
        internal static List<Literature> Load()
        {
            List<Literature> list = new List<Literature>();

            foreach (string line in File.ReadLines(@"D:\2.txt"))
            {
                string[] bookProperties = line.Split(' ');
                list.Add(new Book(bookProperties[0], bookProperties[1], Convert.ToInt32(bookProperties[2])));
            }
       
            return list;
        }

        internal static void Write(ListView listView1)
        {
            using (StreamWriter sw = new StreamWriter("D:\\2.txt"))
            {
                foreach (ListViewItem item in listView1.Items)
                {                    
                    sw.Write(item.Text + " ");
                    sw.Write(item.SubItems[1].Text + " ");
                    sw.Write(item.SubItems[2].Text + " ");
                    sw.WriteLine();
                    
                }
            }
        }
    }
}
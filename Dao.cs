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
                string[] bookProperties = line.Split('\t');            
                                
                list.Add(new Literature(bookProperties[0], bookProperties[1], bookProperties[2], Convert.ToInt32(bookProperties[3]), bookProperties[4]));
                                
            }
       
            return list;
        }

        internal static void Write(ListView listView1)
        {
            using (StreamWriter sw = new StreamWriter("D:\\2.txt"))
            {
                foreach (ListViewItem item in listView1.Items)
                {                    
                    sw.Write(item.Text + "\t");
                    sw.Write(item.SubItems[1].Text + "\t");
                    sw.Write(item.SubItems[2].Text + "\t");
                    sw.Write(item.SubItems[3].Text + "\t");
                    sw.Write(item.SubItems[4].Text + "\t");
                    sw.WriteLine();
                    
                }
            }
        }
    }
}
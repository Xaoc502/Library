using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Library1
{
    public static class Dao
    {
        internal static List<Literature> Load()
        {
            List<Literature> list = new List<Literature>();
            
            XmlTextReader reader = new XmlTextReader("library.xml");

            while (reader.Read())
            {
                if (reader.Name == "Book")
                {
                    list.Add(new Book(reader.GetAttribute("title"), reader.GetAttribute("author"), Convert.ToInt32(reader.GetAttribute("year")), reader.GetAttribute("frequency")));
                }
                else if(reader.Name == "Magazine")
                {
                    list.Add(new Magazine(reader.GetAttribute("title"), reader.GetAttribute("author"), Convert.ToInt32(reader.GetAttribute("year")), reader.GetAttribute("frequency")));
                }
            }
            reader.Close();
            return list;
        }

        internal static void Save(List<Literature> list)
        {
            XmlTextWriter writer = new XmlTextWriter("library.xml", Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("LiteratureList");

            foreach (var item in list)
            {
                
                if (item.Frequency == "")
                {
                    writer.WriteStartElement("Book");

                    writer.WriteAttributeString("title", item.Title);
                    writer.WriteAttributeString("author", item.Author);
                    writer.WriteAttributeString("year", Convert.ToString(item.Year));
                    writer.WriteAttributeString("frequency", item.Frequency);

                    writer.WriteEndElement();
                }

                else
                {
                    writer.WriteStartElement("Magazine");

                    writer.WriteAttributeString("title", item.Title);
                    writer.WriteAttributeString("author", item.Author);
                    writer.WriteAttributeString("year", Convert.ToString(item.Year));
                    writer.WriteAttributeString("frequency", item.Frequency);

                    writer.WriteEndElement();
                }
               
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        internal static List<Literature> Search(string text)
        {
            
            List<Literature> searchList = new List<Literature>(); 
            List<Literature> list = Load();
            foreach (var item in list)
            {
                if (item.Title == text)
                {
                    searchList.Add(item);
                }                
            }
            return searchList;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library1
{
    public partial class Form1 : Form
    {
        Library library = new Library();
       
        public Form1()
        {
            InitializeComponent();
            ShowList(library.list);
        }

        private void ShowList(List<Literature> list)
        {
           foreach (var literature in list)
            {
                ListViewItem newItem = new ListViewItem();                                                        
                
                if (literature.Frequency == "")
                {
                    newItem = new ListViewItem("Book");
                }
                else
                {
                    newItem = new ListViewItem("Magazine");
                }
                
                newItem.SubItems.Add(literature.Title);
                newItem.SubItems.Add(literature.Author);
                newItem.SubItems.Add(Convert.ToString(literature.Year));
                newItem.SubItems.Add(Convert.ToString(literature.Frequency));
                listView1.Items.Add(newItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            ListViewItem newItem = new ListViewItem(listBox1.SelectedItem.ToString());
            newItem.SubItems.Add(textBox1.Text);
            newItem.SubItems.Add(textBox2.Text);
            newItem.SubItems.Add(textBox3.Text);
            if (listBox1.SelectedItem.ToString() == "Book")
            {
                newItem.SubItems.Add("");
            }
            else
            {
                newItem.SubItems.Add(textBox4.Text);
            }
            
            listView1.Items.Add(newItem);
            if (listBox1.SelectedItem.ToString() == "Book")
            {
                library.list.Add(new Book(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), ""));
            }
            else if (listBox1.SelectedItem.ToString() == "Magazine")
            {
                library.list.Add(new Magazine(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), textBox4.Text));
            }
            Dao.Save(library.list);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //ListView.ListViewItemCollection toFindColection = listView1.Items;
            //for (int i = 0; i < toFindColection.Count; i++)
            //{
            //    string allReadyText = toFindColection[i].SubItems[1].Text;
            //    if (allReadyText == searchBox.Text)
            //    {
            //        listView1.Select();
            //        toFindColection[i].Selected = true;
            //        listView1.EnsureVisible(i);
            //        break;
            //    }
            //}

            listView1.Items.Clear();
            ShowList(Dao.Search(searchBox.Text));

        }
    }
}

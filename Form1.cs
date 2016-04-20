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
                
                if (literature.GetType() == typeof(Book))
                {
                    newItem = new ListViewItem("Book");
                    newItem.SubItems.Add(literature.Title);
                    newItem.SubItems.Add(literature.Author);
                    newItem.SubItems.Add(Convert.ToString(literature.Year));
                }
                else if (literature.GetType() == typeof(Magazine))
                {
                    newItem = new ListViewItem("Magazine");
                    newItem.SubItems.Add(literature.Title);
                    newItem.SubItems.Add(literature.Author);
                    newItem.SubItems.Add(Convert.ToString(literature.Year));
                    newItem.SubItems.Add(literature.Frequency);
                }
                else if (literature.GetType() == typeof(NewsPaper))
                {
                    newItem = new ListViewItem("NewsPaper");
                    newItem.SubItems.Add(literature.Title);
                    newItem.SubItems.Add(literature.Author);
                    newItem.SubItems.Add(Convert.ToString(literature.Year));
                    newItem.SubItems.Add(literature.Frequency);
                    newItem.SubItems.Add(literature.Edition);
                    newItem.SubItems.Add(Convert.ToString(literature.Price));
                }

                listView1.Items.Add(newItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            ListViewItem newItem = new ListViewItem(listBox1.SelectedItem.ToString());
            newItem.SubItems.Add(textBox1.Text);
            newItem.SubItems.Add(textBox2.Text);
            
            if (listBox1.SelectedItem.ToString() == "Book")
            {
                newItem.SubItems.Add(textBox3.Text);
              
            }
            else if (listBox1.SelectedItem.ToString() == "Magazine")
            {
                newItem.SubItems.Add(textBox3.Text);
                newItem.SubItems.Add(textBox4.Text);
            }

            else if (listBox1.SelectedItem.ToString() == "NewsPaper")
            {
                newItem.SubItems.Add("");
                newItem.SubItems.Add(textBox4.Text);
                newItem.SubItems.Add(textBox5.Text);
                newItem.SubItems.Add(textBox6.Text);
            }

            listView1.Items.Add(newItem);
            if (listBox1.SelectedItem.ToString() == "Book")
            {
                library.list.Add(new Book(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text)));
            }
            else if (listBox1.SelectedItem.ToString() == "Magazine")
            {
                library.list.Add(new Magazine(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), textBox4.Text));
            }
            else if (listBox1.SelectedItem.ToString() == "NewsPaper")
            {
                library.list.Add(new NewsPaper(textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text, Convert.ToDouble(textBox6.Text)));
            }

            Dao.Save(library.list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ShowList(library.list);
            foreach (ListViewItem item in listView1.Items)
            {
               
                if (listBox1.SelectedIndex == -1)
                {
                    if (item.SubItems[1].Text != searchBox.Text)
                    {
                        item.Remove();
                    }                    
                }

                else
                {
                    if (item.SubItems[1].Text != searchBox.Text || item.Text != listBox1.Text)
                    {
                        item.Remove();
                    }                    
                   
                }           
                              
            }

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ShowList(library.list);
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text != listBox1.Text)
                {
                    item.Remove();
                }
            }
        }
    }
}

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
            ShowList();
        }

        private void ShowList()
        {
           foreach (var literature in library.list)
            {
                ListViewItem newItem = new ListViewItem(literature.Type);
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
            Dao.Write(listView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

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
            foreach (var book in library.list)
            {
                ListViewItem newItem = new ListViewItem(book.Title);
                newItem.SubItems.Add(book.Author);
                newItem.SubItems.Add(Convert.ToString(book.BookYear));
                listView1.Items.Add(newItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem newItem = new ListViewItem(textBox1.Text);
            newItem.SubItems.Add(textBox2.Text);
            newItem.SubItems.Add(textBox3.Text);
            listView1.Items.Add(newItem);
            Dao.Write(listView1);
        }
        
    }
}

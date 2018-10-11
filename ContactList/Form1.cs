using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactList
{
    public partial class Form1 : Form
    {
        // Global
        private Contact[] phoneBook = new Contact[1];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            BubbleSort();
            Display();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Writing full contacts to a text file
        private void Write(Contact obj )
        {
            StreamWriter sw = new StreamWriter("Contacts.txt");
            sw.WriteLine(phoneBook.Length + 1);
            sw.WriteLine(obj.FirstName);
            sw.WriteLine(obj.LastName);
            sw.WriteLine(obj.Phone);

            for( int x = 0; x < phoneBook.Length; x++)
            {
                sw.WriteLine(phoneBook[x].FirstName);
                sw.WriteLine(phoneBook[x].LastName);
                sw.WriteLine(phoneBook[x].Phone);
            }

            sw.Close();
        }

        private void Read()
        {
            StreamReader sr = new StreamReader("Contacts.txt");
            phoneBook = new Contact[Convert.ToInt32(sr.ReadLine())];

            for(int x = 0; x < phoneBook.Length; x++)
            {
                phoneBook[x] = new Contact();
                phoneBook[x].FirstName = sr.ReadLine();
                phoneBook[x].LastName = sr.ReadLine();
                phoneBook[x].Phone = sr.ReadLine();
            }

            sr.Close();
        }

        // display saved contacts to the contact list
        private void Display()
        {
            lstContacts.Items.Clear();
            for(int x = 0; x < phoneBook.Length; x++)
            {
                lstContacts.Items.Add(phoneBook[x].ToString());
            }
        }

        // once user has add contact, clear the text boxes of entries
        private void ClearForm()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            // Create new object and assign values in text boxes to object
            Contact obj = new Contact();
            obj.FirstName = txtFirstName.Text;
            obj.LastName = txtLastName.Text;
            obj.Phone = txtPhone.Text;

            Write(obj);
            Read();
            BubbleSort();
            Display();
            ClearForm();

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            BubbleSort();
            Display();
        }

        private void BubbleSort()
        {
            Contact temp;
            bool swap;

            do
            {
                swap = false;

                for(int x = 0; x < (phoneBook.Length -1); x++)
                {
                    if (phoneBook[x].LastName.CompareTo(phoneBook[x + 1].LastName) > 0)
                    {
                        temp = phoneBook[x];
                        phoneBook[x] = phoneBook[x + 1];
                        phoneBook[x + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap == true);
        }

    }
}

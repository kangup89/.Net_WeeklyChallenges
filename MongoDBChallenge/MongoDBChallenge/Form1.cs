using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDBChallenge
{
    public partial class Form1 : Form
    {
        public static List<Person> people = new List<Person>();
        public static MongoDBAccess mongoDB = new MongoDBAccess();

        public Form1()
        {
            InitializeComponent();

            WireUpData();
        }

        public void WireUpData()
        {
            people = mongoDB.getPeople();
            peopleListBox.DataSource = people;
            peopleListBox.DisplayMember = "FullName";
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            Person p = new Person();

            p.FirstName = firstNameTextBox.Text;
            p.LastName = lastNameTextBox.Text;
            p.PhoneNumber = phoneNumberTextBox.Text;
            
            mongoDB.addOrUpdate(p);
            WireUpData();
        }
    }
}

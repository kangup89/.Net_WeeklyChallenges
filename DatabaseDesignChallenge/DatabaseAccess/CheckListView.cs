using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseAccess.Models;

namespace DatabaseAccess
{
    public partial class CheckListView : Form
    {
        BindingList<Person> people = new BindingList<Person>();
        BindingList<Present> presents = new BindingList<Present>();
        BindingList<Person> leftPeople = new BindingList<Person>();

        public CheckListView()
        {
            InitializeComponent();

            peopleList.DataSource = people;
            peopleList.DisplayMember = "FullName";

            presentsList.DataSource = presents;
            presentsList.DisplayMember = "DisplayName";

            leftPeopleList.DataSource = leftPeople;
            leftPeopleList.DisplayMember = "FullName";

            getPeople();
            getPresents();
            getLeftPeople();
        }

        public void getPeople()
        {
            var list = DataAccess.getPeople();

            people.Clear();
            foreach (var p in list)
            {
                people.Add(p);
            }
        }

        public void getPresents()
        {
            var list = DataAccess.getPresents();

            presents.Clear();
            foreach (var p in list)
            {
                presents.Add(p);
            }
        }

        public void getLeftPeople()
        {
            var list = DataAccess.getLeftPeople();

            leftPeople.Clear();
            foreach (var p in list)
            {
                leftPeople.Add(p);
            }
        }

        private void presentButton_Click(object sender, EventArgs e)
        {
            int personId = leftPeople[leftPeopleList.SelectedIndex].Id;
            int presentId = presents[presentsList.SelectedIndex].Id;

            DataAccess.givePresent(personId, presentId);

            getPeople();
            getPresents();
            getLeftPeople();
        }
    }

}

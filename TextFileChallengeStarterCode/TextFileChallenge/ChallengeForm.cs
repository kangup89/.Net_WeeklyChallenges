using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    {
        //BindingList<UserModel> users = new BindingList<UserModel>();
        BindingList<UserModel> users = FileProcessor.readFile();

        public ChallengeForm()
        {
            InitializeComponent();

            WireUpDropDown();
        }

        private void WireUpDropDown()
        {
            usersListBox.DataSource = users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        public void getUserModels(BindingList<UserModel> userModels)
        {
            users = userModels;
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {

            UserModel model = new UserModel();

            model.FirstName = firstNameText.Text;
            model.LastName = lastNameText.Text;
            model.Age = (int)agePicker.Value;
            model.IsAlive = isAliveCheckbox.Checked;

            users.Add(model);
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            FileProcessor.writeStandardFile(users);
        }
    }
}

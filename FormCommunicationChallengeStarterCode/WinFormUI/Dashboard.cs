using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Dashboard : Form, IRequestForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void launchMessage_Click(object sender, EventArgs e)
        {
            MessageCreation mcr = new MessageCreation(this);
            mcr.Show();
        }

        private void launchSubDashboard_Click(object sender, EventArgs e)
        {
            SubDashboard sdb = new SubDashboard();
            sdb.Show();
        }

        public void ShowMessage(MessageModel message)
        {
            messageText.Text = message.showMessage;
        }
    }
}

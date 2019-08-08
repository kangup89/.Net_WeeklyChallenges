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
    public partial class SubDashboard : Form, IRequestForm
    {
        public SubDashboard()
        {
            InitializeComponent();
        }

        private void launchMessage_Click(object sender, EventArgs e)
        {
            MessageCreation mcr = new MessageCreation(this);
            mcr.Show();
        }

        public void ShowMessage(MessageModel message)
        {
            nameAndMessageText.Text = message.showMessage;
        }
    }
}

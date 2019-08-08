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
    public partial class MessageCreation : Form
    {
        private IRequestForm callingForm;

        public MessageCreation(IRequestForm caller)
        {
            InitializeComponent();

            callingForm = caller;
        }

        private void createMessage_Click(object sender, EventArgs e)
        {
            MessageModel message = new MessageModel();
            message.Name = nameText.Text;
            message.Message = messageText.Text;

            callingForm.ShowMessage(message);          
        }
    }
}

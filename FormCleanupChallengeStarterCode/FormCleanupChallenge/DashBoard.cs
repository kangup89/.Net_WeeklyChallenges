using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCleanupChallenge
{
    public partial class Dashboard : Form, IForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            // This pretend code executes when the form is closed. This
            // could be data cleanup code or code to close down open
            // connections.
            FormClosedTest test = new FormClosedTest();
            test.Form_FormClosed(sender, e);
        }
    }
}

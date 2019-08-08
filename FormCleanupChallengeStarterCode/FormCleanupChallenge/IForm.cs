using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCleanupChallenge
{
    interface IForm
    {
        void Form_FormClosed(object sender, FormClosedEventArgs e);
    }
}

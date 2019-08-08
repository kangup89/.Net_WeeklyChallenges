using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PillReminderUI
{
    public partial class ReminderWindow : Form
    {
        BindingList<PillModel> medications = new BindingList<PillModel>();
        BindingList<PillModel> pillsToTake = new BindingList<PillModel>();

        public ReminderWindow()
        {
            InitializeComponent();
            allPillsListBox.DataSource = medications;
            allPillsListBox.DisplayMember = "PillInfo";

            PopulateDummyData();

            pillsToTakeListBox.DataSource = pillsToTake;
            pillsToTakeListBox.DisplayMember = "pillName";

            checkTakenPills();
        }

        private void PopulateDummyData()
        {
            //medications.Add(new PillModel { PillName = "The white one", TimeToTake = DateTime.ParseExact("0:15 am", "hh:mm tt", null, System.Globalization.DateTimeStyles.AssumeLocal) });
            medications.Add(new PillModel { PillName = "The white one", TimeToTake = DateTime.Parse("0:15 am") });
            medications.Add(new PillModel { PillName = "The big one", TimeToTake = DateTime.Parse("8:00 am") });
            medications.Add(new PillModel { PillName = "The red ones", TimeToTake = DateTime.Parse("11:45 pm") });
            medications.Add(new PillModel { PillName = "The oval one", TimeToTake = DateTime.Parse("0:27 am") });
            medications.Add(new PillModel { PillName = "The round ones", TimeToTake = DateTime.Parse("6:15 pm") });
        }

        private void checkTakenPills()
        {
            pillsToTake.Clear();

            DateTime today = DateTime.Today;
            DateTime checkPoint = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);

            //Console.WriteLine("CheckPoint : {0}", checkPoint);

            //foreach (PillModel p in medications)
            //{
            //    if (DateTime.Compare(checkPoint, p.LastTaken) > 0)
            //    {
            //        pillsToTake.Add(p);
            //    }
            //}

            var pills = from p in medications
                        where p.LastTaken < checkPoint
                        orderby p.PillName ascending
                        select p;

            foreach (var p in pills)
            {
                pillsToTake.Add(p);
            }
        }

        private void takePill_Click(object sender, EventArgs e)
        {
            if (pillsToTakeListBox.SelectedIndex >= 0)
            {
                pillsToTake[pillsToTakeListBox.SelectedIndex].LastTaken = DateTime.Now;
                checkTakenPills();
            }
        }
    }
}

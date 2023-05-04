using Lintumies.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lintumies
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            results();
        }

        BirdDB.BirdDBMethods birdDetails;

        private void results()
        {
            List<string> birds = new List<string>();
            birds.Add("Harakka");
            birds.Add("Hippiainen");
            birds.Add("Jarripeippo");
            birds.Add("Kaki");
            birds.Add("Pajulintu");
            birds.Add("Peippo");
            birds.Add("Punarinta");
            birds.Add("Rakattirastas");
            birds.Add("Selkalokki");
            birds.Add("Varis");

            listView1.Clear();
            listView1.View = View.Details;
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            listView1.Columns.Add("Bird Name", 100);
            listView1.Columns.Add("Heard Count");
            listView1.Columns.Add("Correct Count");
            listView1.Columns.Add("Wrong Count");
            listView1.Columns.Add("Percentage Correct");


            List<BirdDB.BirdDBMethods> birdDetailsList = new List<BirdDB.BirdDBMethods>();
            foreach (string bird in birds)
            {
                birdDetailsList.Add(BirdDB.BirdDBMethods.GetBirdDetails(bird));
            }
            var sortedBirdDetails = birdDetailsList.OrderByDescending(b => (double)b.correctCnt / b.heardCnt);

            // Create the header row
            ListViewItem headerRow = new ListViewItem(new[] { "Bird", "Heard", "Correct", "Wrong", "Correct %" });
            // Insert the header row at index 0
            listView1.Items.Insert(0, headerRow);

            foreach (var birdDetails in sortedBirdDetails)
            {
                double correctPercentage = 0;
                if (birdDetails.heardCnt > 0)
                    correctPercentage = Math.Round(((double)birdDetails.correctCnt / birdDetails.heardCnt), 4) * 100;
                ListViewItem item = new ListViewItem(new[] { birdDetails.birdName, birdDetails.heardCnt.ToString(), birdDetails.correctCnt.ToString(), birdDetails.wrongCnt.ToString(), correctPercentage.ToString() });
                listView1.Items.Add(item);

            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);


        }

        //go back to gameplay
        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            Form1 form1 = new Form1();

            // Show the new form
            form1.Show();

            // Hide the current form (Form1)
            this.Hide();
        }
    }
}

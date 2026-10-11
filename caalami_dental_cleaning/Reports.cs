using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caalami_dental_cleaning
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem.ToString() == "PATIENTS")
            {
                patientsReport rpt = new patientsReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "DENTISTS")
            {
                dentistsReport rpt = new dentistsReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "APPOINTMENTS")
            {
                appointmentsReport rpt = new appointmentsReport();
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (guna2ComboBox1.SelectedItem.ToString() == "TREATMENTS")
            {
                treatmentsReport rpt = new treatmentsReport();
                crystalReportViewer1.ReportSource = rpt;
            }

        }

        private void Reports_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.Insert(0, "Choose select");
            guna2ComboBox1.SelectedIndex = 0;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();

        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            new login().Show(); this.Hide();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            new patients().Show(); this.Hide();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            new dentists().Show(); this.Hide();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            new appointments().Show(); this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new treatments().Show(); this.Hide();
        }
    }
}

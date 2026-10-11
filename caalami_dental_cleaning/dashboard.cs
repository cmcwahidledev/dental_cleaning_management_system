using caalami_dental_cleaning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caalami_dental_cleaning
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        void tms()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");


            SqlDataAdapter da = new SqlDataAdapter("select * from treatments", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pts();
            tms();
            dts();
            aps();
        }
        private void pts()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select count(*)from patients", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblemp.Text = result.ToString();
            }
            else
            {
                lblemp.Text = "0";
            }
            conn.Close();
        }
        private void dts()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");


            SqlCommand cmd = new SqlCommand("select count(*)from dentists", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lblpre.Text = result.ToString();
            }
            else
            {
                lblpre.Text = "0";
            }
            conn.Close();
        }
        private void aps()
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");


            SqlCommand cmd = new SqlCommand("select count(*)from appointments", conn);
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                lbllate.Text = result.ToString();
            }
            else
            {
                lbllate.Text = "0";
            }
            conn.Close();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new patients().Show(); this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tms();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new dentists().Show(); this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new appointments().Show(); this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new treatments().Show(); this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();

        }
    }
}

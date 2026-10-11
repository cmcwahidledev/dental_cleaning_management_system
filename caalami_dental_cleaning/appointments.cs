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
using System.Xml.Linq;

namespace caalami_dental_cleaning
{
    public partial class appointments : Form
    {
        public appointments()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new dentists().Show(); this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new patients().Show(); this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new dashboard().Show(); this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show(); this.Hide();
        }

        private void appointments_Load(object sender, EventArgs e)
        {
            ats();
            boxgender.SelectedIndex = 0;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void ats()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from appointments ", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO appointments(patiendID, dentistID, date, status) VALUES (@pid, @did, @date, @status)", conn);

                cmd.Parameters.AddWithValue("@pid", pid.Text);
                cmd.Parameters.AddWithValue("@did", did.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(date.Text));
                cmd.Parameters.AddWithValue("@status", boxgender.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("appointments saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ats();
                pid.Clear();
                did.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ats();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from appointments where ID='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);


            SqlCommand cmd = new SqlCommand("delete from appointments where ID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete appointments success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            ats();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);


                SqlCommand cmd = new SqlCommand("update appointments set patiendID=@pid ,dentistID=@did ,date=@date, status=@status where ID=@ID", conn);

                cmd.Parameters.AddWithValue("@pid", pid.Text);
                cmd.Parameters.AddWithValue("@did", did.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(date.Text));
                cmd.Parameters.AddWithValue("@status", boxgender.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update appointments success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                ats();

                pid.Clear();
                did.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new treatments().Show(); this.Hide();
        }
    }
}

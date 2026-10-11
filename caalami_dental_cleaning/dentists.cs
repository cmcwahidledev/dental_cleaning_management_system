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
    public partial class dentists : Form
    {
        public dentists()
        {
            InitializeComponent();
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
        void dts()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from dentists ", conn);

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
                SqlCommand cmd = new SqlCommand("INSERT INTO dentists(name, phone, specialty) VALUES (@name, @phone, @specialty)", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@specialty", boxgender.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("dentists saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dts();
                txtname.Clear();
                txtphone.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dentists_Load(object sender, EventArgs e)
        {
            dts();
            boxgender.SelectedIndex = 0;
            dataGridView1.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dts();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);


                SqlCommand cmd = new SqlCommand("update dentists set name=@name ,phone=@phone ,specialty=@specialty where ID=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@specialty", boxgender.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update dentists success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                dts();

                txtname.Clear();
                txtphone.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);


            SqlCommand cmd = new SqlCommand("delete from dentists where ID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete dentists success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            dts();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from dentists where ID='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new appointments().Show(); this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new treatments().Show(); this.Hide();
        }
    }
}

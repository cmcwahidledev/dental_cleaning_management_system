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
    public partial class patients : Form
    {
        public patients()
        {
            InitializeComponent();
        }

        private void patients_Load(object sender, EventArgs e)
        {
            boxgender.SelectedIndex = 0;
            pts();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        void pts()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from patients ", conn);

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
                SqlCommand cmd = new SqlCommand("INSERT INTO patients(name, phone, gender, age) VALUES (@name, @phone, @gender, @age)", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@gender", boxgender.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("patients saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pts();
                txtname.Clear();
                txtphone.Clear();
                txtage.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);


                SqlCommand cmd = new SqlCommand("update patients set name=@name ,phone=@phone ,gender=@gender, age=@age where ID=@ID", conn);

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@gender", boxgender.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update patients success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                pts();

                txtname.Clear();
                txtphone.Clear();
                txtage.Clear();
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


            SqlCommand cmd = new SqlCommand("delete from patients where ID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete patients success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            pts();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from patients where ID='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pts();
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
    }
}

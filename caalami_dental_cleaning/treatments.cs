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
    public partial class treatments : Form
    {
        public treatments()
        {
            InitializeComponent();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new login().Show(); this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            new Reports().Show(); this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            new appointments().Show(); this.Hide();
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
        void tms()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from treatments ", conn);

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
                SqlCommand cmd = new SqlCommand("INSERT INTO treatments(patiendID, dentistID, treatmentName, price, date) VALUES (@pid, @did, @tmname, @price, @date)", conn);

                cmd.Parameters.AddWithValue("@pid", pid.Text);
                cmd.Parameters.AddWithValue("@did", did.Text);
                cmd.Parameters.AddWithValue("@tmname", tmname.Text);
                cmd.Parameters.AddWithValue("@price", price.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(date.Text));

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("treatments saved success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tms();
                pid.Clear();
                did.Clear();
                tmname.Clear();
                price.Clear();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treatments_Load(object sender, EventArgs e)
        {
            tms();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tms();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);


                SqlCommand cmd = new SqlCommand("update treatments set patiendID=@pid ,dentistID=@did , treatmentName=@tmname, price=@price, date=@date where ID=@ID", conn);

                cmd.Parameters.AddWithValue("@pid", pid.Text);
                cmd.Parameters.AddWithValue("@did", did.Text);
                cmd.Parameters.AddWithValue("@tmname", tmname.Text);
                cmd.Parameters.AddWithValue("@price", price.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(date.Text));
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update treatments success", "200", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                tms();

                pid.Clear();
                did.Clear();
                tmname.Clear();
                price.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

            SqlCommand cmd = new SqlCommand("select * from treatments where ID='" + txtsearch.Text + "'", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T9JSR89;Integrated Security=SSPI;Initial Catalog=caalami_dental_cleaning;Integrated Security=true");

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);


            SqlCommand cmd = new SqlCommand("delete from treatments where ID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete treatments success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            tms();
        }
    }
}

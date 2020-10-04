using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FormInsert
{
    public partial class Form1 : Form
    {
        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KHALID\Documents\khalid.mdf;Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            try
            {
                String insertQuery = "INSERT INTO parth (name,city,country) VALUES(@name,@city,@country)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@city", textBox3.Text);
                cmd.Parameters.AddWithValue("@country", textBox4.Text);
                con.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            GirdDisplay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GirdDisplay();
        }
        public void GirdDisplay()
        {
            //MySqlConnection con = new MySqlConnection(constring);
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string query = "Select * from parth";
                //MySqlCommand cmd = new MySqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                //MySqlDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            try
            {
                String updateQuery = "Update parth SET name=@name,city=@city,country=@country where id=@id";
                //MySqlCommand cmd = new MySqlCommand(updateQuery, con);
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@city", textBox3.Text);
                cmd.Parameters.AddWithValue("@country", textBox4.Text);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            GirdDisplay();
        
    }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            try
            {
                String deleteQuery = "Delete from parth where id=@id";
                //MySqlCommand cmd = new MySqlCommand(deleteQuery, con);
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            GirdDisplay();
        }
    }
}

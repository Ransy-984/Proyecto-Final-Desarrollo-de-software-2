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

namespace Proyecto_Final_2
{
    public partial class ArticleList : Form
    {
        public ArticleList()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtStock.Text) || string.IsNullOrEmpty(txtExpirationDate.Text) || string.IsNullOrEmpty(txtHall.Text))
            {
                MessageBox.Show("One or more parameters are missing");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-N3ABNDAC;Initial Catalog=Bravo;User ID=bravo;Password=bravo");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ListArticle VALUES(@ProductName, @Price, @Stock, @Hall, @ExpirationDate) ", con);
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@Price", Convert.ToDouble(txtPrice.Text));
                cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@Hall", int.Parse(txtHall.Text));
                cmd.Parameters.AddWithValue("@ExpirationDate", Convert.ToDateTime(txtExpirationDate.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Article succsesfully Inserted");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            txtHall.Clear();
            txtExpirationDate.Clear();
            txtId.Clear();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || !typeCheckInt(txtId.Text))
            {
                MessageBox.Show("unable to do operation due to lack of data or incorrect parameters ");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-N3ABNDAC;Initial Catalog=Bravo;User ID=bravo;Password=bravo");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE ListArticle SET ProductName = @ProductName, Price = @Price, Stock = @Stock, Hall = @Hall, ExpirationDate = @ExpirationDate WHERE Id = @Id ", con);
                cmd.Parameters.AddWithValue("Id", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@Price", Convert.ToDouble(txtPrice.Text));
                cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@Hall", int.Parse(txtHall.Text));
                cmd.Parameters.AddWithValue("@ExpirationDate", Convert.ToDateTime(txtExpirationDate.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Article succsesfully Updated");
            }


        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || !typeCheckInt(txtId.Text))
            {
                MessageBox.Show("unable to do operation due to lack of data or incorrect parameters ");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-N3ABNDAC;Initial Catalog=Bravo;User ID=bravo;Password=bravo");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE ListArticle WHERE Id = @Id ", con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Article succsesfully Deleted");
            }



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || !typeCheckInt(txtId.Text))
            {
                MessageBox.Show("unable to do operation due to lack of data or incorrect parameters ");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-N3ABNDAC;Initial Catalog=Bravo;User ID=bravo;Password=bravo");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ListArticle WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("Id", int.Parse(txtId.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgArticle.DataSource = dt;
            }

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-N3ABNDAC;Initial Catalog=Bravo;User ID=bravo;Password=bravo");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ListArticle" , con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgArticle.DataSource = dt;
        }


        private bool typeCheckInt(string text)
        {
            int numero = 0;
            return int.TryParse(text, out numero);
        }
        private bool IsNullOrEmpty(string text)
        {
            throw new NotImplementedException();
        }
    }
}

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
using System.Configuration;
using System.IO;

namespace ExamRevision
{
    public partial class Form1 : Form
    {
        DbUtil dbUtil = new DbUtil();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //day 3 page 3
            using (SqlConnection c = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Select Count(*) from products", c))
                {
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        textBox1.Text = " No. of Rows " + sqlReader.GetValue(0).ToString();
                    }
                }
            }

            //Multiple Queries
            using (SqlConnection c = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Select top 2 * from products; select top 2 * from orders; select top 2 * from customers", c))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                        while (sqlReader.Read())
                        {
                            textBox2.Text = "From first SQL - " + sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1);
                        }

                        sqlReader.NextResult();

                        while (sqlReader.Read())
                        {
                            textBox3.Text = "From second SQL - " + sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1);
                        }

                        sqlReader.NextResult();

                        while (sqlReader.Read())
                        {
                            textBox4.Text = "From third SQL - " + sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1);
                        }
                    }

                    /* //Other method filling 3 tables
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {

                        DataSet ds = new DataSet();

                        //sqlDataAdapter.TableMappings.Add("Table", "Products");
                        //sqlDataAdapter.TableMappings.Add("Table1", "Orders");
                        //sqlDataAdapter.TableMappings.Add("Table2", "Customers");

                        sqlDataAdapter.Fill(ds);

                        DataView dv;
                        dv = new DataView(ds.Tables["Table"]);
                        multiDataGridView1.DataSource = dv;


                        dv = new DataView(ds.Tables["Table1"]);
                        multiDataGridView2.DataSource = dv;

                        dv = new DataView(ds.Tables["Table2"]);
                        multiDataGridView3.DataSource = dv;


                    }*/
                }
            }




            //parameters 1
            using (SqlConnection c = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                string PName = "Chai";
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE ProductName LIKE @ProductName", c))
                {
                    command.Parameters.Add(new SqlParameter("ProductName", PName));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string ProductName = reader.GetString(1);
                        double UnitPrice = (double)reader.GetDecimal(5);
                        int UnitsInStock = reader.GetInt16(6);
                        textBox5.Text = "" + ProductName + " " + UnitPrice + "  " + UnitsInStock;
                    }
                }
            }
            //Adding data to combobox **extra**
            using (SqlConnection c = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products", c))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        parameterComboBox.Items.Add(reader.GetString(1));
                    }

                    parameterComboBox.Items.Add("*Select All*");
                }
            }



            //SqlAdapter
            using (SqlConnection c = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Products", c))
                {
                    //DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);
                    dataGridView1.DataSource = t;

                    //Dataset
                    /*
                    DataSet ds = new DataSet();
                    a.Fill(ds, "Products_table");

                    DataView dv;
                    dv = new DataView(ds.Tables["Products_table"]);
                    dataGridView1.DataSource = dv;
                     */
                }
            }


            //Excutescalar
            using (SqlConnection c = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Select Count(*) from products", c))
                {
                    Int32 count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    textBox6.Text = " No. of Rows " + count;
                }
            }


        }

        //Insert
        private void InsertButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connectionString = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                string query = "INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description) ";
                using (SqlCommand sqlCommand = new SqlCommand(query, connectionString))
                {
                    // define parameters and their values
                    sqlCommand.Parameters.Add("@CategoryName", SqlDbType.VarChar, 50).Value = "Meat";
                    sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = "Steak";

                    // open connection, execute INSERT, close connection
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }


        //Delete
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connectionString = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                string query = "Delete From Categories where CategoryName = 'Meat';";
                using (SqlCommand sqlCommand = new SqlCommand(query, connectionString))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        //Parameters 2 **extra**
        private void parameterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (SqlConnection c = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                string PName = parameterComboBox.SelectedItem.ToString();
                using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Products WHERE ProductName LIKE @ProductName", c))
                {
                    if (PName.Equals("*Select All*"))
                    {
                        a.SelectCommand = new SqlCommand("SELECT * FROM Products", c);
                    }
                    else a.SelectCommand.Parameters.Add(new SqlParameter("ProductName", PName));
                    DataTable t = new DataTable();
                    a.Fill(t);
                    dataGridView1.DataSource = t;

                }
            }
        }

        //show Categories
        private void showButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection c = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Categories", c))
                {
                    DataTable t = new DataTable();
                    a.Fill(t);
                    dataGridView1.DataSource = t;
                }
            }
        }


        //load and save image
        private void loadButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection c = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                using (SqlCommand com = new SqlCommand("INSERT INTO Categories VALUES(@CategoryName,@description, @picture)", c))
                {
                    OpenFileDialog fop = new OpenFileDialog();
                    fop.InitialDirectory = @"C:\";
                    fop.Filter = "[JPG,JPEG]|*.jpg";
                    if (fop.ShowDialog() == DialogResult.OK)
                    {
                        FileStream FS = new FileStream(@fop.FileName, FileMode.Open, FileAccess.Read);
                        byte[] img = new byte[FS.Length];
                        FS.Read(img, 0, Convert.ToInt32(FS.Length));
                        com.Parameters.AddWithValue("@CategoryName", "Drinks");
                        com.Parameters.AddWithValue("@description", "more drinks");
                        com.Parameters.AddWithValue("@picture", img);
                        com.ExecuteNonQuery();

                    }
                    else
                    {
                        MessageBox.Show("Please Select a Image to save!!", "Information", MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);
                    }
                }
            }
        }

        //retrieve image
        private void retrieveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection c = dbUtil.GetSqlConnection(dbUtil.GetConnectionString()))
            {
                using (SqlCommand com = new SqlCommand("Select Picture from Categories where CategoryName='Beverages'", c))
                {
                    byte[] imageAsByte = (byte[])com.ExecuteScalar();
                    MemoryStream ms = new MemoryStream(imageAsByte);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        


    }
}

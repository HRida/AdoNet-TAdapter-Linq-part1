using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamRevision
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void productsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.northwindDataSet.Categories);
            // TODO: This line of code loads data into the 'northwindDataSet.Order_Details' table. You can move, or remove it, as needed.
            this.order_DetailsTableAdapter.Fill(this.northwindDataSet.Order_Details);
            // TODO: This line of code loads data into the 'northwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter.FillByCategoryID(this.northwindDataSet.Products, Convert.ToInt32(categoriesComboBox.SelectedValue));
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);
        }

        private void idButton_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter.FillByProductID(this.northwindDataSet.Products,Convert.ToInt32(idTextBox.Text));
        }

        private void nameButton_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter.FillByProductName(this.northwindDataSet.Products,nameTextBox.Text);
        }

        private void order_DetailsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            order_DetailsDataGridView.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            order_DetailsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkBlue;
            order_DetailsDataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
            order_DetailsDataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            if (e.ColumnIndex == 5)
            {
                order_DetailsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Orange, BackColor = Color.Blue };




                //e.Value = e.Value.ToString().Substring(0, 5);
                //e.FormattingApplied = true;
                if (Convert.ToDouble(e.Value) > 20.0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.BackColor = Color.Yellow;

                }
                else
                {

                    order_DetailsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = order_DetailsDataGridView.DefaultCellStyle;

                }

                /* if (productsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString() == "2")
                 {
                     e.CellStyle.ForeColor = Color.Red;
                 }*/
            }
        }
    }
}

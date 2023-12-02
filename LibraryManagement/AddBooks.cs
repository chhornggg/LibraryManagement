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

namespace LibraryManagement
{

    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {
                /*
                String bname = txtBookName.Text;
                String bauthor = txtAuthor.Text;
                String publication = txtPublication.Text;
                String pdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);
                */
                /*SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-CF5N97R\\SQLEXPRESS; database = library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuan) values ('" + bname + "', '" + bauthor + "', '" + publication + "', '" + pdate + "', " + price + ", " + quan + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                */
                Book newBook = new Book();
                newBook.BookName = txtBookName.Text;
                newBook.BookAuthor = txtAuthor.Text;
                newBook.BookPublication = txtPublication.Text;
                newBook.Date = dateTimePicker1.Text;
                newBook.Price = Int64.Parse(txtPrice.Text);
                newBook.Quantity = Int64.Parse(txtQuantity.Text);
                newBook.AddToDatabase();

                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublication.Clear();
                txtPrice.Clear();
                txtQuantity.Clear();
            } 
            else
            {
                MessageBox.Show("Empty Field Not Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will DELETE your unsaved data.", "Are you Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close(); 
            }
        }
    }

    public class Book
    {
        private String bookName;
        private String bookAuthor;
        private String bookPublication;
        private String date;
        private Int64 price;
        private Int64 quantity;

        public String BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        public String BookAuthor
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }

        public String BookPublication
        {
            get { return bookPublication; }
            set { bookPublication = value; }
        }

        public String Date
        {
            get { return date; }
            set { date = value; }
        }

        public Int64 Price
        {
            get { return price; }
            set { price = value; }
        }

        public Int64 Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Book()
        {
            bookName = "";
            bookAuthor = "";
            bookPublication = "";
            date = "";
            price = 0;
            quantity = 0;
        }
        public Book(String bookName, String bookAuthor, String bookPublication, String date, Int64 price, Int64 quantity)
        {
            this.bookName = bookName;
            this.bookAuthor = bookAuthor;
            this.bookPublication = bookPublication;
            this.date = date;
            this.price = price;
            this.quantity = quantity;
        }

        public void AddToDatabase()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-CF5N97R\\SQLEXPRESS; database = library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText = "insert into NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuan) values ('" + BookName + "', '" + BookAuthor + "', '" + BookPublication + "', '" + Date + "', " + Price + ", " + Quantity + ")";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}



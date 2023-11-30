using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagement
{
    public partial class ViewStudentInformation : Form
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchEnrollment_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchEnrollment.Text != "")
            {
                label1.Visible = false;
                Image image = Image.FromFile("C:\\Users\\senge\\source\\repos\\LibraryManagement\\LibraryManagement\\Resources\\search1.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-CF5N97R\\SQLEXPRESS; database = library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where enroll LIKE '" + txtSearchEnrollment.Text + "%'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                label1.Visible = true;
                Image image = Image.FromFile("C:\\Users\\senge\\source\\repos\\LibraryManagement\\LibraryManagement\\Resources\\search1.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-CF5N97R\\SQLEXPRESS; database = library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
        }

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-CF5N97R\\SQLEXPRESS; database = library; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
        }

        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible=true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-CF5N97R\\SQLEXPRESS; database = library; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where stuid = "+bid+" ";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            rowid = Int64.Parse(DS.Tables[0].Rows[0][0].ToString());
            
            txtSName.Text = DS.Tables[0].Rows[0][1].ToString();
            txtEnrollment.Text = DS.Tables[0].Rows[0][2].ToString();
            txtDepartment.Text = DS.Tables[0].Rows[0][3].ToString();
            txtSemester.Text = DS.Tables[0].Rows[0][4].ToString();
            txtContact.Text = DS.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String sname = txtSName.Text;
            String enroll = txtEnrollment.Text;
            String dep = txtDepartment.Text;
            String sem = txtSemester.Text;
            Int64 contact =Int64.Parse (txtContact.Text);
            String semail = txtEmail.Text;

            if (MessageBox.Show("Data Will be Update?. confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-CF5N97R\\SQLEXPRESS; database = library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set sname='" + sname + "',enroll='" + enroll + "', dep='" + dep + "', sem='" + sem + "', contact='" + contact + "', email='" + semail + "' where stuid = " + rowid + "  ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                ViewStudentInformation_Load(this, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewStudentInformation_Load(this, null);
            Image image = Image.FromFile("C:\\Users\\senge\\source\\repos\\LibraryManagement\\LibraryManagement\\Resources\\search1.gif");
            pictureBox1.Image = image;
            txtSearchEnrollment.Clear();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Deleted?. confirm?", "Deleted", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-CF5N97R\\SQLEXPRESS; database = library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where stuid= "+rowid+" ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                ViewStudentInformation_Load(this, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Data Unsaved will be lost?","Are you sure to cancel?", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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

namespace LibraryManagement
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) 
            {
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtName.Focus(); //when clear data cursor auto focus on Name textbox
            txtEnrollment.Clear();
            txtDepartment.Clear();
            txtContact.Clear();
            txtEnrollment.Clear();
            txtSemester.Clear();
            txtEmail.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="" && txtEmail.Text!="" && txtDepartment.Text!="" && txtSemester.Text!="" && txtContact.Text != "")
            {
                /*  String name = txtName.Text;
                  String enroll = txtEnrollment.Text;
                  String dep = txtDepartment.Text;
                  String sem = txtSemester.Text;
                  Int64 mobile = Int64.Parse(txtContact.Text);
                  String email = txtEmail.Text;

                  SqlConnection con = new SqlConnection();
                  con.ConnectionString = "data source = DESKTOP-CF5N97R\\SQLEXPRESS; database = library; integrated security =True";
                  SqlCommand cmd = new SqlCommand();
                  cmd.Connection = con;

                  con.Open();
                  cmd.CommandText = "insert into NewStudent(sname,enroll,dep,sem,contact,email) values ('" + name + "', '" + enroll + "', '" + dep + "', '" + sem + "', '" + mobile + "', '" + email + "')";
                  cmd.ExecuteNonQuery();
                  con.Close();
                  MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); */

                Students newStudents = new Students();
                newStudents.name = txtName.Text;
                newStudents.enroll = txtEnrollment.Text;
                newStudents.dep = txtDepartment.Text;
                newStudents.sem = txtSemester.Text;
                newStudents.mobile = Int64.Parse(txtContact.Text);
                newStudents.email = txtEmail.Text;
                newStudents.AddToDatabase();

                txtName.Clear();
                txtEnrollment.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
            else
            {
                MessageBox.Show("Please fill the emply field", "suggest", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
        }

        
        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class Students
    {
        private String Sname;
        private String Enroll;
        private String department;
        private String semester;
        private Int64 contact;
        private String Email;

        public String name
        {
            get { return Sname; }
            set { Sname = value; }
        }

        public String enroll
        {
            get { return Enroll; }
            set { Enroll = value; }

        }

        public String dep
        {
            get { return department; }
            set { department = value; }
        }

        public String sem
        {
            get { return semester; }
            set { semester = value; }
        }

        public Int64 mobile
        {
            get { return contact; }
            set { contact = value; }
        }

        public String email
        {
            get { return Email; }
            set { Email = value; }
        }

        public Students()
        {
            Sname = "";
            Enroll = "";
            department = "";
            semester = "";
            contact = 0;
            Email = "";
        }

        public Students(String SName, String Enroll, String department, String semester, Int64 contact, String Email)
        {
            this.Sname = SName;
            this.Enroll = Enroll;
            this.department = department;
            this.semester = semester;
            this.contact = contact;
            this.email = email;
        }

        public void AddToDatabase()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-CF5N97R\\SQLEXPRESS; database = library; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText = "insert into NewStudent(sname,enroll,dep,sem,contact,email) values ('" + name + "', '" + enroll + "', '" + dep + "', '" + sem + "', '" + mobile + "', '" + email + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}


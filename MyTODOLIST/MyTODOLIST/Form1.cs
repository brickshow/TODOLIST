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

namespace MyTODOLIST
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TODOLIST;Integrated Security=True");


        Quotes ShowQuote = new Quotes();
        public Form1()
        {
            InitializeComponent();
            dtable.Columns.Add("Task Title");
            dtable.Columns.Add("Priority");
            dtable.Columns.Add("Status");
            dtable.Columns.Add("Start Date");
            dtable.Columns.Add("Due Date");
            dtable.Columns.Add("Completed Date");
        }

        private void AddTask() 
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into TaskTable (taskTitle, startDate, dueDate) values (@taskTitle, @sd, @dd)", conn);
            cmd.Parameters.AddWithValue("@taskTitle", txtTask.Text);
            cmd.Parameters.AddWithValue("@sd", DateTime.Now.ToString("MM / dd / yyyy"));
            cmd.Parameters.AddWithValue("@dd", txtDueDate.Text);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            txtTask.Focus();
            RandomQuotes();
        }

        private void txtTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the Enter key from adding a new line to the textbox
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtDueDate.Focus();
            }
        }

        private void txtDueDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the Enter key from adding a new line to the textbox
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        public void RandomQuotes()
        {
            int index = 0;
            Timer timer = new Timer();
            timer.Interval = 3000; //3 seconds
            timer.Tick += (sender, e) =>
            {
                lblQuotes.Text = ShowQuote.MyQuotes[index];
                index = (index + 1) % ShowQuote.MyQuotes.Length;
            };
            timer.Start();
        }
        DataTable table = new DataTable();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTask();
            Data();

            conn.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtDueDate.Text = dateTimePicker2.Value.ToString("MM/dd/yyyy");


        }
        DataGridViewComboBoxColumn combobox = new DataGridViewComboBoxColumn();
        DataTable dtable = new DataTable();
        DataRow dr;
        private void Data()
        {


            dr = dtable.NewRow();

            if (txtDueDate.Text == "" && txtTask.Text == "")
            {
                MessageBox.Show("Please provide task and due date information..", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtTask.Text == "")
            {
                MessageBox.Show("Task details missing. Please provide.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDueDate.Text == "")
            {
                MessageBox.Show("Please specify Due Date. Thank You!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDueDate.Text != dateTimePicker2.Value.ToString("MM/dd/yyy"))
            {
                MessageBox.Show("Due Date invalid!!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                DataHide.Hide();
                dr["Start Date"] = DateTime.Now.ToString("MM / dd / yyyy");
                dr["Task Title"] = txtTask.Text;
                dr["Due Date"] = txtDueDate.Text;
                dr["Status"] = "Not Started";


                dtable.Rows.Add(dr);
                DataTask.DataSource = dtable;
                DataTask.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                GetTimeSort();
          

   

                //DataTask.Rows[0].Cells[0].Value = "Not Started";

                txtDueDate.Clear();
                txtTask.Clear();
                txtTask.Focus();
            }
            
        }

        public void GetTimeSort()
        {
            
            //DataTask.Sort(DataTask.Columns[0], ListSortDirection.Ascending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
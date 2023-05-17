using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace lr12
{
    public partial class MenuForm : Form
    {
        private readonly AppDbContext _context;
        private readonly User _user;
        public LoginForm loginForm;
        public MenuForm(AppDbContext context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;

            int userId = _user.Id;
            _user = _context.User.Include(u => u.Task).First(u => u.Id == userId);

            /*_user.Task = _context.Task.Where(t => t.UserId == _user.Id).ToList();*/


            Text = $"Задачи пользователя {_user.Name}";

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _user.Task;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm(_context, _user);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _user.Task;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var task = (Task)selectedRow.DataBoundItem;
            _user.Task.Remove(task);
            _context.SaveChanges();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _user.Task;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var task = (Task)selectedRow.DataBoundItem;
            if (task.Status == false)
                task.Status = true;
            else
                task.Status = false;
            _context.SaveChanges();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _user.Task;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }
    }
}

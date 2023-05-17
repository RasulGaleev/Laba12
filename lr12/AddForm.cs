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

namespace lr12
{
    public partial class AddForm : Form
    {
        private readonly AppDbContext _context;
        private readonly User _user;

        public Task Task { get; private set; }
        public AddForm(AppDbContext context, User user)
        {

            InitializeComponent();
            _context = context;
            _user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var task = new Task
            {
                UserId = _user.Id,
                Date = (dateTimePicker1.Value).ToString(),
                Client = textBox1.Text,
                Item = textBox2.Text,
                Count = Convert.ToInt32(textBox3.Text),
                Status = textBox4.Text
            };

            _context.Task.Add(task);
            _context.SaveChanges();

            Task = task;
            DialogResult = DialogResult.OK;
        }
    }
}

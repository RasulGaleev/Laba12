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
    public partial class LoginForm : Form
    {
        private AppDbContext context;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user;
            using (var context = new AppDbContext())
            {
                var email = textBox1.Text;
                var password = textBox2.Text;

                user = context.User.FirstOrDefault(u => u.Email == email && u.Password == password);
            }


            if (user != null)
            {
                MessageBox.Show("Вы успешно вошли!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Аккаунт не найден!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}

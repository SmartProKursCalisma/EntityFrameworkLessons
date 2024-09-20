using EntityFrameworkLessons.DbConnection;
using EntityFrameworkLessons.Forms;
using EntityFrameworkLessons.Repositories;
using System;
using System.Windows.Forms;

namespace EntityFrameworkLessons
{
    public partial class Form1 : Form
    {
        UserRepository _userRepo;
        public Form1()
        {
            InitializeComponent();
            _userRepo = new UserRepository();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "melih.kamar";
            txtPassword.Text = "123456";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool isLogin =  _userRepo.Login(username,password);
            if (isLogin)
            {
                MessageBox.Show("Giriş Başarılı!","Bilgi");
                this.Hide();
                UserManagement userManagement = new UserManagement();
                userManagement.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı Bulunamadı!", "Bilgi");
            }
        }
    }
}

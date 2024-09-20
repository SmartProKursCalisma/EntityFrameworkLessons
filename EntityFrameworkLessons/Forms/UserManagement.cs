using EntityFrameworkLessons.Entities;
using EntityFrameworkLessons.Repositories;
using System;
using System.Windows.Forms;

namespace EntityFrameworkLessons.Forms
{
    //CRUD OPERATIONS
    //CREATE
    //READ
    //UPDATE
    //DELETE
    public partial class UserManagement : Form
    {
        UserRepository _userRepo;
        public UserManagement()
        {
            InitializeComponent();
            _userRepo = new UserRepository();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _userRepo.GetAllUser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = txtRole.Text;
            User user = new User()
            {
                Username = username,
                Password = password,
                Role = role
            };
            _userRepo.AddUser(user);
            dataGridView1.DataSource = _userRepo.GetAllUser();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            //User user = row.DataBoundItem as User;
            User user = (User)row.DataBoundItem;
            txtUsername.Text = user.Username;
            txtPassword.Text = user.Password;
            txtRole.Text = user.Role;
            txtId.Text = user.Id.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Id = int.Parse(txtId.Text),
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Role = txtRole.Text
            };
            _userRepo.UpdateUser(user);
            dataGridView1.DataSource = _userRepo.GetAllUser();



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            _userRepo.DeleteUser(id);
            dataGridView1.DataSource = _userRepo.GetAllUser();

        }

        private void txtSerachBar_TextChanged(object sender, EventArgs e)
        {
           dataGridView1.DataSource = _userRepo.SearchUser(txtSerachBar.Text);
        }
    }
}

using BlackJack.DbModels;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class LoginForm : Form
    {
        BlackJackContext context;
        public LoginForm()
        {
            InitializeComponent();
             context= new BlackJackContext();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            RegistrationForm form = new RegistrationForm();
            form.Closed += (s, args) => this.Close();
            this.Hide();
            form.Show();
            
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            string username = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;
            var user = context.Users.SingleOrDefault(x => x.UserName == username);
            if(user is null)
            {
                MessageBox.Show("Incorrect user credentials");
                return;
            }
            string hashedPassword = PasswordHasher.HashPassword(password);
            if(hashedPassword!=user.PasswordHash)
            {
                MessageBox.Show("Incorrect user credentials");
                return;
            }

            Game form = new Game(user.Id);
            form.Closed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }
    }
}

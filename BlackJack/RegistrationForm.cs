using BlackJack.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class RegistrationForm : Form
    {
        BlackJackContext context;
        public RegistrationForm()
        {
            InitializeComponent();
            context = new BlackJackContext();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            FNErrorMessage.Text = "";
            LNErrorMessage.Text = "";
            PasswordErrorMessage.Text = "";
            ConfirmPasswordErrorMessage.Text = "";
        }

        private void OpenLogInForm_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Closed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if(!CheckAllFields())
            {
                return;
            }
            if (!string.IsNullOrEmpty(FNErrorMessage.Text))
            {
                MessageBox.Show(FNErrorMessage.Text);
                return;
            }
            if(!string.IsNullOrEmpty(LNErrorMessage.Text))
            {
                MessageBox.Show(LNErrorMessage.Text);
                return;
            }
            if (!string.IsNullOrEmpty(PasswordErrorMessage.Text))
            {
                MessageBox.Show(PasswordErrorMessage.Text);
                return;
            }
            if (!string.IsNullOrEmpty(ConfirmPasswordErrorMessage.Text))
            {
                MessageBox.Show(ConfirmPasswordErrorMessage.Text);
                return;
            }
            if(!CheckAge())
            {
                MessageBox.Show("You must be at least 18 years old to regiser");
                return;
            }
            var user1 = context.Users.SingleOrDefault(x => x.UserName == UserNameTextBox.Text);
            var user2 = context.Users.SingleOrDefault(x => x.Email == EmailTextBox.Text);
            if(!(user1 is null))
            {
                MessageBox.Show("User name is already taken");
                return;
            }
            if(!(user2 is null))
            {
                MessageBox.Show("Email is already used");
                return;
            }

            User user = new User();
            user.FirstName=FirstNameTextBox.Text;
            user.LastName=LastNameTextBox.Text;
            user.UserName=UserNameTextBox.Text;
            user.Email=EmailTextBox.Text;
            user.DateOfBirth = BirthDatePicker.Value;
            user.PasswordHash = PasswordHasher.HashPassword(PasswordTextBox.Text);
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("User is successfully registered");
            LoginForm form = new LoginForm();
            form.Closed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FNErrorMessage.Text = "";
            string text = FirstNameTextBox.Text;
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    FNErrorMessage.Text = "First name must contain letters only";
                }
            }
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordErrorMessage.Text = "";
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            Regex regex = new Regex(pattern);
            if(!regex.IsMatch(PasswordTextBox.Text))
            {
                PasswordErrorMessage.Text = "Password must contain at least 8 characters: at least 1 uppercase letter, at least 1 lowercase letter and at least 1 digit";
            }

        }

        private void ConfirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            ConfirmPasswordErrorMessage.Text = "";
            if(PasswordTextBox.Text !=ConfirmPasswordTextBox.Text)
            {
                ConfirmPasswordErrorMessage.Text = "Passwords did not match";
            }
        }

        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            LNErrorMessage.Text = "";
            string text = LastNameTextBox.Text;
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    LNErrorMessage.Text = "Last name must contain letters only";
                }
            }
        }
        private bool CheckAllFields()
        {
            if(string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(UserNameTextBox.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(ConfirmPasswordTextBox.Text))
            {
                return false;
            }
            return true;
        }
        private bool CheckAge()
        {
            var birthDate = BirthDatePicker.Value;
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;

            if (currentDate.Month < birthDate.Month ||
                (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            return age>=21;
        }
    }
}

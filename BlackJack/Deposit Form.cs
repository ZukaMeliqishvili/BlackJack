using BlackJack.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Deposit_Form : Form
    {
        int userId;
        BlackJackContext context;
        public Deposit_Form(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            context = new BlackJackContext();
        }

        private void Deposit_Form_Load(object sender, EventArgs e)
        {

        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            decimal amount;
            bool b = decimal.TryParse(DepositTextBox.Text, out amount);
            if (!b)
            {
                MessageBox.Show("Enter Correct Amount");
                return;
            }
            if(amount<1)
            {
                MessageBox.Show("Minimum deposit amount is 1$");
                return;
            }
            if(amount>10000)
            {
                MessageBox.Show("Maximum deposit amount is 10000$");
                return;
            }
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            user.Balance += amount;
            context.SaveChanges();
            MessageBox.Show("Deposit was made successfully");
            this.Close();
        }
    }
}

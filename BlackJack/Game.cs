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
using Windows.ApplicationModel.UserActivities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BlackJack
{
    public partial class Game : Form
    {
        private Deposit_Form depositForm;
        private readonly int userId;
        User user;
        BlackJackContext context;
        public Button HitButton { get; private set; }
        public Button StandButton { get; private set; }
        private static TaskCompletionSource<string> playerDecisionTaskCompletionSource = new TaskCompletionSource<string>();

        public Game(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            context = new BlackJackContext();
            InitializeButtons();
        }
        private void InitializeButtons()
        {
            
            HitButton = new Button();
            HitButton.Text = "Hit";
            HitButton.Click += HitButton_Click;
            HitButton.Visible = false;
            HitButton.BackColor = Color.Green;
            HitButton.ForeColor = Color.Black;
            HitButton.Size = new Size(100, 40);
            HitButton.Location = new Point(450, 200);
            Controls.Add(HitButton);

            
            StandButton = new Button();
            StandButton.Text = "Stand";
            StandButton.Click += StandButton_Click;
            StandButton.Visible = false;
            StandButton.BackColor = Color.Red;
            StandButton.ForeColor = Color.Black;
            StandButton.Size = new Size(100, 40);
            StandButton.Location = new Point(550, 200);
            Controls.Add(StandButton);
        }

        private void HitButton_Click(object sender, EventArgs e)
        {
           
            playerDecisionTaskCompletionSource?.SetResult("Hit");

        }

        private void StandButton_Click(object sender, EventArgs e)
        {
            
            playerDecisionTaskCompletionSource?.SetResult("Stand");

        }
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Closed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            user = context.Users.FirstOrDefault(u => u.Id == userId);
            BalanceLabel.Text = String.Format("{0:N2}", user.Balance);
            UserNameLabel.Text = user.UserName;
            PlayerScoreLabel.Text = "";
            DealerScoreLabel.Text = "";
            //PlayerLabel.Hide();
            //DealerLabel.Hide();
        }

        private void BalanceLabel_Click(object sender, EventArgs e)
        {

        }
        private void depositForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReloadGameForm();
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            if (depositForm == null || depositForm.IsDisposed)
            {
                depositForm = new Deposit_Form(userId);
                depositForm.FormClosed += depositForm_FormClosed;
                depositForm.Show();
            }
        }
        private void ReloadGameForm()
        {
            user = context.Users.FirstOrDefault(u => u.Id == userId);
            context.Entry(user).Reload();
            BalanceLabel.Text = String.Format("{0:N2}", user.Balance);
            DepositButton.Show();
            PlayerScoreLabel.Text = "";
            DealerScoreLabel.Text = "";
            PlayerLabel.Hide();
            DealerLabel.Hide();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void BetButton_Click(object sender, EventArgs e)
        //{
        //    decimal bet = BetTextBox.Value;
        //    DepositButton.Hide();
        //    BlackJackGame.StartGame(bet, this);
        //}
        private void BetButton_Click(object sender, EventArgs e)
        {
            decimal bet = BetTextBox.Value;
            DepositButton.Hide();
            BlackJackGame.StartGame(bet, this);
        }
    }
}

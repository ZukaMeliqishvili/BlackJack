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
        public event EventHandler HitClicked;
        public event EventHandler StandClicked;
        private Deposit_Form depositForm;
        private readonly int userId;
        User user;
        BlackJackContext context;
        public Button HitButton { get; private set; }
        public Button StandButton { get; private set; }

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
            HitButton.Click += (sender, e) => HitClicked?.Invoke(this, EventArgs.Empty);
            HitButton.Visible = false;
            HitButton.BackColor = Color.Green;
            HitButton.ForeColor = Color.Black;
            HitButton.Size = new Size(100, 40);
            HitButton.Location = new Point(500, 300);
            Controls.Add(HitButton);

            
            StandButton = new Button();
            StandButton.Text = "Stand";
            StandButton.Click += (sender, e) => StandClicked?.Invoke(this, EventArgs.Empty);
            StandButton.Visible = false;
            StandButton.BackColor = Color.Red;
            StandButton.ForeColor = Color.Black;
            StandButton.Size = new Size(100, 40);
            StandButton.Location = new Point(600, 300);
            Controls.Add(StandButton);
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
            WinLabel.Hide();
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
            Thread.Sleep(5000);
            user = context.Users.FirstOrDefault(u => u.Id == userId);
            context.Entry(user).Reload();
            BalanceLabel.Text = String.Format("{0:N2}", user.Balance);
            DepositButton.Show();
            PlayerScoreLabel.Text = "";
            DealerScoreLabel.Text = "";
            RemoveImages();
            //WinLabel.Hide();
            BetButton.Show();
        }

        private void BetButton_Click(object sender, EventArgs e)
        {
            decimal bet = BetTextBox.Value;
            DepositButton.Hide();
            BlackJackGame game = new BlackJackGame(this,userId,bet);
            game.StartGame();

            ReloadGameForm();
        }
        private void RemoveImages()
        {
            List<PictureBox> pictureBoxesToRemove = new List<PictureBox>();

            // Find PictureBox controls to remove
            foreach (var control in Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    pictureBoxesToRemove.Add(pictureBox);
                }
            }

            foreach (var pictureBox in pictureBoxesToRemove)
            {
                Controls.Remove(pictureBox);
                pictureBox.Dispose();
            }
        }

        //public void ShowWinner(string winner, decimal amount)
        //{
        //    if (winner == "Player")
        //    {
        //        WinLabel.ForeColor = Color.Green;
        //        WinLabel.Text = $"Player wins {amount}";
        //    }
        //    else if (winner == "Dealer")
        //    {
        //        WinLabel.ForeColor = Color.Red;
        //        WinLabel.Text = $"Dealer wins {amount}";
        //    }
           
        //}
    }
}

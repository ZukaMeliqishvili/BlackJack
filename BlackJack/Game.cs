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
    public event EventHandler DoubleClicked;
    public event EventHandler InsuranceYesClicked;
    public event EventHandler InsuranceNoClicked;
    private Deposit_Form depositForm;
    private readonly int userId;
    User user;
    BlackJackContext context;
    public Button HitButton { get; private set; }
    public Button StandButton { get; private set; }
    public Button DoubleButton { get; private set; }
    public Button InsuranceYesButton { get; private set; }
    public Button InsuranceNoButton { get; private set; }

    public Game(int userId)
    {
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
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
      HitButton.Location = new Point(350, 250);
      Controls.Add(HitButton);

      StandButton = new Button();
      StandButton.Text = "Stand";
      StandButton.Click += (sender, e) => StandClicked?.Invoke(this, EventArgs.Empty);
      StandButton.Visible = false;
      StandButton.BackColor = Color.Red;
      StandButton.ForeColor = Color.Black;
      StandButton.Size = new Size(100, 40);
      StandButton.Location = new Point(450, 250);
      Controls.Add(StandButton);

      DoubleButton = new Button();
      DoubleButton.Text = "Double";
      DoubleButton.Click += (sender, e) => DoubleClicked?.Invoke(this, EventArgs.Empty);
      DoubleButton.Visible = false;
      DoubleButton.BackColor = Color.Yellow;
      DoubleButton.ForeColor = Color.Black;
      DoubleButton.Size = new Size(100, 40);
      DoubleButton.Location = new Point(550, 250);
      Controls.Add(DoubleButton);

      InsuranceYesButton = new Button();
      InsuranceYesButton.Text = "Insure bet";
      InsuranceYesButton.Click += (sender, e) => InsuranceYesClicked?.Invoke(this, EventArgs.Empty);
      InsuranceYesButton.Visible = false;
      InsuranceYesButton.BackColor = Color.ForestGreen;
      InsuranceYesButton.ForeColor = Color.Black;
      InsuranceYesButton.Size = new Size(100, 40);
      InsuranceYesButton.Location = new Point(375, 350);
      Controls.Add(InsuranceYesButton);

      InsuranceNoButton = new Button();
      InsuranceNoButton.Text = "Not insure bet";
      InsuranceNoButton.Click += (sender, e) => InsuranceNoClicked?.Invoke(this, EventArgs.Empty);
      InsuranceNoButton.Visible = false;
      InsuranceNoButton.BackColor = Color.Red;
      InsuranceNoButton.ForeColor = Color.Black;
      InsuranceNoButton.Size = new Size(100, 40);
      InsuranceNoButton.Location = new Point(500, 350);
      Controls.Add(InsuranceNoButton);

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
      //Thread.Sleep(5000);
      user = context.Users.FirstOrDefault(u => u.Id == userId);
      context.Entry(user).Reload();
      BalanceLabel.Text = String.Format("{0:N2}", user.Balance);
      DepositButton.Show();
      //PlayerScoreLabel.Text = "";
      //DealerScoreLabel.Text = "";
      //RemoveImages();
      //WinLabel.Hide();
      BetButton.Show();
    }

    private void BetButton_Click(object sender, EventArgs e)
    {
      decimal bet = BetTextBox.Value;
      DepositButton.Hide();
      if (bet > decimal.Parse(BalanceLabel.Text))
      {
        MessageBox.Show("You dont have enough funds");
        DepositButton.Show();
        return;
      }
      
      BetLabel.Text = bet.ToString();
      BlackJackGame game = new BlackJackGame(this, userId, bet,user.Balance.GetValueOrDefault());
      game.StartGame();
      ReloadGameForm();
    }

    public void RemoveImages()
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

    private void button1_Click(object sender, EventArgs e)
    {
      GameHistoryForm form = new GameHistoryForm(userId);
      form.Show();
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

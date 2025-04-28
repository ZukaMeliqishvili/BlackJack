namespace BlackJack
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      Label SideBetLabel;
      LogOutButton = new Button();
      MainBetLabel = new Label();
      label1 = new Label();
      BalanceLabel = new Label();
      DepositButton = new Button();
      BetButton = new Button();
      BetTextBox = new NumericUpDown();
      DealerLabel = new Label();
      PlayerLabel = new Label();
      DealerScoreLabel = new Label();
      PlayerScoreLabel = new Label();
      WinLabel = new Label();
      button1 = new Button();
      label2 = new Label();
      BetLabel = new Label();
      BonusBetUpAndDown = new NumericUpDown();
      label3 = new Label();
      SideBetAmountLabel = new Label();
      SideBetWinLabel = new Label();
      SideBetLabel = new Label();
      ((System.ComponentModel.ISupportInitialize)BetTextBox).BeginInit();
      ((System.ComponentModel.ISupportInitialize)BonusBetUpAndDown).BeginInit();
      SuspendLayout();
      // 
      // SideBetLabel
      // 
      SideBetLabel.AutoSize = true;
      SideBetLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
      SideBetLabel.Location = new Point(396, 485);
      SideBetLabel.Name = "SideBetLabel";
      SideBetLabel.Size = new Size(72, 21);
      SideBetLabel.TabIndex = 16;
      SideBetLabel.Text = "Side Bet";
      // 
      // LogOutButton
      // 
      LogOutButton.BackColor = Color.Red;
      LogOutButton.BackgroundImageLayout = ImageLayout.None;
      LogOutButton.Cursor = Cursors.Hand;
      LogOutButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      LogOutButton.Location = new Point(1012, 470);
      LogOutButton.Margin = new Padding(3, 2, 3, 2);
      LogOutButton.Name = "LogOutButton";
      LogOutButton.Size = new Size(119, 34);
      LogOutButton.TabIndex = 1;
      LogOutButton.Text = "Log Out";
      LogOutButton.UseVisualStyleBackColor = false;
      LogOutButton.Click += LogOutButton_Click;
      // 
      // MainBetLabel
      // 
      MainBetLabel.AutoSize = true;
      MainBetLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
      MainBetLabel.Location = new Point(396, 456);
      MainBetLabel.Name = "MainBetLabel";
      MainBetLabel.Size = new Size(78, 21);
      MainBetLabel.TabIndex = 2;
      MainBetLabel.Text = "Main Bet";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      label1.Location = new Point(1, 453);
      label1.Name = "label1";
      label1.Size = new Size(65, 19);
      label1.TabIndex = 3;
      label1.Text = "Balance:";
      // 
      // BalanceLabel
      // 
      BalanceLabel.AutoSize = true;
      BalanceLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      BalanceLabel.ForeColor = Color.Green;
      BalanceLabel.Location = new Point(73, 456);
      BalanceLabel.Name = "BalanceLabel";
      BalanceLabel.Size = new Size(50, 19);
      BalanceLabel.TabIndex = 4;
      BalanceLabel.Text = "label2";
      BalanceLabel.Click += BalanceLabel_Click;
      // 
      // DepositButton
      // 
      DepositButton.BackColor = Color.FromArgb(0, 192, 0);
      DepositButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      DepositButton.ForeColor = Color.Black;
      DepositButton.Location = new Point(1012, 431);
      DepositButton.Margin = new Padding(3, 2, 3, 2);
      DepositButton.Name = "DepositButton";
      DepositButton.Size = new Size(119, 34);
      DepositButton.TabIndex = 5;
      DepositButton.Text = "Add Balance";
      DepositButton.UseVisualStyleBackColor = false;
      DepositButton.Click += DepositButton_Click;
      // 
      // BetButton
      // 
      BetButton.BackColor = Color.Green;
      BetButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      BetButton.Location = new Point(480, 518);
      BetButton.Margin = new Padding(3, 2, 3, 2);
      BetButton.Name = "BetButton";
      BetButton.Size = new Size(131, 26);
      BetButton.TabIndex = 6;
      BetButton.Text = "Make Bet";
      BetButton.UseVisualStyleBackColor = false;
      BetButton.Click += BetButton_Click;
      // 
      // BetTextBox
      // 
      BetTextBox.DecimalPlaces = 2;
      BetTextBox.Location = new Point(480, 453);
      BetTextBox.Margin = new Padding(3, 2, 3, 2);
      BetTextBox.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
      BetTextBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      BetTextBox.Name = "BetTextBox";
      BetTextBox.Size = new Size(131, 23);
      BetTextBox.TabIndex = 7;
      BetTextBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
      // 
      // DealerLabel
      // 
      DealerLabel.AutoSize = true;
      DealerLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
      DealerLabel.Location = new Point(438, 7);
      DealerLabel.Name = "DealerLabel";
      DealerLabel.Size = new Size(156, 30);
      DealerLabel.TabIndex = 8;
      DealerLabel.Text = "Dealer's score";
      // 
      // PlayerLabel
      // 
      PlayerLabel.AutoSize = true;
      PlayerLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
      PlayerLabel.Location = new Point(440, 407);
      PlayerLabel.Name = "PlayerLabel";
      PlayerLabel.Size = new Size(154, 30);
      PlayerLabel.TabIndex = 9;
      PlayerLabel.Text = "Player's score";
      // 
      // DealerScoreLabel
      // 
      DealerScoreLabel.AutoSize = true;
      DealerScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
      DealerScoreLabel.ForeColor = Color.Red;
      DealerScoreLabel.Location = new Point(616, 14);
      DealerScoreLabel.Name = "DealerScoreLabel";
      DealerScoreLabel.Size = new Size(57, 21);
      DealerScoreLabel.TabIndex = 10;
      DealerScoreLabel.Text = "label3";
      // 
      // PlayerScoreLabel
      // 
      PlayerScoreLabel.AutoSize = true;
      PlayerScoreLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
      PlayerScoreLabel.ForeColor = Color.FromArgb(0, 192, 0);
      PlayerScoreLabel.Location = new Point(600, 414);
      PlayerScoreLabel.Name = "PlayerScoreLabel";
      PlayerScoreLabel.Size = new Size(57, 21);
      PlayerScoreLabel.TabIndex = 11;
      PlayerScoreLabel.Text = "label4";
      // 
      // WinLabel
      // 
      WinLabel.AutoSize = true;
      WinLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
      WinLabel.Location = new Point(475, 203);
      WinLabel.Name = "WinLabel";
      WinLabel.Size = new Size(76, 30);
      WinLabel.TabIndex = 12;
      WinLabel.Text = "label2";
      // 
      // button1
      // 
      button1.BackColor = Color.Yellow;
      button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      button1.Location = new Point(1012, 27);
      button1.Margin = new Padding(3, 2, 3, 2);
      button1.Name = "button1";
      button1.Size = new Size(119, 33);
      button1.TabIndex = 13;
      button1.Text = "Game History";
      button1.UseVisualStyleBackColor = false;
      button1.Click += button1_Click;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      label2.Location = new Point(1, 485);
      label2.Name = "label2";
      label2.Size = new Size(72, 19);
      label2.TabIndex = 14;
      label2.Text = "Main Bet:";
      // 
      // BetLabel
      // 
      BetLabel.AutoSize = true;
      BetLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      BetLabel.ForeColor = Color.Green;
      BetLabel.Location = new Point(73, 485);
      BetLabel.Name = "BetLabel";
      BetLabel.Size = new Size(0, 19);
      BetLabel.TabIndex = 15;
      // 
      // BonusBetUpAndDown
      // 
      BonusBetUpAndDown.DecimalPlaces = 2;
      BonusBetUpAndDown.Location = new Point(480, 486);
      BonusBetUpAndDown.Margin = new Padding(3, 2, 3, 2);
      BonusBetUpAndDown.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
      BonusBetUpAndDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      BonusBetUpAndDown.Name = "BonusBetUpAndDown";
      BonusBetUpAndDown.Size = new Size(131, 23);
      BonusBetUpAndDown.TabIndex = 17;
      BonusBetUpAndDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      label3.Location = new Point(1, 518);
      label3.Name = "label3";
      label3.Size = new Size(68, 19);
      label3.TabIndex = 18;
      label3.Text = "Side Bet:";
      // 
      // SideBetAmountLabel
      // 
      SideBetAmountLabel.AutoSize = true;
      SideBetAmountLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      SideBetAmountLabel.ForeColor = Color.Green;
      SideBetAmountLabel.Location = new Point(73, 518);
      SideBetAmountLabel.Name = "SideBetAmountLabel";
      SideBetAmountLabel.Size = new Size(0, 19);
      SideBetAmountLabel.TabIndex = 19;
      // 
      // SideBetWinLabel
      // 
      SideBetWinLabel.AutoSize = true;
      SideBetWinLabel.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold, GraphicsUnit.Point);
      SideBetWinLabel.ForeColor = Color.Lime;
      SideBetWinLabel.Location = new Point(28, 69);
      SideBetWinLabel.Name = "SideBetWinLabel";
      SideBetWinLabel.Size = new Size(116, 23);
      SideBetWinLabel.TabIndex = 20;
      SideBetWinLabel.Text = "SIde bet win ";
      // 
      // Game
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.LightSteelBlue;
      ClientSize = new Size(1130, 733);
      Controls.Add(SideBetWinLabel);
      Controls.Add(SideBetAmountLabel);
      Controls.Add(label3);
      Controls.Add(BonusBetUpAndDown);
      Controls.Add(SideBetLabel);
      Controls.Add(BetLabel);
      Controls.Add(label2);
      Controls.Add(button1);
      Controls.Add(WinLabel);
      Controls.Add(PlayerScoreLabel);
      Controls.Add(DealerScoreLabel);
      Controls.Add(PlayerLabel);
      Controls.Add(DealerLabel);
      Controls.Add(BetTextBox);
      Controls.Add(BetButton);
      Controls.Add(DepositButton);
      Controls.Add(BalanceLabel);
      Controls.Add(label1);
      Controls.Add(MainBetLabel);
      Controls.Add(LogOutButton);
      Margin = new Padding(3, 2, 3, 2);
      Name = "Game";
      Text = "Game";
      Load += Game_Load;
      ((System.ComponentModel.ISupportInitialize)BetTextBox).EndInit();
      ((System.ComponentModel.ISupportInitialize)BonusBetUpAndDown).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Button LogOutButton;
        private Label MainBetLabel;
        private Label label1;
        public Label BalanceLabel;
        private Button DepositButton;
        public Button BetButton;
        private NumericUpDown BetTextBox;
        private Label DealerLabel;
        private Label PlayerLabel;
        public Label DealerScoreLabel;
        public Label PlayerScoreLabel;
        public Label WinLabel;
        private Button button1;
    private Label label2;
    public Label BetLabel;
    private NumericUpDown BonusBetUpAndDown;
    private Label label3;
    public Label SideBetAmountLabel;
    public Label SideBetWinLabel;
  }
}
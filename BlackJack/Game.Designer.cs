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
            LogOutButton = new Button();
            UserNameLabel = new Label();
            label1 = new Label();
            BalanceLabel = new Label();
            DepositButton = new Button();
            BetButton = new Button();
            BetTextBox = new NumericUpDown();
            DealerLabel = new Label();
            PlayerLabel = new Label();
            DealerScoreLabel = new Label();
            PlayerScoreLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)BetTextBox).BeginInit();
            SuspendLayout();
            // 
            // LogOutButton
            // 
            LogOutButton.BackColor = Color.Red;
            LogOutButton.BackgroundImageLayout = ImageLayout.None;
            LogOutButton.Cursor = Cursors.Hand;
            LogOutButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            LogOutButton.Location = new Point(1051, 530);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(136, 46);
            LogOutButton.TabIndex = 1;
            LogOutButton.Text = "Log Out";
            LogOutButton.UseVisualStyleBackColor = false;
            LogOutButton.Click += LogOutButton_Click;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            UserNameLabel.Location = new Point(12, 463);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(70, 28);
            UserNameLabel.TabIndex = 2;
            UserNameLabel.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 509);
            label1.Name = "label1";
            label1.Size = new Size(76, 23);
            label1.TabIndex = 3;
            label1.Text = "Balance:";
            // 
            // BalanceLabel
            // 
            BalanceLabel.AutoSize = true;
            BalanceLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            BalanceLabel.ForeColor = Color.Green;
            BalanceLabel.Location = new Point(81, 509);
            BalanceLabel.Name = "BalanceLabel";
            BalanceLabel.Size = new Size(59, 23);
            BalanceLabel.TabIndex = 4;
            BalanceLabel.Text = "label2";
            BalanceLabel.Click += BalanceLabel_Click;
            // 
            // DepositButton
            // 
            DepositButton.BackColor = Color.FromArgb(0, 192, 0);
            DepositButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            DepositButton.ForeColor = Color.Black;
            DepositButton.Location = new Point(1051, 479);
            DepositButton.Name = "DepositButton";
            DepositButton.Size = new Size(136, 45);
            DepositButton.TabIndex = 5;
            DepositButton.Text = "Add Balance";
            DepositButton.UseVisualStyleBackColor = false;
            DepositButton.Click += DepositButton_Click;
            // 
            // BetButton
            // 
            BetButton.Location = new Point(448, 530);
            BetButton.Name = "BetButton";
            BetButton.Size = new Size(150, 35);
            BetButton.TabIndex = 6;
            BetButton.Text = "Make Bet";
            BetButton.UseVisualStyleBackColor = true;
            BetButton.Click += BetButton_Click;
            // 
            // BetTextBox
            // 
            BetTextBox.DecimalPlaces = 2;
            BetTextBox.Location = new Point(448, 497);
            BetTextBox.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            BetTextBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            BetTextBox.Name = "BetTextBox";
            BetTextBox.Size = new Size(150, 27);
            BetTextBox.TabIndex = 7;
            BetTextBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DealerLabel
            // 
            DealerLabel.AutoSize = true;
            DealerLabel.Location = new Point(497, 22);
            DealerLabel.Name = "DealerLabel";
            DealerLabel.Size = new Size(53, 20);
            DealerLabel.TabIndex = 8;
            DealerLabel.Text = "Dealer";
            // 
            // PlayerLabel
            // 
            PlayerLabel.AutoSize = true;
            PlayerLabel.Location = new Point(500, 407);
            PlayerLabel.Name = "PlayerLabel";
            PlayerLabel.Size = new Size(49, 20);
            PlayerLabel.TabIndex = 9;
            PlayerLabel.Text = "Player";
            // 
            // DealerScoreLabel
            // 
            DealerScoreLabel.AutoSize = true;
            DealerScoreLabel.ForeColor = SystemColors.ActiveCaptionText;
            DealerScoreLabel.Location = new Point(548, 55);
            DealerScoreLabel.Name = "DealerScoreLabel";
            DealerScoreLabel.Size = new Size(50, 20);
            DealerScoreLabel.TabIndex = 10;
            DealerScoreLabel.Text = "label3";
            // 
            // PlayerScoreLabel
            // 
            PlayerScoreLabel.AutoSize = true;
            PlayerScoreLabel.ForeColor = Color.Black;
            PlayerScoreLabel.Location = new Point(548, 366);
            PlayerScoreLabel.Name = "PlayerScoreLabel";
            PlayerScoreLabel.Size = new Size(50, 20);
            PlayerScoreLabel.TabIndex = 11;
            PlayerScoreLabel.Text = "label4";
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 577);
            Controls.Add(PlayerScoreLabel);
            Controls.Add(DealerScoreLabel);
            Controls.Add(PlayerLabel);
            Controls.Add(DealerLabel);
            Controls.Add(BetTextBox);
            Controls.Add(BetButton);
            Controls.Add(DepositButton);
            Controls.Add(BalanceLabel);
            Controls.Add(label1);
            Controls.Add(UserNameLabel);
            Controls.Add(LogOutButton);
            Name = "Game";
            Text = "Game";
            Load += Game_Load;
            ((System.ComponentModel.ISupportInitialize)BetTextBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button LogOutButton;
        private Label UserNameLabel;
        private Label label1;
        private Label BalanceLabel;
        private Button DepositButton;
        private Button BetButton;
        private NumericUpDown BetTextBox;
        private Label DealerLabel;
        private Label PlayerLabel;
        public Label DealerScoreLabel;
        public Label PlayerScoreLabel;
    }
}
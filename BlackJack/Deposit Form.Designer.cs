namespace BlackJack
{
    partial class Deposit_Form
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
            DepositTextBox = new TextBox();
            DepositButton = new Button();
            SuspendLayout();
            // 
            // DepositTextBox
            // 
            DepositTextBox.Location = new Point(129, 90);
            DepositTextBox.Name = "DepositTextBox";
            DepositTextBox.Size = new Size(182, 27);
            DepositTextBox.TabIndex = 0;
            // 
            // DepositButton
            // 
            DepositButton.BackColor = Color.FromArgb(0, 192, 0);
            DepositButton.ForeColor = Color.Black;
            DepositButton.Location = new Point(150, 123);
            DepositButton.Name = "DepositButton";
            DepositButton.Size = new Size(135, 43);
            DepositButton.TabIndex = 1;
            DepositButton.Text = "Make Deposit";
            DepositButton.UseVisualStyleBackColor = false;
            DepositButton.Click += DepositButton_Click;
            // 
            // Deposit_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 374);
            Controls.Add(DepositButton);
            Controls.Add(DepositTextBox);
            Name = "Deposit_Form";
            Text = "Deposit_Form";
            Load += Deposit_Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox DepositTextBox;
        private Button DepositButton;
    }
}
namespace BlackJack
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UserNameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            LogInButton = new Button();
            RegistrationButton = new Button();
            SuspendLayout();
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(229, 124);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(191, 27);
            UserNameTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(229, 169);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(191, 27);
            PasswordTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(275, 57);
            label1.Name = "label1";
            label1.Size = new Size(81, 31);
            label1.TabIndex = 2;
            label1.Text = "Log In";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(114, 124);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 3;
            label2.Text = "User Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(114, 172);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(106, 276);
            label4.Name = "label4";
            label4.Size = new Size(250, 20);
            label4.TabIndex = 5;
            label4.Text = "Don't have account? create new user";
            // 
            // LogInButton
            // 
            LogInButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LogInButton.Location = new Point(262, 223);
            LogInButton.Name = "LogInButton";
            LogInButton.Size = new Size(109, 30);
            LogInButton.TabIndex = 6;
            LogInButton.Text = "Log In";
            LogInButton.UseVisualStyleBackColor = true;
            LogInButton.Click += LogInButton_Click;
            // 
            // RegistrationButton
            // 
            RegistrationButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            RegistrationButton.Location = new Point(114, 317);
            RegistrationButton.Name = "RegistrationButton";
            RegistrationButton.Size = new Size(216, 34);
            RegistrationButton.TabIndex = 7;
            RegistrationButton.Text = "Register User";
            RegistrationButton.UseVisualStyleBackColor = true;
            RegistrationButton.Click += RegistrationButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 414);
            Controls.Add(RegistrationButton);
            Controls.Add(LogInButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordTextBox);
            Controls.Add(UserNameTextBox);
            Name = "LoginForm";
            Text = "Log In";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UserNameTextBox;
        private TextBox PasswordTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button LogInButton;
        private Button RegistrationButton;
    }
}

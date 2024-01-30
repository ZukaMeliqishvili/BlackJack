namespace BlackJack
{
    partial class RegistrationForm
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
            FirstNameTextBox = new TextBox();
            LastNameTextBox = new TextBox();
            UserNameTextBox = new TextBox();
            EmailTextBox = new TextBox();
            BirthDatePicker = new DateTimePicker();
            PasswordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label5 = new Label();
            FNErrorMessage = new Label();
            LNErrorMessage = new Label();
            PasswordErrorMessage = new Label();
            label7 = new Label();
            OpenLogInForm = new Button();
            RegisterButton = new Button();
            label8 = new Label();
            ConfirmPasswordTextBox = new TextBox();
            ConfirmPasswordErrorMessage = new Label();
            SuspendLayout();
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.Location = new Point(251, 45);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.Size = new Size(269, 27);
            FirstNameTextBox.TabIndex = 0;
            FirstNameTextBox.TextChanged += FirstNameTextBox_TextChanged;
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.Location = new Point(251, 90);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new Size(269, 27);
            LastNameTextBox.TabIndex = 1;
            LastNameTextBox.TextChanged += LastNameTextBox_TextChanged;
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(251, 175);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(269, 27);
            UserNameTextBox.TabIndex = 2;
            UserNameTextBox.TextChanged += UserNameTextBox_TextChanged;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(251, 220);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(269, 27);
            EmailTextBox.TabIndex = 3;
            EmailTextBox.TextChanged += EmailTextBox_TextChanged;
            // 
            // BirthDatePicker
            // 
            BirthDatePicker.Location = new Point(251, 133);
            BirthDatePicker.Name = "BirthDatePicker";
            BirthDatePicker.Size = new Size(269, 27);
            BirthDatePicker.TabIndex = 4;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(251, 266);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(269, 27);
            PasswordTextBox.TabIndex = 5;
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(42, 48);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 6;
            label1.Text = "First name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(42, 97);
            label2.Name = "label2";
            label2.Size = new Size(98, 25);
            label2.TabIndex = 7;
            label2.Text = "Last name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(42, 133);
            label3.Name = "label3";
            label3.Size = new Size(122, 25);
            label3.TabIndex = 8;
            label3.Text = "Date of birth";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(42, 175);
            label4.Name = "label4";
            label4.Size = new Size(97, 25);
            label4.TabIndex = 9;
            label4.Text = "Username";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(42, 269);
            label6.Name = "label6";
            label6.Size = new Size(92, 25);
            label6.TabIndex = 11;
            label6.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(42, 223);
            label5.Name = "label5";
            label5.Size = new Size(58, 25);
            label5.TabIndex = 12;
            label5.Text = "Email";
            // 
            // FNErrorMessage
            // 
            FNErrorMessage.AutoSize = true;
            FNErrorMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FNErrorMessage.ForeColor = Color.Red;
            FNErrorMessage.Location = new Point(553, 45);
            FNErrorMessage.Name = "FNErrorMessage";
            FNErrorMessage.Size = new Size(51, 20);
            FNErrorMessage.TabIndex = 14;
            FNErrorMessage.Text = "label7";
            // 
            // LNErrorMessage
            // 
            LNErrorMessage.AutoSize = true;
            LNErrorMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LNErrorMessage.ForeColor = Color.Red;
            LNErrorMessage.Location = new Point(553, 97);
            LNErrorMessage.Name = "LNErrorMessage";
            LNErrorMessage.Size = new Size(51, 20);
            LNErrorMessage.TabIndex = 15;
            LNErrorMessage.Text = "label8";
            // 
            // PasswordErrorMessage
            // 
            PasswordErrorMessage.AutoSize = true;
            PasswordErrorMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            PasswordErrorMessage.ForeColor = Color.Red;
            PasswordErrorMessage.Location = new Point(553, 274);
            PasswordErrorMessage.Name = "PasswordErrorMessage";
            PasswordErrorMessage.Size = new Size(51, 20);
            PasswordErrorMessage.TabIndex = 16;
            PasswordErrorMessage.Text = "label9";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(42, 468);
            label7.Name = "label7";
            label7.Size = new Size(187, 23);
            label7.TabIndex = 17;
            label7.Text = "Already have account?";
            // 
            // OpenLogInForm
            // 
            OpenLogInForm.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            OpenLogInForm.Location = new Point(267, 462);
            OpenLogInForm.Name = "OpenLogInForm";
            OpenLogInForm.Size = new Size(94, 29);
            OpenLogInForm.TabIndex = 18;
            OpenLogInForm.Text = "Log In";
            OpenLogInForm.UseVisualStyleBackColor = true;
            OpenLogInForm.Click += OpenLogInForm_Click;
            // 
            // RegisterButton
            // 
            RegisterButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            RegisterButton.Location = new Point(287, 387);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(170, 42);
            RegisterButton.TabIndex = 19;
            RegisterButton.Text = "Register User";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(42, 324);
            label8.Name = "label8";
            label8.Size = new Size(165, 25);
            label8.TabIndex = 20;
            label8.Text = "Confirm Password";
            // 
            // ConfirmPasswordTextBox
            // 
            ConfirmPasswordTextBox.Location = new Point(251, 317);
            ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            ConfirmPasswordTextBox.PasswordChar = '*';
            ConfirmPasswordTextBox.Size = new Size(269, 27);
            ConfirmPasswordTextBox.TabIndex = 21;
            ConfirmPasswordTextBox.TextChanged += ConfirmPasswordTextBox_TextChanged;
            // 
            // ConfirmPasswordErrorMessage
            // 
            ConfirmPasswordErrorMessage.AutoSize = true;
            ConfirmPasswordErrorMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ConfirmPasswordErrorMessage.ForeColor = Color.Red;
            ConfirmPasswordErrorMessage.Location = new Point(556, 325);
            ConfirmPasswordErrorMessage.Name = "ConfirmPasswordErrorMessage";
            ConfirmPasswordErrorMessage.Size = new Size(51, 20);
            ConfirmPasswordErrorMessage.TabIndex = 22;
            ConfirmPasswordErrorMessage.Text = "label9";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 532);
            Controls.Add(ConfirmPasswordErrorMessage);
            Controls.Add(ConfirmPasswordTextBox);
            Controls.Add(label8);
            Controls.Add(RegisterButton);
            Controls.Add(OpenLogInForm);
            Controls.Add(label7);
            Controls.Add(PasswordErrorMessage);
            Controls.Add(LNErrorMessage);
            Controls.Add(FNErrorMessage);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordTextBox);
            Controls.Add(BirthDatePicker);
            Controls.Add(EmailTextBox);
            Controls.Add(UserNameTextBox);
            Controls.Add(LastNameTextBox);
            Controls.Add(FirstNameTextBox);
            Name = "RegistrationForm";
            Text = "Register User";
            Load += RegistrationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FirstNameTextBox;
        private TextBox LastNameTextBox;
        private TextBox UserNameTextBox;
        private TextBox EmailTextBox;
        private DateTimePicker BirthDatePicker;
        private TextBox PasswordTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label5;
        private Label FNErrorMessage;
        private Label LNErrorMessage;
        private Label PasswordErrorMessage;
        private Label label7;
        private Button OpenLogInForm;
        private Button RegisterButton;
        private Label label8;
        private TextBox ConfirmPasswordTextBox;
        private Label ConfirmPasswordErrorMessage;
    }
}
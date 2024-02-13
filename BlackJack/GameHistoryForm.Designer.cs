namespace BlackJack
{
    partial class GameHistoryForm
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
            components = new System.ComponentModel.Container();
            dataGridView = new DataGridView();
            gameHistoryDtoBindingSource = new BindingSource(components);
            playerScoreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dealeScoreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            betDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            payoutDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gameHistoryDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { playerScoreDataGridViewTextBoxColumn, dealeScoreDataGridViewTextBoxColumn, betDataGridViewTextBoxColumn, payoutDataGridViewTextBoxColumn });
            dataGridView.DataSource = gameHistoryDtoBindingSource;
            dataGridView.Location = new Point(-8, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(570, 423);
            dataGridView.TabIndex = 0;
            // 
            // gameHistoryDtoBindingSource
            // 
            gameHistoryDtoBindingSource.DataSource = typeof(Dto.GameHistoryDto);
            // 
            // playerScoreDataGridViewTextBoxColumn
            // 
            playerScoreDataGridViewTextBoxColumn.DataPropertyName = "PlayerScore";
            playerScoreDataGridViewTextBoxColumn.HeaderText = "Player Score";
            playerScoreDataGridViewTextBoxColumn.MinimumWidth = 6;
            playerScoreDataGridViewTextBoxColumn.Name = "playerScoreDataGridViewTextBoxColumn";
            playerScoreDataGridViewTextBoxColumn.ReadOnly = true;
            playerScoreDataGridViewTextBoxColumn.Width = 125;
            // 
            // dealeScoreDataGridViewTextBoxColumn
            // 
            dealeScoreDataGridViewTextBoxColumn.DataPropertyName = "DealerScore";
            dealeScoreDataGridViewTextBoxColumn.HeaderText = "Dealer Score";
            dealeScoreDataGridViewTextBoxColumn.MinimumWidth = 6;
            dealeScoreDataGridViewTextBoxColumn.Name = "dealeScoreDataGridViewTextBoxColumn";
            dealeScoreDataGridViewTextBoxColumn.ReadOnly = true;
            dealeScoreDataGridViewTextBoxColumn.Width = 125;
            // 
            // betDataGridViewTextBoxColumn
            // 
            betDataGridViewTextBoxColumn.DataPropertyName = "Bet";
            betDataGridViewTextBoxColumn.HeaderText = "Bet";
            betDataGridViewTextBoxColumn.MinimumWidth = 6;
            betDataGridViewTextBoxColumn.Name = "betDataGridViewTextBoxColumn";
            betDataGridViewTextBoxColumn.ReadOnly = true;
            betDataGridViewTextBoxColumn.Width = 125;
            // 
            // payoutDataGridViewTextBoxColumn
            // 
            payoutDataGridViewTextBoxColumn.DataPropertyName = "Payout";
            payoutDataGridViewTextBoxColumn.HeaderText = "Payout";
            payoutDataGridViewTextBoxColumn.MinimumWidth = 6;
            payoutDataGridViewTextBoxColumn.Name = "payoutDataGridViewTextBoxColumn";
            payoutDataGridViewTextBoxColumn.ReadOnly = true;
            payoutDataGridViewTextBoxColumn.Width = 125;
            // 
            // GameHistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 436);
            Controls.Add(dataGridView);
            Name = "GameHistoryForm";
            Text = "GameHistoryForm";
            Load += GameHistoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)gameHistoryDtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private BindingSource gameHistoryDtoBindingSource;
        private DataGridViewTextBoxColumn playerScoreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dealeScoreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn betDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn payoutDataGridViewTextBoxColumn;
    }
}
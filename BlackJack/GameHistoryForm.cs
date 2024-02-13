using BlackJack.DbModels;
using BlackJack.Dto;
using Mapster;
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
    public partial class GameHistoryForm : Form
    {
        private int userId { get; set; }
        private BlackJackContext context {  get; set; }
        public GameHistoryForm(int userId)
        {
            context = new BlackJackContext();
            this.userId = userId;
            InitializeComponent();
        }

        private void GameHistoryForm_Load(object sender, EventArgs e)
        {
            List<GameHistoryDto> data = new  List<GameHistoryDto>();
            var gameHistory = context.GameHistories.Where(x=>x.UserId == userId).ToList();
            data = gameHistory.Adapt<List<GameHistoryDto>>();
            dataGridView.Columns[2].DefaultCellStyle.Format = "N2";
            dataGridView.Columns[3].DefaultCellStyle.Format = "N2";
            dataGridView.DataSource = data;
        }
    }
}

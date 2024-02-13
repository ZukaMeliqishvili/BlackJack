using System;
using System.Collections.Generic;

namespace BlackJack.DbModels
{
    public partial class GameHistory
    {
        public int Id { get; set; }
        public string PlayerScore { get; set; } = null!;
        public string DealerScore { get; set; } = null!;
        public decimal Bet { get; set; }
        public decimal Payout { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}

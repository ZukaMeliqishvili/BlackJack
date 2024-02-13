using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Dto
{
    public class GameHistoryDto
    {
        public string PlayerScore { get; set; }
        public string DealerScore {  get; set; }
        public decimal Bet {  get; set; }
        public decimal Payout { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
  public class Player
  {
    public int Id { get; set; }
    public int PlayerScore { get; set; }
    public bool PlayerHasBJ { get; set; }
    public List<Card> Cards { get; set; } = new List<Card>();
    public decimal Bet;
    public int AceCount { get; set; }
    public string Winner { get; set; } = "tie";
    public decimal Payout { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
  public class Card:IComparable
  {
    public char CardId { get; set; }
    public char Suite { get; set; }
    public int CompareTo(object? obj)
    {
      Dictionary<char, int> cardOrder = new Dictionary<char, int>()
      {
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { 't', 10 },
        { 'j', 11 },
        { 'q', 12 },
        { 'k', 13 },
        { 'a', 14 }
      };

      Card c = (Card)obj;
      if (cardOrder[this.CardId] > cardOrder[c.CardId])
      {
        return 1;
      }

      if (cardOrder[this.CardId] > cardOrder[c.CardId])
      {
        return -1;
      }

      return 0;
    }

  }
}

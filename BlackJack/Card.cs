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
      Card c = (Card)obj;
      if (CardOrder[this.CardId] > CardOrder[c.CardId])
      {
        return 1;
      }

      if (CardOrder[this.CardId] > CardOrder[c.CardId])
      {
        return -1;
      }

      return 0;
    }

    public static Dictionary<char, int> CardOrder { get; set; } = new Dictionary<char, int>()
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

    public static Dictionary<char, int> CardValues { get; set; } = new Dictionary<char, int>()
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
      { 'j', 10 },
      { 'q', 10 },
      { 'k', 10 },
      { 'a', 14 }
    };

    public override string ToString()
    {
      return string.Concat(CardId,Suite);
    }
  }
}

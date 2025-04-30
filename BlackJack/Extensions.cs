using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
  public static class Extensions
  {
    public static bool IsMatchedByCardId(this IEnumerable<Card> cards)
    {
      var cardList = cards.ToList();
      if (cardList.Count == 0)
      {
        return false;
      }

      if (cardList.Count == 1)
      {
        return true;
      }

      for (int i = 0; i < cardList.Count - 1; ++i)
      {
        if (cardList[i].CardId != cardList[i + 1].CardId)
        {
          return false;
        }
      }
      return true;
    }

    public static bool IsMatchedByCardSuite(this IEnumerable<Card> cards)
    {
      var cardList = cards.ToList();
      if (cardList.Count == 0)
      {
        return false;
      }

      if (cardList.Count == 1)
      {
        return true;
      }

      for (int i = 0; i < cardList.Count - 1; ++i)
      {
        if (cardList[i].Suite != cardList[i + 1].Suite)
        {
          return false;
        }
      }
      return true;
    }

    public static bool IsStraight(this IEnumerable<Card> cards)
    {
      var cardList = cards.ToList();
      cardList.Sort();
      Dictionary<char, int> cardOrder = Card.CardOrder;

      bool isSequential = true;
      for (int i = 0; i < cardList.Count - 1; ++i)
      {
        if ((cardOrder[cardList[i].CardId] + 1) != cardOrder[cardList[i + 1].CardId])
        {
          isSequential = false;
        }
      }

      if (isSequential == true)
      {
        return true;
      }

      if (cardList[cardList.Count - 1].CardId == 'a')
      {
        if (cardList[0].CardId == 2)
        {
          return true;
        }
      }

      return false;
    }
  }
}

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
      bool isSequential = true;
      for (int i =0; i<cardList.Count-1;++i)
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

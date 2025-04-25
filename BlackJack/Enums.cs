using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
  public enum BlackJackBonusType
  {
    Suited_Trips = 100,
    Straight_Flush = 40,
    Three_of_a_kind = 30,
    Straight = 10,
    Flush = 5,
    No_Bonus = 0
  }
}

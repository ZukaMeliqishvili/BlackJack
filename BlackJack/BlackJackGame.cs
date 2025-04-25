using BlackJack.DbModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Devices.HumanInterfaceDevice;
using Windows.UI.Input.Inking.Analysis;

namespace BlackJack
{
  public class BlackJackGame
  {
    static List<string> cards;
    static int counter = 0;
    private Game gameForm;
    private int playerScore = 0;
    private int dealerScore = 0;
    private readonly Random r = new Random();
    private bool playerDecisionMade = false;
    private string playerDecision = "";
    private int playerCardCount = 0;
    private int dealerCardCount = 0;
    private string winner = "Tie";
    private BlackJackContext context;
    private int playerAceCount = 0;
    private int dealerAceCount = 0;
    private decimal bet;
    private bool playerWinsWithBlackJack = false;
    private int userId;
    private static bool needsShuffle = false;
    private static int cuttingCardPosition = 0;
    private bool RequestInsurance = false;
    private bool IsInsured = false;
    public decimal insuranceBet = 0;
    private decimal UserBalance = 0;

    static BlackJackGame()
    {
      cards = new List<string>();
      InitializeCards();
    }

    public BlackJackGame(Game form, int userId, decimal bet, decimal userBalance)
    {
      this.bet = bet;
      gameForm = form;
      this.userId = userId;
      UserBalance = userBalance;
      InitializeButtons();
      context = new BlackJackContext();
      MakeTransfer(-bet);
    }

    private static void InitializeCards()
    {
      cards.Clear();
      string[] suite = new string[4] { "h", "c", "d", "s" };
      string[] number = new string[13]
      {
        "a", "2", "3", "4", "5", "6", "7", "8", "9", "t",
        "j", "q", "k"
      };
      for (int i = 1; i <= 6; ++i)
      {
        for (int j = 0; j < suite.Length; ++j)
        {
          for (int k = 0; k < number.Length; ++k)
          {
            string s = number[k] + suite[j];
            cards.Add(s);
          }
        }
      }

      counter = 0;
      Random r = new Random();
      cuttingCardPosition = r.Next(90, 150);
    }

    private void InitializeButtons()
    {
      gameForm.HitClicked += (sender, e) =>
      {
        playerDecision = "Hit";
        playerDecisionMade = true;
      };

      gameForm.StandClicked += (sender, e) =>
      {
        playerDecision = "Stand";
        playerDecisionMade = true;
      };

      gameForm.DoubleClicked += (sender, e) =>
      {
        playerDecision = "Double";
        playerDecisionMade = true;
      };

      gameForm.InsuranceYesClicked += (sender, e) =>
      {
        IsInsured = true;
        RequestInsurance = false;
        playerDecisionMade = true;
        gameForm.InsuranceYesButton.Visible=false;
        gameForm.InsuranceNoButton.Visible=false;
      };

      gameForm.InsuranceNoClicked += (sender, e) =>
      {
        RequestInsurance = false;
        gameForm.InsuranceYesButton.Visible = false;
        gameForm.InsuranceNoButton.Visible = false;
      };
    }

    public void StartGame()
    {
      gameForm.BetButton.Hide();
      gameForm.WinLabel.Hide();
      decimal amount = decimal.Parse(gameForm.BalanceLabel.Text);
      gameForm.RemoveImages();
      gameForm.PlayerScoreLabel.Text = "";
      gameForm.DealerScoreLabel.Text = "";
      gameForm.BalanceLabel.Text = (amount - bet).ToString();
      DealCards();
      StartGamingProcess();
      Pay();
      if (counter >= 180)
      {
        InitializeCards();
      }
    }

    private void DecisionMade(string decision)
    {
      int index = r.Next(0, 312 - counter);
      string card = cards[index];
      switch (decision)
      {
        case "Hit":

          gameForm.HitButton.Visible = false;
          gameForm.StandButton.Visible = false;
          gameForm.DoubleButton.Visible= false;
          Thread.Sleep(TimeSpan.FromSeconds(1));
          ++playerCardCount;
          SendPlayerScore(card);
          cards.RemoveAt(index);
          sendPlayersCard(card);
          counter++;
          break;
        case "Double":
          gameForm.HitButton.Visible = false;
          gameForm.StandButton.Visible = false;
          gameForm.DoubleButton.Visible = false;
          Thread.Sleep(TimeSpan.FromSeconds(1));
          ++playerCardCount;
          SendPlayerScore(card);
          cards.RemoveAt(index);
          sendPlayersCard(card);
          counter++;
          break;
      }

    }

    public void StartGamingProcess()
    {
      while (playerScore < 21)
      {
        gameForm.HitButton.Visible = true;
        gameForm.StandButton.Visible = true;
        if (playerCardCount <= 2)
        {
          gameForm.DoubleButton.Visible = true;
        }

        while (!playerDecisionMade)
        {
          Application.DoEvents();
        }

        playerDecisionMade = false;
        if (playerDecision == "Hit")
        {
          DecisionMade("Hit");
          Thread.Sleep(TimeSpan.FromSeconds(0.5));
        }
        else if (playerDecision == "Double")
        {
          MakeTransfer(-bet);
          if (UserBalance - bet < 0)
          {
            MessageBox.Show("Not enogh funds");
            continue;
          }
          bet *= 2;
          gameForm.BetLabel.Text = bet.ToString();
          gameForm.BalanceLabel.Text = UserBalance.ToString();
          DecisionMade("Double");
          Thread.Sleep(TimeSpan.FromSeconds(0.5));
          break;
        }
        else if (playerDecision == "Stand")
        {
          break;
        }
        gameForm.DoubleButton.Visible=false;
        gameForm.HitButton.Visible = false;
        gameForm.StandButton.Visible = false;
      }

      if (playerScore > 21)
      {
        winner = "Dealer";
        return;
      }

      gameForm.DoubleButton.Visible = false;
      gameForm.HitButton.Visible = false;
      gameForm.StandButton.Visible = false;
      scanDealerCards();
      DetermineWinner();
    }

    private void scanDealerCards()
    {
      while (dealerScore < 17)
      {
        if (gameForm.PlayerScoreLabel.Text == "BJ" && (dealerScore != 10 && dealerScore != 11))
        {
          winner = "Player";
          playerWinsWithBlackJack = true;
          break;
        }

        int index = r.Next(0, 312 - counter);
        string card = cards[index];
        ++dealerCardCount;
        SendDealerScore(card);
        cards.RemoveAt(index);
        counter++;
        sendDealersCard(card);
      }
    }

    private void checkForBonus(Card[] cards)
    {
      BlackJackBonusType bonus = DetermineBonusCombination(cards);
    }

    private BlackJackBonusType DetermineBonusCombination(Card [] cards)
    {
      bool isThreeOfAKind = cards.IsMatchedByCardId();
      bool isFlush = cards.IsMatchedByCardSuite();
      bool isStraight = cards.IsStraight();
      //card example "ad" first char stands for A second char stands for Diamonds
      if (isThreeOfAKind && isFlush)
      {
        return BlackJackBonusType.Suited_Trips;
      }

      if (isStraight && isFlush)
      {
        return BlackJackBonusType.Straight_Flush;
      }

      if (isThreeOfAKind)
      {
        return BlackJackBonusType.Three_of_a_kind;
      }

      if (isStraight)
      {
        return BlackJackBonusType.Straight;
      }

      if (isFlush)
      {
        return BlackJackBonusType.Flush;
      }

      return BlackJackBonusType.No_Bonus;


    }
    
    private void DetermineWinner()
    {
      bool dealerHasBJ = gameForm.DealerScoreLabel.Text == "BJ";
      bool playerHasBJ = gameForm.PlayerScoreLabel.Text == "BJ";
      if (playerHasBJ && !dealerHasBJ)
      {
        winner = "Player";
        playerWinsWithBlackJack = true;
        return;
      }
      
      if (dealerHasBJ && !playerHasBJ)
      {
        if (IsInsured)
        {
          return;
        }
        winner = "Dealer";
        return;
      }

      if (dealerScore > 21)
      {
        winner = "Player";
        return;
      }

      if (playerScore > dealerScore)
      {
        winner = "Player";
      }
      else if (dealerScore > playerScore)
      {
        winner = "Dealer";
      }

      if (cards.Count <= cuttingCardPosition)
      {
        needsShuffle = true;
      }
    }

    private void AskForInsurance()
    {
      RequestInsurance = true;
      gameForm.InsuranceYesButton.Visible = true;
      gameForm.InsuranceNoButton.Visible = true;
      while (RequestInsurance)
      {
        Application.DoEvents();
      }

      if (IsInsured)
      {
        if (UserBalance - insuranceBet < 0)
        {
          MessageBox.Show("You don't have enough funds to insure your bet");
          IsInsured = false;
        }
        insuranceBet = bet / 2;
        MakeTransfer(-insuranceBet);
        gameForm.BetLabel.Text = (bet+insuranceBet).ToString();
        gameForm.BalanceLabel.Text = UserBalance.ToString();
      }
    }
    private void MakeTransfer(decimal amount)
    {
      var user = context.Users.SingleOrDefault(x => x.Id == userId);
      UserBalance += amount;
      user.Balance = UserBalance;
      context.SaveChanges();
    }
    private void Pay()
    {
      decimal payout = bet;
      if (winner == "Player")
      {
        if (playerWinsWithBlackJack)
        {
          payout = payout * (decimal)1.5;
        }
        MakeTransfer(payout+bet);
        gameForm.WinLabel.ForeColor = Color.Green;
        decimal winamount = payout + bet;
        gameForm.WinLabel.Text = $"Player wins {winamount}";
        //gameForm.ShowWinner("Player", payout + bet);
        gameForm.WinLabel.Show();

      }
      else if (winner == "Dealer")
      {
        bet += insuranceBet;
        gameForm.WinLabel.ForeColor = Color.Red;
        gameForm.WinLabel.Text = $"Dealer wins {bet}";
        //gameForm.ShowWinner("Dealer", bet);
        gameForm.WinLabel.Show();
      }
      else
      {
        if (IsInsured && gameForm.DealerScoreLabel.Text == "BJ")
        {
          MakeTransfer(bet+insuranceBet);
        }
        gameForm.WinLabel.ForeColor = Color.Green;
        gameForm.WinLabel.Text = $"Player wins {bet}";
        MakeTransfer(bet);
        gameForm.WinLabel.Show();
      }

      GameHistory gameHistory = new GameHistory()
      {
        PlayerScore = gameForm.PlayerScoreLabel.Text,
        DealerScore = gameForm.DealerScoreLabel.Text,
        Bet = bet,
        Payout = payout,
        UserId = userId
      };
      Task.Run(() => CreateRoundHistory(gameHistory));
      //CreateRoundHistory(gameHistory);
    }

    private void CreateRoundHistory(GameHistory gameHistory)
    {
      context.GameHistories.Add(gameHistory);
      context.SaveChanges();
    }

    private void DealCards()
    {
      if (needsShuffle)
      {
        InitializeCards();
      }

      Card [] bonusCards = new Card[3];

      int index = r.Next(0, 312 - counter - 1);
      string card = cards[index];
      bonusCards[0] = new Card()
      {
        CardId = card[0],
        Suite = card[1]
      };
      ++playerCardCount;
      SendPlayerScore(card);
      cards.RemoveAt(index);
      sendPlayersCard(card);
      counter++;

      card = cards[r.Next(0, 312 - counter - 1)];
      ++dealerCardCount;
      SendDealerScore(card);
      cards.RemoveAt(index);
      sendDealersCard(card);
      counter++;
      bonusCards[1] = new Card()
      {
        CardId = card[0],
        Suite = card[1]
      };

      card = cards[r.Next(0, 312 - counter - 1)];
      ++playerCardCount;
      SendPlayerScore(card);
      cards.RemoveAt(index);
      sendPlayersCard(card);
      counter++;
      bonusCards[2] = new Card()
      {
        CardId = card[0],
        Suite = card[1]
      };

      if (gameForm.PlayerScoreLabel.Text != "BJ" && gameForm.DealerScoreLabel.Text == "1/11")
      {
        AskForInsurance();
      }
    }

    private void sendPlayersCard(string card)
    {
      PictureBox pictureBox = new PictureBox();

      pictureBox.Location = new Point(400 + (60 * playerCardCount), 510);
      pictureBox.Size = new Size(60, 120);
      string currentDirectory = Directory.GetCurrentDirectory();
      string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
      string imagePath = Path.Combine(projectDirectory, "Resources", "Cards", $"{card}.jpg");

      if (File.Exists(imagePath))
      {

        pictureBox.Image = Image.FromFile(imagePath);
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        gameForm.Controls.Add(pictureBox);
      }
    }

    private void sendDealersCard(string card)
    {
      PictureBox pictureBox = new PictureBox();

      pictureBox.Location = new Point(400 + (60 * dealerCardCount), 80);
      pictureBox.Size = new Size(60, 120);
      string currentDirectory = Directory.GetCurrentDirectory();
      string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
      string imagePath = Path.Combine(projectDirectory, "Resources", "Cards", $"{card}.jpg");

      if (File.Exists(imagePath))
      {

        pictureBox.Image = Image.FromFile(imagePath);
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        gameForm.Controls.Add(pictureBox);
      }
    }

    private void SendPlayerScore(string card)
    {
      Thread.Sleep(TimeSpan.FromSeconds(1));
      char c = card[0];
      if (c == 't' || c == 'j' || c == 'q' || c == 'k')
      {
        playerScore += 10;
      }
      else if (c == 'a')
      {
        playerAceCount++;
        playerScore += 11;
      }
      else
      {
        playerScore += int.Parse(c.ToString());
      }

      if (playerScore > 21 && playerAceCount > 0)
      {
        playerScore -= 10;
        playerAceCount--;
      }

      if (playerScore == 21 && playerCardCount == 2)
      {
        //gameForm.PlayerScoreLabel.Text = "BJ";
        gameForm.Invoke(() => gameForm.PlayerScoreLabel.Text = "BJ");
      }
      else
      {
        string scoreLabel;
        if (playerAceCount > 0)
        {
          scoreLabel = (playerScore - 10).ToString() + "/" + playerScore;
        }
        else
        {
          scoreLabel = playerScore.ToString();
        }

        //gameForm.PlayerScoreLabel.Text = playerScore.ToString();
        gameForm.Invoke(() => gameForm.PlayerScoreLabel.Text = scoreLabel);
      }

      gameForm.Refresh();

    }

    private void SendDealerScore(string card)
    {
      Thread.Sleep(TimeSpan.FromSeconds(1));
      char c = card[0];
      if (c == 't' || c == 'j' || c == 'q' || c == 'k')
      {
        dealerScore += 10;
      }
      else if (c == 'a')
      {
        dealerAceCount++;
        dealerScore += 11;
      }
      else
      {
        dealerScore += int.Parse(c.ToString());
      }

      if (dealerScore > 21 && dealerAceCount > 0)
      {
        dealerScore -= 10;
        dealerAceCount--;
      }

      if (dealerScore == 21 && dealerCardCount == 2)
      {
        //gameForm.DealerScoreLabel.Text = "BJ";
        gameForm.Invoke(() => gameForm.DealerScoreLabel.Text = "BJ");
      }
      else
      {
        string scoreLabel;
        if (dealerAceCount > 0)
        {
          scoreLabel = (dealerScore - 10).ToString() + "/" + dealerScore;
        }
        else
        {
          scoreLabel = dealerScore.ToString();
        }

        //gameForm.DealerScoreLabel.Text = dealerScore.ToString();
        gameForm.Invoke(() => gameForm.DealerScoreLabel.Text = scoreLabel);
      }

      gameForm.Refresh();
    }
  }
}

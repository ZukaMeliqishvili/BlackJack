using BlackJack.DbModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
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
    private List<Player> Players = new List<Player>();
    private int dealerScore = 0;
    private readonly Random r = new Random();
    private bool playerDecisionMade = false;
    private string playerDecision = "";
    private int dealerCardCount = 0;
    private BlackJackContext context;
    private int dealerAceCount = 0;
    private bool playerWinsWithBlackJack = false;
    private int userId;
    private static bool needsShuffle = false;
    private static int cuttingCardPosition = 0;
    private bool RequestInsurance = false;
    private bool IsInsured = false;
    public decimal insuranceBet = 0;
    private decimal UserBalance = 0;
    public decimal BonusBet = 0;
    private bool IsSplited = false;
    private int HighlightedLabel = 0;
    private List<PictureBox> CardPictures = new List<PictureBox>();

    static BlackJackGame()
    {
      cards = new List<string>();
      InitializeCards();
    }

    public BlackJackGame(Game form, int userId, decimal bet, decimal bonusBet, decimal userBalance)
    {
      Players.Add(new Player
      {
        Id = 1,
        Bet = bet
      });
      gameForm = form;
      gameForm.PlayerScoreLabel.Visible = true;
      gameForm.Player1ScoreLabel.Visible = false;
      gameForm.Player2ScoreLabel.Visible = false;
      this.userId = userId;
      UserBalance = userBalance;
      InitializeButtons();
      context = new BlackJackContext();
      this.BonusBet = bonusBet;
      MakeTransfer(-bet);
      MakeTransfer(-bonusBet);
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

      gameForm.SplitClicked += (sender, e) =>
      {
        playerDecision = "Split";
        playerDecisionMade = true;
      };

      gameForm.InsuranceYesClicked += (sender, e) =>
      {
        IsInsured = true;
        RequestInsurance = false;
        playerDecisionMade = true;
        gameForm.InsuranceYesButton.Visible = false;
        gameForm.InsuranceNoButton.Visible = false;
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
      gameForm.SideBetWinLabel.Hide();
      gameForm.RemoveImages();
      gameForm.PlayerScoreLabel.Text = "";
      gameForm.DealerScoreLabel.Text = "";
      gameForm.BalanceLabel.Text = UserBalance.ToString();
      gameForm.Player1ScoreLabel.Text = "";
      gameForm.Player2ScoreLabel.Text = "";
      DealCards();
      StartGamingProcess();
      Pay();
      //if (counter >= 180)
      //{
      //  InitializeCards();
      //}
    }

    private void DecisionMade(string decision, int playerId)
    {
      Player player = Players.First(x => x.Id == playerId);
      string card = GetCard();
      switch (decision)
      {
        case "Hit":

          gameForm.HitButton.Visible = false;
          gameForm.StandButton.Visible = false;
          gameForm.DoubleButton.Visible = false;
          Thread.Sleep(TimeSpan.FromSeconds(1));
          SendPlayerScore(card, playerId);
          sendPlayersCard(card, playerId);
          break;
        case "Double":
          gameForm.HitButton.Visible = false;
          gameForm.StandButton.Visible = false;
          gameForm.DoubleButton.Visible = false;
          Thread.Sleep(TimeSpan.FromSeconds(1));
          SendPlayerScore(card, playerId);
          sendPlayersCard(card, playerId);
          break;
      }

    }

    public void StartGamingProcess()
    {
      for (int i = 0; i<Players.Count; i++)
      {
        CheckForHiglight(i);
        while (Players[i].PlayerScore < 21)
        {
          gameForm.HitButton.Visible = true;
          gameForm.StandButton.Visible = true;
          if (Players[i].Cards.Count <= 2)
          {
            gameForm.DoubleButton.Visible = true;
          }

          if (IsSplited == false && CheckPlayerSplitOptions(Players[i].Cards))
          {
            gameForm.SplitButton.Visible = true;
          }

          while (!playerDecisionMade)
          {
            Application.DoEvents();
          }

          playerDecisionMade = false;
          if (playerDecision == "Hit")
          {
            DecisionMade("Hit", Players[i].Id);
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
          }
          else if (playerDecision == "Double")
          {
            if (UserBalance - Players[i].Bet < 0)
            {
              MessageBox.Show("Not enogh funds");
              continue;
            }

            MakeTransfer(-Players[i].Bet);
            Players[i].Bet *= 2;
            gameForm.BalanceLabel.Text = UserBalance.ToString();
            DecisionMade("Double", Players[i].Id);
            UpdateBetLabel();
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            break;
          }
          else if (playerDecision == "Split")
          {
            if (UserBalance - Players[i].Bet < 0)
            {
              MessageBox.Show("Not enogh funds");
              continue;
            }

            gameForm.PlayerScoreLabel.Visible = false;
            MakeTransfer(-Players[i].Bet);
            gameForm.BalanceLabel.Text = UserBalance.ToString();
            gameForm.SplitButton.Visible = false;
            IsSplited = true;
            Players[i].Bet *= 2;
            UpdateBetLabel();
            MakeSplit();
            return;
          }
          else if (playerDecision == "Stand")
          {
            break;
          }

          if (Players[i].PlayerScore > 21)
          {
            Players[i].Winner = "Dealer";
          }
          gameForm.DoubleButton.Visible = false;
          gameForm.HitButton.Visible = false;
          gameForm.StandButton.Visible = false;
          gameForm.SplitButton.Visible = false;
        }

      }

      if (Players.Count() == Players.Count(x => x.Winner == "Dealer"))
      {
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
          Players[0].Winner = "Player";
          Players[0].PlayerHasBJ = true;
          break;
        }

        string card = GetCard();
        ++dealerCardCount;
        SendDealerScore(card);
        sendDealersCard(card);
      }
    }

    private void checkForBonus(Card[] cards)
    {
      BlackJackBonusType bonus = DetermineBonusCombination(cards);
      if (bonus == BlackJackBonusType.No_Bonus)
      {
        return;
      }

      int mult = (int)bonus;
      string WinningCombination = bonus.ToString().Replace('_', ' ');
      MakeTransfer(BonusBet * mult);
      gameForm.SideBetWinLabel.Text = $"Congratulation \nyou win {(mult * BonusBet)} \nby {WinningCombination}";
      gameForm.SideBetWinLabel.Visible = true;
      gameForm.BalanceLabel.Text = UserBalance.ToString();
    }

    private BlackJackBonusType DetermineBonusCombination(Card[] cards)
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
      foreach (var player in Players)
      {
        bool dealerHasBJ = gameForm.DealerScoreLabel.Text == "BJ";
        if (player.PlayerHasBJ && !dealerHasBJ)
        {
          player.Winner = "Player";
          playerWinsWithBlackJack = true;
          return;
        }

        if (dealerHasBJ && !player.PlayerHasBJ)
        {
          if (IsInsured)
          {
            return;
          }

          player.Winner = "Dealer";
          return;
        }

        if (dealerScore > 21)
        {
          player.Winner = "Player";
          return;
        }

        if (player.PlayerScore > dealerScore)
        {
          player.Winner = "Player";
        }
        else if (dealerScore > player.PlayerScore)
        {
          player.Winner = "Dealer";
        }

        if (cards.Count <= cuttingCardPosition)
        {
          needsShuffle = true;
        }
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

      Player player = Players.First();
      if (IsInsured)
      {
        if (UserBalance - insuranceBet < 0)
        {
          MessageBox.Show("You don't have enough funds to insure your bet");
          IsInsured = false;
        }

        insuranceBet = player.Bet / 2;
        MakeTransfer(-insuranceBet);
        UpdateBetLabel();
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
      decimal winamount = 0;
      foreach (var player in Players)
      {
        decimal payout = player.Bet;
        if (player.Winner == "Player")
        {
          if (player.PlayerHasBJ)
          {
            payout = payout * (decimal)1.5;
          }

          MakeTransfer(payout + player.Bet);
          winamount = payout + player.Bet;
          //gameForm.ShowWinner("Player", payout + bet);
          gameForm.WinLabel.Show();
          player.Payout = payout;
        }
        else if (player.Winner == "Dealer")
        {
          player.Bet += insuranceBet;
        }
        else
        {
          //If bet is insured loop will perform only once
          if (IsInsured && gameForm.DealerScoreLabel.Text == "BJ" && player.PlayerScore <=21)
          {
            MakeTransfer(player.Bet + insuranceBet);
          }

          gameForm.WinLabel.ForeColor = Color.Green;
          gameForm.WinLabel.Text = $"Player wins {player.Bet}";
          MakeTransfer(player.Bet);
          gameForm.WinLabel.Show();
          player.Payout = payout;
        }

      }

      decimal totalBet = Players.Sum(x => x.Bet) + insuranceBet;
      if (Players.Exists(x => x.Winner == "Player") && winamount >= totalBet)
      {
        gameForm.WinLabel.ForeColor = Color.Green;
        gameForm.WinLabel.Text = $"Player wins {winamount}";
        gameForm.WinLabel.Show();
      }
      else
      {
        gameForm.WinLabel.ForeColor = Color.Red;
        gameForm.WinLabel.Text = $"Dealer wins {totalBet}";
        //gameForm.ShowWinner("Dealer", bet);
        gameForm.WinLabel.Show();
      }

      GameHistory gameHistory = new GameHistory()
      {
        PlayerScore = gameForm.PlayerScoreLabel.Text,
        DealerScore = gameForm.DealerScoreLabel.Text,
        Bet = Players.Sum(x => x.Bet),
        Payout = Players.Sum(x => x.Payout),
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

    private string GetCard()
    {
      int index = r.Next(0,312-counter-1);
      string card = cards[index];
      cards.RemoveAt(index);
      ++counter;
      return card;
    }
    private void DealCards()
    {
      if (needsShuffle)
      {
        InitializeCards();
      }

      Card[] bonusCards = new Card[3];
      Player player = Players.First();
      string card = GetCard();
      bonusCards[0] = new Card()
      {
        CardId = card[0],
        Suite = card[1]
      };
      SendPlayerScore(card, player.Id);
      sendPlayersCard(card, 1);

      card = GetCard();
      ++dealerCardCount;
      sendDealersCard(card);
      SendDealerScore(card);
      bonusCards[1] = new Card()
      {
        CardId = card[0],
        Suite = card[1]
      };

      card = GetCard();
      sendPlayersCard(card, 1);
      SendPlayerScore(card, player.Id);
      
      bonusCards[2] = new Card()
      {
        CardId = card[0],
        Suite = card[1]
      };

      if (gameForm.PlayerScoreLabel.Text != "BJ" && gameForm.DealerScoreLabel.Text == "1/11")
      {
        AskForInsurance();
      }

      if (BonusBet > 0)
      {
        checkForBonus(bonusCards);
      }

    }

    private void sendPlayersCard(string card, int playerId)
    {
      Player player = Players.First(x => x.Id == playerId);
      PictureBox pictureBox = new PictureBox();
      player.Cards.Add(new Card()
      {
        CardId = card[0],
        Suite = card[1]
      });
      if (!IsSplited)
      {
        pictureBox.Location = new Point(400 + (60 * player.Cards.Count), 570);
      }
      else
      {
        if (player.Id == 1)
        {
          pictureBox.Location = new Point(200 + (60 * player.Cards.Count), 570);
        }
        else
        {
          pictureBox.Location = new Point(600 + (60 * player.Cards.Count), 570);
        }
      }

      pictureBox.Size = new Size(60, 120);
      string currentDirectory = Directory.GetCurrentDirectory();
      string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
      string imagePath = Path.Combine(projectDirectory, "Resources", "Cards", $"{card}.jpg");
     
      CardPictures.Add(pictureBox);
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

    private void SendPlayerScore(string card, int playerId)
    {
      Player player = Players.First(x => x.Id == playerId);
      Thread.Sleep(TimeSpan.FromSeconds(1));
      char c = card[0];
      if (c == 't' || c == 'j' || c == 'q' || c == 'k')
      {
        player.PlayerScore += 10;
      }
      else if (c == 'a')
      {
        player.AceCount++;
        player.PlayerScore += 11;
      }
      else
      {
        player.PlayerScore += int.Parse(c.ToString());
      }

      if (player.PlayerScore > 21 && player.AceCount > 0)
      {
        player.PlayerScore -= 10;
        player.AceCount--;
      }

      if (player.PlayerScore == 21 && player.Cards.Count == 2 && !IsSplited)
      {
        //gameForm.PlayerScoreLabel.Text = "BJ";
        gameForm.Invoke(() => gameForm.PlayerScoreLabel.Text = "BJ");
        player.PlayerHasBJ = true;

      }
      else
      {
        string scoreLabel;
        if (player.AceCount > 0)
        {
          scoreLabel = (player.PlayerScore - 10).ToString() + "/" + player.PlayerScore;
        }
        else
        {
          scoreLabel = player.PlayerScore.ToString();
        }

        //gameForm.PlayerScoreLabel.Text = playerScore.ToString();
        if (!IsSplited)
        {
          gameForm.Invoke(() => gameForm.PlayerScoreLabel.Text = scoreLabel);
        }
        else
        {
          if (player.Id == 1)
          {
            gameForm.Invoke(() => gameForm.Player1ScoreLabel.Text = scoreLabel);
          }
          else
          {
            gameForm.Invoke(() => gameForm.Player2ScoreLabel.Text = scoreLabel);
          }
        }

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

    private bool CheckPlayerSplitOptions(List<Card> cards)
    {
      var cardValues = Card.CardValues;
      if (cardValues[cards[0].CardId] == cardValues[cards[1].CardId] && cards.Count == 2)
      {
        return true;
      }

      return false;
    }

    private void MakeSplit()
    {
      Player player1 = Players.First();
      player1.Bet /= 2;
      Player player2 = new Player()
      {
        Id = 2,
        Bet = player1.Bet/2,
        AceCount = player1.AceCount / 2,
        PlayerScore = 0,
      };

      player1.AceCount = 0;
      player1.PlayerScore = 0;
      Players.Add(player2);
      gameForm.PlayerScoreLabel.Visible = false;
      RearrangeCardsAndScoreAfterSplit();
      StartGamingProcess();
    }

    private void RearrangeCardsAndScoreAfterSplit()
    {
      
      List<Card> tempCards = Players[0].Cards.ToList();
      Players[0].Cards.Clear();
      foreach (var picture in CardPictures)
      {
        gameForm.Controls.Remove(picture);
      }
      for(int i = 0; i<Players.Count; ++i)
      {
        SendPlayerScore(tempCards[i].ToString(), Players[i].Id);
        sendPlayersCard(tempCards[i].ToString(), Players[i].Id);
      }

      gameForm.Player1ScoreLabel.Visible = true;
      gameForm.Player2ScoreLabel.Visible = true;
      tempCards.Clear();
      string card1 = GetCard();
      string card2 = GetCard();
      tempCards.Add(new Card()
      {
        CardId = card1[0],
        Suite = card1[1]
      });
      tempCards.Add(new Card()
      {
        CardId = card2[0],
        Suite = card2[1]
      });

      for (int i = 0; i < Players.Count; ++i)
      {
        SendPlayerScore(tempCards[i].ToString(), Players[i].Id);
        sendPlayersCard(tempCards[i].ToString(), Players[i].Id);
      }

    }
    private void UpdateBetLabel()
    {
      gameForm.BetLabel.Text = (Players.Sum(x => x.Bet) + insuranceBet).ToString();
    }

    private void CheckForHiglight(int playerId)
    {
      if (IsSplited)
      {
        if (playerId == 0 && HighlightedLabel!=1)
        {
          gameForm.Player1ScoreLabel.ForeColor = Color.Yellow;
          gameForm.Player2ScoreLabel.ForeColor = Color.Green;
        }
        else if (playerId == 1 && HighlightedLabel != 2)
        {
          gameForm.Player2ScoreLabel.ForeColor = Color.Yellow;
          gameForm.Player1ScoreLabel.ForeColor = Color.Green;
        }
      }
    }
  }
}

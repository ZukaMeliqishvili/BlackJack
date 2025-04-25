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

    static BlackJackGame()
    {
      cards = new List<string>();
      InitializeCards();
    }

    public BlackJackGame(Game form, int userId, decimal bet)
    {
      this.bet = bet;
      gameForm = form;
      this.userId = userId;
      InitializeButtons();
      context = new BlackJackContext();
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

    public void StartGamingProcess()
    {
      while (playerScore < 21)
      {
        gameForm.HitButton.Visible = true;
        gameForm.StandButton.Visible = true;

        while (!playerDecisionMade)
        {
          Application.DoEvents();
        }

        playerDecisionMade = false;
        if (playerDecision == "Hit")
        {
          int index = r.Next(0, 312 - counter);
          string card = cards[index];
          gameForm.HitButton.Visible = false;
          gameForm.StandButton.Visible = false;
          Thread.Sleep(TimeSpan.FromSeconds(1));
          ++playerCardCount;
          SendPlayerScore(card);
          cards.RemoveAt(index);
          sendPlayersCard(card);
          counter++;

          Thread.Sleep(TimeSpan.FromSeconds(0.5));
        }
        else if (playerDecision == "Stand")
        {
          break;
        }

        gameForm.HitButton.Visible = false;
        gameForm.StandButton.Visible = false;
      }

      if (playerScore > 21)
      {
        winner = "Dealer";
        return;
      }

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

    private void Pay()
    {
      decimal payout = bet;
      var user = context.Users.SingleOrDefault(x => x.Id == userId);
      if (winner == "Player")
      {
        if (playerWinsWithBlackJack)
        {
          payout = payout * (decimal)1.5;
        }

        user.Balance += payout;
        gameForm.WinLabel.ForeColor = Color.Green;
        decimal winamount = payout + bet;
        gameForm.WinLabel.Text = $"Player wins {winamount}";
        //gameForm.ShowWinner("Player", payout + bet);
        gameForm.WinLabel.Show();
        context.SaveChanges();

      }
      else if (winner == "Dealer")
      {
        payout *= -1;
        user.Balance += payout;
        gameForm.WinLabel.ForeColor = Color.Red;
        gameForm.WinLabel.Text = $"Dealer wins {bet}";
        //gameForm.ShowWinner("Dealer", bet);
        gameForm.WinLabel.Show();
        payout = 0;
        context.SaveChanges();
      }
      else
      {
        gameForm.WinLabel.ForeColor = Color.Green;
        gameForm.WinLabel.Text = $"Player wins {bet}";
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

      int index = r.Next(0, 312 - counter);
      string card = cards[index];
      ++playerCardCount;
      SendPlayerScore(card);
      cards.RemoveAt(index);
      sendPlayersCard(card);
      counter++;
      card = cards[r.Next(0, 312 - counter)];
      ++dealerCardCount;
      SendDealerScore(card);
      cards.RemoveAt(index);
      sendDealersCard(card);
      counter++;
      card = cards[r.Next(0, 312 - counter)];
      ++playerCardCount;
      SendPlayerScore(card);
      cards.RemoveAt(index);
      sendPlayersCard(card);
      counter++;
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

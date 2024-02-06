using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.VoiceCommands;
using Windows.UI.Input.Inking.Analysis;

namespace BlackJack
{
    static class BlackJackGame
    {
        private static TaskCompletionSource<string> playerDecisionTaskCompletionSource;
        static List<string> cards;
        static int counter = 0;
        private static Game gameForm;
        private static bool shuffle;
        private static int playerScore = 0;
        private static int dealerScore = 0;
        private static Random r = new Random();
        static BlackJackGame()
        {
            cards = new List<string>();
            InitializeCards();
        }
        public static void InitializeCards()
        {
            cards.Clear();
            string[] suite = new string[4] { "h", "c", "d", "s" };
            string[] number = new string[13] {"a","2","3","4","5","6","7","8","9","t",
                "j","q","k"};
            for (int i = 1; i <= 6; ++i)
            {
                for (int j = 0; j < suite.Length; ++j)
                {
                    for (int k = 0; k < number.Length; ++k)
                    {
                        string s =number[k] + suite[j];
                        cards.Add(s);
                    }
                }
            }
            //cards.Add("cut");
            //cards.Insert(155, "cut");
            counter = 0;
        }
        public static void StartGame(decimal bet, Game form)
        {
            gameForm = form;
            DealCards();
            StartGamingProcess().GetAwaiter();
        }
        //private static void StartGamingProcess()
        //{
        //    while(playerScore<21)
        //    {
        //        //ask player for decision
        //    }

        //}
        public static async Task StartGamingProcess()
        {
            while (playerScore < 21)
            {
                gameForm.HitButton.Visible = true;
                gameForm.StandButton.Visible = true;
                string decision = await WaitForPlayerDecision();
                if (decision == "Hit")
                {
                    int index = r.Next(0, 312 - counter);
                    string card = cards[index];
                    SendPlayerScore(card);
                    cards.RemoveAt(index);
                    counter++;
                }
                else if (decision == "Stand")
                {
                    break;
                }
            }
            gameForm.HitButton.Visible = false;
            gameForm.StandButton.Visible = false;
            scanDealerCards();
        }
        private static void scanDealerCards()
        {
            while(dealerScore<17)
            {
                int index = r.Next(0, 312 - counter);
                string card = cards[index];
                SendDealerScore(card);
                cards.RemoveAt(index);
                counter++;
            }
        }
        private static async Task<string> WaitForPlayerDecision()
        {
            var tcs = new TaskCompletionSource<string>();
            playerDecisionTaskCompletionSource = new TaskCompletionSource<string>(); 
            gameForm.HitButton.Click += (sender, e) =>
            {
                playerDecisionTaskCompletionSource.SetResult("Hit");
            };

            gameForm.StandButton.Click += (sender, e) =>
            {
                playerDecisionTaskCompletionSource.SetResult("Stand");
            };

            return await playerDecisionTaskCompletionSource.Task;
        }
        private static void DealCards()
        {
            int index = r.Next(0, 312 - counter);
            string card = cards[index];
            SendPlayerScore(card);
            cards.RemoveAt(index);
            counter++;
            card = cards[r.Next(0, 312 - counter)];
            SendDealerScore(card);
            cards.RemoveAt(index);
            counter++;
            card = cards[r.Next(0, 312 - counter)];
            SendPlayerScore(card);
            cards.RemoveAt(index);
            counter++;
        }
        private static void SendPlayerScore(string card)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            if(card == "cut")
            {
                shuffle = true;
                return;
            }
            char c = card[0];
            if (c == 't' || c == 'j' || c == 'q' || c == 'k')
            {
                playerScore += 10;
            }
            else if (c == 'a')
            {
                if(playerScore > 10)
                {
                    playerScore += 1;
                }
                else
                {
                    playerScore += 11;
                }
            }
            else
            {
                playerScore += int.Parse(c.ToString());
            }
            if(playerScore == 21)
            {
                gameForm.PlayerScoreLabel.Text = "BJ";
            }
            else
            {
                gameForm.PlayerScoreLabel.Text = playerScore.ToString();
            }
            
            gameForm.Refresh();
        }
        private static void SendDealerScore(string card)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            if (card == "cut")
            {
                shuffle = true;
                return;
            }
            char c = card[0];
            if (c == 't' || c == 'j' || c == 'q' || c == 'k')
            {
                dealerScore += 10;
            }
            else if (c == 'a')
            {
                if (dealerScore > 10)
                {
                    dealerScore += 1;
                }
                else
                {
                    dealerScore += 11;
                }
            }
            else
            {
                dealerScore += int.Parse(c.ToString());
            }
            if(dealerScore == 21)
            {
                gameForm.DealerScoreLabel.Text = "BJ";
            }
            else
            {
                gameForm.DealerScoreLabel.Text = dealerScore.ToString();
            }
            
            gameForm.Refresh();
        }
    }
}

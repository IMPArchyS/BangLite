using BangLite.Cards;
using BangLite.Cards.Blue;
using BangLite.Decks;
using BangLite.Utils;

namespace BangLite.Players
{
    public class Player
    {
        public int Lives { get; set; } = 4;
        public string Name { get; private set; } = "unknown";
        public bool IsAlive { get => Lives > 0; }

        public List<Card> Hand { get; private set; } = new();
        public List<Card> PassiveCards { get; private set; } = new();

        public Player(string? name)
        {
            if (name != null)
                Name = name;
        }

        public void PlayCard(Deck deck, List<Player> players, List<Player> deadPlayers)
        {
            while (Hand.Count > 0)
            {
                CheckDeathCondition(deck, players, deadPlayers);

                int alive = 0;
                foreach (Player player in players)
                {
                    if (player.IsAlive)
                    {
                        alive++;
                    }
                }

                if (alive == 1)
                {
                    break;
                }

                int indexOfCard = -1;
                while (indexOfCard < 0 || indexOfCard > Hand.Count - 1)
                {
                    DisplayPlayerInfo();
                    indexOfCard = Utility.ReadInt("\nChoose card (choose 0 to skip round): ", ConsoleColor.DarkGray) - 1;
                    if (indexOfCard == -1)
                    {
                        Utility.WriteColoredLine("\n{" + Name + "} IS SKIPPING THE ROUND!", ConsoleColor.Yellow);
                        return;
                    }
                    else if (indexOfCard < 0 || indexOfCard > Hand.Count - 1)
                    {
                        Console.WriteLine("Out of bounds input! try again...");
                    }
                }

                Hand.ElementAt(indexOfCard).UseCard(this, players);
            }
        }

        public bool DrawCards(Deck deck)
        {
            if (deck.ActiveCards.Count == 1 && deck.DiscardedCards.Count > 0)
            {
                deck.ReshuffleCards();
                return true;
            }
            if (deck.ActiveCards.Count > 0)
            {
                int cardsToDraw = Math.Min(deck.ActiveCards.Count, 2);
                List<Card> drawnCards = new List<Card>(deck.ActiveCards.GetRange(0, cardsToDraw));
                deck.ActiveCards.RemoveAll(c => drawnCards.Contains(c));
                Hand.AddRange(drawnCards);
                return true;
            }
            return false;
        }

        public void DiscardCards(Deck deck)
        {
            while (Lives != Hand.Count)
            {
                int indexOfCard = -1;
                while (indexOfCard < 0 || indexOfCard > Hand.Count)
                {
                    DisplayHand();
                    indexOfCard = Utility.ReadInt("\nChoose card to throw away [" + (Hand.Count - Lives) + " NEED TO GO] : ", ConsoleColor.DarkGray) - 1;
                    if (indexOfCard < 0 || indexOfCard > Hand.Count)
                    {
                        Console.WriteLine("Out of bounds input! try again...");
                    }
                }
                deck.DiscardedCards.Add(Hand.ElementAt(indexOfCard));
                Hand.RemoveAt(indexOfCard);
                Console.WriteLine("");
            }
        }

        // for blue cards
        public bool CheckEffects(List<Player> players)
        {
            List<Card> copyPassives = new();
            bool canPlay = true;
            copyPassives.AddRange(PassiveCards);
            foreach (Card card in copyPassives)
            {
                if (card is Dynamite dynamite)
                {
                    dynamite.Explode(this, players);
                }
                if (card is Prison prison)
                {
                    canPlay = prison.Escape(this);
                }
            }
            copyPassives.Clear();
            return canPlay;
        }

        public void CheckDeathCondition(Deck deck, List<Player> players, List<Player> deadPlayers)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (!players.ElementAt(i).IsAlive)
                {
                    if (!deadPlayers.Contains(players.ElementAt(i)))
                    {
                        deck.DiscardedCards.AddRange(players.ElementAt(i).Hand);
                        players.ElementAt(i).Hand.RemoveAll(c => players.ElementAt(i).Hand.Contains(c));
                        deadPlayers.Add(players.ElementAt(i));
                    }
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            Utility.WriteColoredLine("\n|<=====>| CURRENT PLAYER: " + Name + " |<=====>|", ConsoleColor.Magenta);
            Utility.WriteColoredLine("Current lives: {" + Lives + "}", ConsoleColor.Red);
            Utility.WriteColoredLine("Active cards: ", ConsoleColor.White);
            DisplayPassiveCards();
            DisplayHand();
        }

        public void DisplayPassiveCards()
        {
            int index = 1;
            if (PassiveCards.Count == 0)
            {
                Console.WriteLine("");
            }
            foreach (Card card in PassiveCards)
            {
                Utility.WriteColoredLine("[" + index + ". " + card.Name + "]", ConsoleColor.Blue);
                index++;
            }
        }

        private void DisplayHand()
        {
            Utility.WriteColoredLine("Current cards on Hand: ", ConsoleColor.White);
            for (int i = 0; i < Hand.Count; i++)
            {
                Utility.WriteColored("[", ConsoleColor.White);
                Utility.WriteColored((i + 1) + ". " + Hand.ElementAt(i).Name, ConsoleColor.Green);
                Utility.WriteColored("] ", ConsoleColor.White);
            }
        }
    }
}

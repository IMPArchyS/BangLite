using BangLite.Cards;
using BangLite.Decks;
using BangLite.Utils;

namespace BangLite.Players
{
    public class Player
    {
        public List<Card> Hand { get; private set; } = new();
        public List<Card> PassiveCards { get; private set; } = new();
        public int Lives { get; set; } = 4;
        public string Name { get; private set; } = "unknown";
        public bool IsAlive { get; set; } = true;

        public Player(string? name)
        {
            if (name != null)
                Name = name;
        }

        public void PlayCard(Deck deck, List<Player> players, List<Player> deadPlayers)
        {
            while (Hand.Count > 0)
            {
                CheckPlayerStatuses(deck, players, deadPlayers);

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
                    indexOfCard = Utility.InputInt("\nChoose card (choose 0 to skip round): ") - 1;
                    if (indexOfCard == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{GAME}: " + Name + " is skipping the round!");
                        Console.ForegroundColor = ConsoleColor.Gray;
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
            return false;
        }

        public void DiscardCards(Deck deck)
        {

        }

        public bool CheckEffects(List<Player> players)
        {
            return false;
        }

        public void CheckPlayerStatuses(Deck deck, List<Player> players, List<Player> deadPlayers)
        {

        }

        public void DisplayPlayerInfo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n------| Current Player: " + Name + " |------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Current lives: " + Lives);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Active cards: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            DisplayPassiveCards();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Current cards on Hand: ");
            Console.ForegroundColor = ConsoleColor.Green;
            DisplayHand();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DisplayPassiveCards()
        {
            int index = 1;
            foreach (Card card in PassiveCards)
            {
                Console.WriteLine(index + ". " + card.Name);
                index++;
            }
        }

        private void DisplayHand()
        {
            for (int i = 0; i < Hand.Count; i++)
            {
                Console.Write(i + 1 + ". " + Hand.ElementAt(i).Name + " ");
            }
        }
    }
}

using BangLite.Decks;
using BangLite.Players;

namespace BangLite.Games
{
    public class Game
    {
        private List<Player> players = new();
        private List<Player> deadPlayers = new();
        private Deck deck;
        private int currentPlayer = 0;
        private int playerCount = 0;

        public Game()
        {
            while (playerCount < 2 || playerCount > 4)
            {
                Console.Write("Input the number of players (2-4): ");
                playerCount = Convert.ToInt32(Console.ReadLine());
                if (playerCount < 2 || playerCount > 4)
                {
                    Console.Write("The game supports only 2 to 4 players! ");
                    playerCount = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (int i = 0; i < playerCount; i++)
            {
                Console.Write("Player " + (i + 1) + " name: ");
                players.Add(new Player(Console.ReadLine()));
            }

            deck = new Deck(players);
            StartGame();
        }

        private void StartGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Game started! ===");
            Console.ForegroundColor = ConsoleColor.Gray;
            GameLoop();
        }

        private void GameLoop()
        {

        }

        private void PlayerTurn()
        {

        }

        private void PrintWinner()
        {

        }
    }
}

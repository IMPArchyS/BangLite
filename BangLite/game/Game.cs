using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

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
                playerCount = Utility.InputInt("Input the number of players(2 - 4): ");
                if (playerCount == -1)
                {
                    Console.WriteLine("Wrong Input!"); continue;
                }
                if (playerCount < 2 || playerCount > 4)
                {
                    Console.WriteLine("The game supports only 2 to 4 players!");
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
            Utility.WriteColoredLine("\n{BANGLITE} <===> GAME STARTED! <===> {BANGLITE}", ConsoleColor.Yellow);
            GameLoop();
        }

        private void GameLoop()
        {
            while (deadPlayers.Count < playerCount - 1)
            {
                for (currentPlayer = 0; currentPlayer < players.Count; currentPlayer++)
                {
                    if (deck.ActiveCards.Count == 0)
                    {
                        deck.ReshuffleCards();
                    }
                    if (players.ElementAt(currentPlayer).IsAlive)
                    {
                        PlayerTurn();
                        Utility.WriteColoredLine("\n{BANGLITE} <===> NEXT PLAYER TURN! <===> {BANGLITE}", ConsoleColor.DarkMagenta);
                    }
                }
            }
            PrintWinner();
        }

        private void PlayerTurn()
        {
            bool canPlay = players.ElementAt(currentPlayer).CheckEffects(players);

            if (!players.ElementAt(currentPlayer).IsAlive || !canPlay)
            {
                return;
            }

            players.ElementAt(currentPlayer).DrawCards(deck);
            players.ElementAt(currentPlayer).PlayCard(deck, players, deadPlayers);

            if (deadPlayers.Count < playerCount && players.ElementAt(currentPlayer).Hand.Count > players.ElementAt(currentPlayer).Lives)
            {
                players.ElementAt(currentPlayer).DiscardCards(deck);
            }
        }

        private void PrintWinner()
        {
            foreach (Player player in players)
            {
                if (player.IsAlive)
                {
                    Utility.WriteColoredLine("{BANGLITE}: " + player.Name + " LAST MAN STANDING!", ConsoleColor.Yellow);
                }
            }
        }
    }
}

using BangLite.Cards;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Decks
{

    public class Deck
    {
        public List<Card> ActiveCards { get; private set; } = new();
        public List<Card> DiscardedCards { get; private set; } = new();

        public Deck(List<Player> players)
        {
            InitCardPile();
            DealCards(players);
        }

        public void ReshuffleCards()
        {
            if (DiscardedCards.Count == 0)
            {
                return;
            }
            ActiveCards.AddRange(DiscardedCards);
            DiscardedCards.Clear();
            Utility.Shuffle(ActiveCards);
        }

        private void InitCardPile()
        {

            for (int i = 0; i < 30; i++)
            {
                ActiveCards.Add(new Bang(this));
            }
            /*
            for (int i = 0; i < 8; i++)
            {
                ActiveCards.Add(new Beer(this));
            }

            for (int i = 0; i < 2; i++)
            {
                ActiveCards.Add(new Barrel(this));
            }

            for (int i = 0; i < 6; i++)
            {
                ActiveCards.Add(new CatBalou(this));
            }

            for (int i = 0; i < 4; i++)
            {
                ActiveCards.Add(new Stagecoach(this));
            }

            for (int i = 0; i < 15; i++)
            {
                ActiveCards.Add(new Missed(this));
            }

            for (int i = 0; i < 2; i++)
            {
                ActiveCards.Add(new Indians(this));
            }

            for (int i = 0; i < 3; i++)
            {
                ActiveCards.Add(new Prison(this));
            }

            ActiveCards.Add(new Dynamite(this));
            */
            Utility.Shuffle(ActiveCards);
        }

        private void DealCards(List<Player> players)
        {
            for (int i = 0; i < 4; i++)
            {
                foreach (Player player in players)
                {
                    player.Hand.Add(ActiveCards.ElementAt(0));
                    ActiveCards.RemoveAt(0);
                }
            }
        }
    }
}

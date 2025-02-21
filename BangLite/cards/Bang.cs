using BangLite.Decks;
using BangLite.Players;

namespace BangLite.Cards
{
    public class Bang : Card
    {
        public Bang(Deck deck) : base("Bang", deck)
        {
        }

        public override void UseCard(Player player, List<Player> targets)
        {
        }
    }
}

using BangLite.Decks;
using BangLite.Players;

namespace BangLite.Cards
{
    public class Barrel(Deck deck) : Card("Barrel", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
        }
    }
}

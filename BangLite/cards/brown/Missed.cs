using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards.Brown
{
    public class Missed(Deck deck) : Card("Missed", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            Utility.WriteColoredLine("Can't use Missed! It's a reactionary card!", ConsoleColor.Red);
        }

        public bool Miss(Player target)
        {
            Utility.WriteColoredLine("Missed " + target.Name + "!", ConsoleColor.Red);
            RemoveCard(target);
            return true;
        }
    }
}

using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards.Brown
{
    public class Stagecoach(Deck deck) : Card("Stagecoach", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            bool canDraw = player.DrawCards(deck);
            if (canDraw)
            {
                Utility.WriteColoredLine(player.Name + " used Stagecoach!", ConsoleColor.Red);
                RemoveCard(player);
            }
            else
            {
                Utility.WriteColoredLine("Can't use Stagecoach, no cards left!", ConsoleColor.Red);
            }
        }
    }
}

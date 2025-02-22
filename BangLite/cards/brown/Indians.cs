using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;


namespace BangLite.Cards.Brown
{
    public class Indians(Deck deck) : Card("Indians", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            Utility.WriteColoredLine("\n{" + player.Name + "}: USED INDIANS!", ConsoleColor.Yellow);
            foreach (Player target in targets)
            {
                bool getsHit = true;

                if (target.Equals(player) || !target.IsAlive)
                {
                    getsHit = false;
                }
                else
                {
                    foreach (Card card in target.Hand)
                    {
                        if (card is Bang)
                        {
                            card.RemoveCard(target);
                            Utility.WriteColoredLine(target.Name + " countered with Bang!", ConsoleColor.DarkYellow);
                            getsHit = false;
                            break;
                        }
                    }
                }

                if (getsHit)
                {
                    Utility.WriteColoredLine(target.Name + " lost a life!", ConsoleColor.Red);
                    target.Lives--;
                }
            }
            RemoveCard(player);
        }
    }
}

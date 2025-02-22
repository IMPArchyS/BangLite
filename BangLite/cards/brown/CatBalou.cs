using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards.Brown
{
    public class CatBalou(Deck deck) : Card("Cat Balou", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            Player targetPlayer = GetTargets(player, targets);
            if (targetPlayer.Hand.Count == 0 && targetPlayer.PassiveCards.Count == 0)
            {
                Utility.WriteColoredLine("Can't play Cat Balou, target has no cards!", ConsoleColor.DarkGreen);
                return;
            }
            int choice = -1;
            while (choice < 0 || choice > 1)
            {
                choice = Utility.InputInt("Take from hand(0) or passives(1): ", ConsoleColor.White);
                if (choice < 0 || choice > 1)
                {
                    Console.WriteLine("Out of bounds input! Try again...");
                }
                if (choice == 1 && targetPlayer.PassiveCards.Count == 0)
                {
                    Console.WriteLine("Player has no blue cards! Try again...");
                    choice = -1;
                }
                else if (choice == 0 && targetPlayer.Hand.Count == 0)
                {
                    Console.WriteLine("Player has no cards on hand! Try again...");
                    choice = -1;
                }
            }
            Card takenCard;
            if (choice == 1)
            {
                int indexOfCard = -1;
                while (indexOfCard < 0 || indexOfCard > targetPlayer.PassiveCards.Count - 1)
                {
                    targetPlayer.DisplayPassiveCards();
                    indexOfCard = Utility.InputInt("\nChoose card:") - 1;
                    if (indexOfCard < 0 || indexOfCard > targetPlayer.PassiveCards.Count - 1)
                    {
                        Console.WriteLine("Out of bounds input! try again...");
                    }
                }
                deck.DiscardedCards.Add(targetPlayer.PassiveCards.ElementAt(indexOfCard));
                takenCard = targetPlayer.PassiveCards.ElementAt(indexOfCard);
                targetPlayer.PassiveCards.RemoveAt(indexOfCard);
            }
            else
            {
                int indexOfCard = new Random().Next(targetPlayer.Hand.Count);
                deck.DiscardedCards.Add(targetPlayer.Hand.ElementAt(indexOfCard));
                takenCard = targetPlayer.Hand.ElementAt(indexOfCard);
                targetPlayer.Hand.RemoveAt(indexOfCard);
            }
            Utility.WriteColoredLine("\n{" + player.Name + "}: USED CAT BALOU ON " + targetPlayer.Name + "'s " + takenCard.Name, ConsoleColor.Yellow);
            RemoveCard(player);
        }
    }
}

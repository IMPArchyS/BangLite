﻿using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards.Blue
{
    public class Barrel(Deck deck) : Card("Barrel", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            foreach (Card card in player.PassiveCards)
            {
                if (card is Barrel)
                {
                    Utility.WriteColoredLine("Barrel is already active!", ConsoleColor.DarkGreen);
                    return;
                }
            }

            Utility.WriteColoredLine("\n{" + player.Name + "}: USED BARREL!", ConsoleColor.Yellow);
            player.PassiveCards.Add(this);
            player.Hand.Remove(this);
        }

        public bool Block()
        {
            int chance = new Random().Next(4);
            if (chance == 0)
            {
                Utility.WriteColoredLine("Barrel blocked the shot!", ConsoleColor.DarkGreen);
                return true;
            }
            return false;
        }
    }
}

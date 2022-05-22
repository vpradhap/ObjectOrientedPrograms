using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.DeckOfCards
{
    public class DeckOfCards
    {
        Random random = new Random();
        public int suits, ranks;
        List<string> cards = new List<string>();
        string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
        string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        List<string>[,] playerlist;
        public DeckOfCards()
        {
            playerlist = new List<string>[2, 2];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    playerlist[i, j] = new List<string>();
                }
            }
        }
        public void InitializeDeck()
        {
            Console.WriteLine("---------------------DECK BEFORE SHUFFLE---------------------");
            for (int i = 0; i < suit.Length; i++)
            {
                for (int j = 0; j < rank.Length; j++)
                {
                    Console.WriteLine(rank[j] + " of " + suit[i]);
                }
            }
        }

        public void Shuffles(int j, int k)
        {
            suits = random.Next(suit.Length);
            ranks = random.Next(rank.Length);
            string shuffle = rank[ranks] + " of " + suit[suits];
            if (cards.Contains(shuffle))
            {
                Shuffles(j,k);
            }
            else
            {
                cards.Add(shuffle);
                playerlist[j, k].Add(shuffle);
            }
        }
        public void Shuffle()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        Shuffles(j, k);
                    }
                }
            }
        }
        public void Display()
        {
            int count = 1;
            Console.WriteLine("\n---------------------After deck distribution---------------------");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine("\nPlayer " + count + " cards : \n");

                    foreach (string card in playerlist[i, j])
                    {
                        Console.WriteLine(card);
                    }
                    count++;
                }
            }
        }
    }
}

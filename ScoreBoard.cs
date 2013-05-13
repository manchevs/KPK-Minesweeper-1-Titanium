using System;
using System.Collections.Generic;
using System.Linq;

namespace Mines
{
    class ScoreBoard
    {
        private List<Player> players;

        public ScoreBoard()
        {
            players = new List<Player>();
        }

        internal int MinimalScoreInTop5()
        {
            if (players.Count > 0)
            {
                return players.Last().Score;
            }
            else
            {
                return -1;
            }
        }

        internal void AddScore(int score)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            players.Add(new Player(name, score));
            players.Sort(new Comparison<Player>((p1, p2) => p2.Score.CompareTo(p1.Score)));
            players = players.Take(5).ToList();
        }

        internal void ShowScore()
        {
            Console.WriteLine("Scoreboard:");
            foreach (var p in players)
            {
                Console.WriteLine(players.IndexOf(p) + 1 + ". " + p.Name + " --> " + p.Score + " cells");
            }
            Console.WriteLine();
        }

        internal int Count()
        {
            return players.Count();
        }
    }
}

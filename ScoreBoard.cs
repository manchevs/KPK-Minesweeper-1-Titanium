using System;
using System.Collections.Generic;
using System.Linq;

namespace Mines
{
    /// <summary>
    /// Tops scores data of the players. Keeps information as List of Players
    /// </summary>
    public class ScoreBoard
    {
        private List<Player> players;

        public ScoreBoard()
        {
            players = new List<Player>();
        }

        public int MinimalScoreInTop5()
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

        public void AddScore(int score)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            AddScores(name, score);
        }

        private void AddScores(string name, int score)
        {
            players.Add(new Player(name, score));
            players.Sort(new Comparison<Player>((p1, p2) => p2.Score.CompareTo(p1.Score)));
            players = players.Take(5).ToList();
        }

        // Created only for the tests
        public void AddScore(int scores, string defaultName)
        {
            AddScores(defaultName, scores);
        }

        public void ShowScore()
        {
            Console.WriteLine("Scoreboard:");
            foreach (var p in players)
            {
                Console.WriteLine(players.IndexOf(p) + 1 + ". " + p.Name + " --> " + p.Score + " cells");
            }
            Console.WriteLine();
        }

        public int Count()
        {
            return players.Count();
        }
    }
}

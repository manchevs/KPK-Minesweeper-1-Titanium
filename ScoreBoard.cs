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

        /// <summary>
        /// Class constructor. Initialize a list that holds the players
        /// results.
        /// </summary>
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

        /// <summary>
        /// Takes the name of the player from <see cref="System.Console"/>
        /// and adds it to the scoreboard
        /// </summary>
        /// <param name="score">The score of the player</param>
        public void AddScore(int score)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            AddScores(name, score);
        }

        /// <summary>
        /// Takes the name of the player and his score
        /// and adds it to the scoreboard
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        private void AddScores(string name, int score)
        {
            players.Add(new Player(name, score));
            players.Sort(new Comparison<Player>((p1, p2) => p2.Score.CompareTo(p1.Score)));
            players = players.Take(5).ToList();
        }

        // Created only for the tests
        public void AddScore(string defaultName, int scores)
        {
            AddScores(defaultName, scores);
        }

        /// <summary>
        /// Method that prints the scoreboard on the
        /// <see cref="System.Console"/>
        /// </summary>
        public void ShowScore()
        {
            Console.WriteLine("Scoreboard:");
            foreach (var p in players)
            {
                Console.WriteLine(players.IndexOf(p) + 1 + ". " + p.Name + " --> " + p.Score + " cells");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Returns the count of the current players added to the scoreboard
        /// </summary>
        /// <returns>The count of the players on the scoreboard</returns>
        public int Count()
        {
            return players.Count();
        }
    }
}

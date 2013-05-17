using System;
using System.Linq;

namespace Mines
{
    /// <summary>
    /// Players data - Name, Scores
    /// Internal class used from <see cref="ScoreBoard"/>
    /// </summary>
    public class Player
    {
        private string name;
        private int score;

        /// <summary>
        /// Initialize the player
        /// </summary>
        /// <param name="name">Payer's name - string</param>
        /// <param name="score">Player's score - integer </param>
        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        /// <summary>
        /// Gets/Sets the name of the Player
        /// </summary>
        public string Name
        {
            get { return this.name; }
			
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Player's name cannot be null");
                }
                if (value == "")
                {
                    this.name = "unsign player";
                }
                else
                {
                    this.name = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets the score of the Player
        /// </summary>
        public int Score
        {
            get { return this.score; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Score cannot be less than 0");
                }
                this.score = value;
            }
        }
    }
}

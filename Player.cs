using System;
using System.Linq;

namespace Mines
{
   public class Player
    {
        private string name;
        private int score;

        public Player(string name, int score)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }
            if (name == "")
            {
                throw new ArgumentException("Name cannot be empty string");
            }
             this.Name = name;
            if (score < 0)
            {
                throw new ArgumentException("Score cannot be less than 0");
            }
             this.Score = score;
        }

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
                    throw new ArgumentException("Player's name cannot be empty string");
                }
                this.name = value;
            }
        }

        public int Score
        {
            get { return this.score; }
            set 
            {
                if(value<0)
                {
                    throw new ArgumentException("Score cannot be less than 0");
                }
                this.score = value; 
            }
        }
    }
}

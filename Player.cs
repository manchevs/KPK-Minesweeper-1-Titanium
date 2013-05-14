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
            this.Name = name;
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
                    this.name = "unsign player";
                }
                else
                {
                    this.name = value;
                }
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

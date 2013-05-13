using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mines
{
    class Player
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.name = "unsigned player";
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
            set { this.score = value; }
        }
    }
}

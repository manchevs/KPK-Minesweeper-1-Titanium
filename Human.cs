using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mini
{
    class Human
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public Human(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
    }
}

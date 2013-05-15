using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mines;

namespace TestMines
{
    [TestClass]
    public class TestScoreBoard
    {
        [TestMethod]
        public void TestAddScores()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddScore(20, "");
            scoreBoard.AddScore(10, "");
            scoreBoard.AddScore(50, "");
            int result = scoreBoard.Count();
            Assert.AreEqual(3, result, "Not correct minimal score");
        }

        [TestMethod]
        public void TestMinimalScoreInTop5()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddScore(20, "");
            scoreBoard.AddScore(10, "");
            scoreBoard.AddScore(50, "");
            Assert.AreEqual(10, scoreBoard.MinimalScoreInTop5(), "Not correct minimal score");
        }
    }
}

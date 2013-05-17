using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Mines;

namespace TestMines
{
    [TestClass]
    public class TestGameMessages
    {
        [TestMethod]
        public void TestStartGame()
        {
            using (StringWriter strWriter = new StringWriter())
            {
                Console.SetOut(strWriter);
                GameMessages.StartGame();

                string expected = string.Format(
                    "Welcome to the game “Minesweeper”. Try to reveal all cells without mines.{0}" +
                    "To reveal cells enter row and column of the cell with space for separator -     \"0 0\"{0}" +
                    "Use 'flag' command to flag/unflag cells - \"flag 0 0\"{0}" +
                    "Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.{0}{0}",
                    Environment.NewLine);

                Assert.AreEqual(expected, strWriter.ToString());
            }
        }

        [TestMethod]
        public void TestIlligalCommand()
        {
            using (StringWriter strWriter = new StringWriter())
            {
                Console.SetOut(strWriter);
                GameMessages.IlligalCommand();

                string expected = string.Format("Illegal command!{0}", Environment.NewLine);

                Assert.AreEqual(expected, strWriter.ToString());
            }
        }

        [TestMethod]
        public void TestIlligalMove()
        {
            using (StringWriter strWriter = new StringWriter())
            {
                Console.SetOut(strWriter);
                GameMessages.IlligalMove();

                string expected = string.Format("Illegal move!{0}{0}", Environment.NewLine);

                Assert.AreEqual(expected, strWriter.ToString());
            }
        }

        [TestMethod]
        public void TestEntry()
        {
            using (StringWriter strWriter = new StringWriter())
            {
                Console.SetOut(strWriter);
                GameMessages.Entry();

                string expected = string.Format("Enter row and column: ");

                Assert.AreEqual(expected, strWriter.ToString());
            }
        }

        [TestMethod]
        public void TestExit()
        {
            using (StringWriter strWriter = new StringWriter())
            {
                Console.SetOut(strWriter);
                GameMessages.Exit();

                string expected = string.Format("Goodbye!{0}", Environment.NewLine);

                Assert.AreEqual(expected, strWriter.ToString());
            }
        }
    }
}

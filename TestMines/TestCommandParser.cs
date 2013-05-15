using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mines;

namespace TestMines
{
    [TestClass]
    public class TestCommandParser
    {
        [TestMethod]
        public void TestTryParseCommandFlag00()
        {
            string cmd = "flag 0 0";
            CommandParser commandParser = new CommandParser();
            bool parsedCommand = commandParser.TryParseCommand(cmd);
            Assert.IsTrue(parsedCommand, "Not parsed 'flag'");
        }

        [TestMethod]
        public void TestTryParseCommandIlligalFlag00()
        {
            string cmd = "flagr 0 0";
            CommandParser commandParser = new CommandParser();
            bool parsedCommand = commandParser.TryParseCommand(cmd);
            Assert.IsFalse(parsedCommand, "Not parsed 'flag'");
        }

        [TestMethod]
        public void TestTryParseCommandTwoTwo()
        {
            string cmd = "2 2";
            CommandParser commandParser = new CommandParser();
            bool parsedCommand = commandParser.TryParseCommand(cmd);
            Assert.IsTrue(parsedCommand, "Not parsed '2 2'");
        }

        [TestMethod]
        public void TestIsSpecialCommandTrueEnd()
        {
            string cmd = "end";
            CommandParser commandParser = new CommandParser();
            commandParser.Command = cmd;
            bool parsedCommand = commandParser.IsSpecialCommand();
            Assert.IsTrue(parsedCommand, "Incorrect special command");
        }

        [TestMethod]
        public void TestIsSpecialCommandFalseZeroZero()
        {
            string cmd = "0 0";
            CommandParser commandParser = new CommandParser();
            commandParser.Command = cmd;
            bool parsedCommand = commandParser.IsSpecialCommand();
            Assert.IsFalse(parsedCommand, "Not parsed 'move'");
        }
    }
}

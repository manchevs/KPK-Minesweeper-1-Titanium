using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestMines
{
    [TestClass]
    public class TestMinesweeperGameEngine
    {
        [TestMethod]
        public void TestReadCommand()
        {
            string[] inputCommands = new string[]
            {
                " 3 1       ",
                "   Flag 1 2 ",
                " TOP  ",
                "ResTart  ",
                "   eXit ",
                "  Some Invalid Command To Test ReadCommand Method "
            };

            string[] expectedCommands = new string[]
            {
                "3 1",
                "flag 1 2",
                "top",
                "restart",
                "exit",
                "some invalid command to test readcommand method"
            };

            for (int i = 0; i < inputCommands.Length; i++)
            {
                using (StringReader strReader = new StringReader(inputCommands[i]))
                {
                    Console.SetIn(strReader);
                    string actual = Mines.MinesweeperGameEngine.ReadCommand();
                    string expected = expectedCommands[i];
                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}

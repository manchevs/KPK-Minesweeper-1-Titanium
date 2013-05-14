using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mines;

namespace MinesUnitTests
{
    [TestClass]
    public class TestPlayer
    {

        private const string validPlayerName = "pesho";
        private const int minPlayerScore = 0;
        private const int validPlayerScore = 10;
        private const int invalidPlayerScore = -1;
        private const string emptyPlayerName = "unsign player";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNameInContstructorForNull()
        {
            new Player(null, TestPlayer.validPlayerScore);
        }

        [TestMethod]
        public void TestNameInConstructorForEmptyString()
        {
            Player player = new Player("", TestPlayer.validPlayerScore);
            Assert.AreEqual(TestPlayer.emptyPlayerName, player.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScoreInConstructorForInvalidValue()
        {
            new Player(TestPlayer.validPlayerName, TestPlayer.invalidPlayerScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNameInPropertySetForNull()
        {
            Player player = new Player(TestPlayer.validPlayerName, TestPlayer.validPlayerScore);

            player.Name = null;
        }

        [TestMethod]
        public void TestNameInPropertySetForEmptyString()
        {
            Player player = new Player(TestPlayer.validPlayerName, TestPlayer.validPlayerScore);
            player.Name = "";
            Assert.AreEqual(TestPlayer.emptyPlayerName, player.Name);

        }

        [TestMethod]
        public void TestNameInPropertyGetForCorrectGettedValue()
        {
            Player player = new Player(TestPlayer.validPlayerName, TestPlayer.validPlayerScore);

            Assert.AreEqual(TestPlayer.validPlayerName, player.Name, "Getter for name do not work correct");
        }

        [TestMethod]
        public void TestNamePropertyForCorrectWork()
        {
            Player player = new Player(TestPlayer.validPlayerName, TestPlayer.validPlayerScore);

            player.Name = "newName";

            Assert.AreEqual("newName", player.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScoreInPropertyForInvalidValue()
        {
            Player player = new Player(TestPlayer.validPlayerName, TestPlayer.validPlayerScore);

            player.Score = TestPlayer.invalidPlayerScore;
        }

        [TestMethod]
        public void TestScoreWithZeroPoints()
        {
            Player player = new Player(TestPlayer.validPlayerName, TestPlayer.minPlayerScore);
            Assert.AreEqual(0, player.Score);
        }

        [TestMethod]
        public void TestNameWithWhiteSpaces()
        {
            Player player = new Player(new string(' ', 10), TestPlayer.validPlayerScore);

            Assert.AreEqual(new string(' ', 10), player.Name);

        }

    }
}

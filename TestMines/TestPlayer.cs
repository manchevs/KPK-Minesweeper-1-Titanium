using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mines;

namespace TestMines
{
    [TestClass]
    public class TestPlayer
    {

        private const string ValidPlayerName = "pesho";
        private const int MinPlayerScore = 0;
        private const int ValidPlayerScore = 10;
        private const int InvalidPlayerScore = -1;
        private const string EmptyPlayerName = "unsign player";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNameInContstructorForNull()
        {
            new Player(null, TestPlayer.ValidPlayerScore);
        }

        [TestMethod]
        public void TestNameInConstructorForEmptyString()
        {
            Player player = new Player("", TestPlayer.ValidPlayerScore);
            Assert.AreEqual(TestPlayer.EmptyPlayerName, player.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScoreInConstructorForInvalidValue()
        {
            new Player(TestPlayer.ValidPlayerName, TestPlayer.InvalidPlayerScore);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNameInPropertySetForNull()
        {
            Player player = new Player(TestPlayer.ValidPlayerName, TestPlayer.ValidPlayerScore);

            player.Name = null;
        }

        [TestMethod]
        public void TestNameInPropertySetForEmptyString()
        {
            Player player = new Player(TestPlayer.ValidPlayerName, TestPlayer.ValidPlayerScore);
            player.Name = "";
            Assert.AreEqual(TestPlayer.EmptyPlayerName, player.Name);

        }

        [TestMethod]
        public void TestNameInPropertyGetForCorrectGettedValue()
        {
            Player player = new Player(TestPlayer.ValidPlayerName, TestPlayer.ValidPlayerScore);

            Assert.AreEqual(TestPlayer.ValidPlayerName, player.Name, "Getter for name do not work correct");
        }

        [TestMethod]
        public void TestNamePropertyForCorrectWork()
        {
            Player player = new Player(TestPlayer.ValidPlayerName, TestPlayer.ValidPlayerScore);

            player.Name = "newName";

            Assert.AreEqual("newName", player.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScoreInPropertyForInvalidValue()
        {
            Player player = new Player(TestPlayer.ValidPlayerName, TestPlayer.ValidPlayerScore);

            player.Score = TestPlayer.InvalidPlayerScore;
        }

        [TestMethod]
        public void TestScoreWithZeroPoints()
        {
            Player player = new Player(TestPlayer.ValidPlayerName, TestPlayer.MinPlayerScore);
            Assert.AreEqual(0, player.Score);
        }

        [TestMethod]
        public void TestNameWithWhiteSpaces()
        {
            Player player = new Player(new string(' ', 10), TestPlayer.ValidPlayerScore);

            Assert.AreEqual(new string(' ', 10), player.Name);

        }

    }
}

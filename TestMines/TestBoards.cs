using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mines;

namespace TestMines
{
    [TestClass]
    public class TestBoards
    {
        private const int InvalidHeightValue = -10;
        private const int InvalidWidthValue = -20;
        private const int ValidHeightValue = 10;
        private const int ValidWidthValue = 20;
        private const int CriticalBorderValueZero = 0;
        //private const int CriticalBorderValueOne = 1;

        private Boards boards = new Boards(TestBoards.ValidHeightValue, TestBoards.ValidWidthValue);
       
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForInvalidHeight()
        {
            new Boards(TestBoards.InvalidHeightValue, TestBoards.ValidWidthValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForInvalidWidth()
        {
            new Boards(TestBoards.ValidHeightValue, TestBoards.InvalidWidthValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForCriticalHeightValue()
        {
            Boards boards = new Boards(TestBoards.CriticalBorderValueZero, TestBoards.ValidWidthValue);
            Assert.AreEqual(0, boards.Visible.GetLength(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForCriticalWidthValue()
        {
            Boards boards = new Boards(TestBoards.ValidHeightValue, TestBoards.CriticalBorderValueZero);
            Assert.AreEqual(0, boards.Visible.GetLength(1));
        }

        [TestMethod]
        public void TestPropertyVisibleForGettingCorrectValue()
        {           
            Assert.IsTrue(boards.Visible.GetLength(0) == TestBoards.ValidHeightValue &&
                          boards.Visible.GetLength(1) == TestBoards.ValidWidthValue);
        }

        [TestMethod]
        public void TestPropertyHasMineForGettingCorrectValue()
        {
            Assert.IsTrue(boards.HasMine.GetLength(0) == TestBoards.ValidHeightValue &&
                          boards.HasMine.GetLength(1) == TestBoards.ValidWidthValue);
        }

        [TestMethod]
        public void TestPropertyIsShownForGettingCorrectValue()
        {
            Assert.IsTrue(boards.IsShown.GetLength(0) == TestBoards.ValidHeightValue &&
                          boards.IsShown.GetLength(1) == TestBoards.ValidWidthValue);
        }

        [TestMethod]
        public void TestPropertyNumberOfNeighbourMinesForGettingCorrectValue()
        {
            Assert.IsTrue(boards.NumberOfNeighbourMines.GetLength(0) == TestBoards.ValidHeightValue &&
                          boards.NumberOfNeighbourMines.GetLength(1) == TestBoards.ValidWidthValue);
        }

    }
}

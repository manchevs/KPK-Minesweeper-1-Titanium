using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mines;

namespace TestMines
{
    [TestClass]
    public class TestBoards
    {
        private const int invalidHeightValue = -10;
        private const int invalidWidthValue = -20;
        private const int validHeightValue = 10;
        private const int validWidthValue = 20;
        private const int criticalBorderValueZero = 0;
        private const int criticalBorderValueOne = 1;

        private Boards boards = new Boards(TestBoards.validHeightValue, TestBoards.validWidthValue);
       
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForInvalidHeight()
        {
            new Boards(TestBoards.invalidHeightValue, TestBoards.validWidthValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForInvalidWidth()
        {
            new Boards(TestBoards.validHeightValue, TestBoards.invalidWidthValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForCriticalHeightValue()
        {
            Boards boards = new Boards(TestBoards.criticalBorderValueZero, TestBoards.validWidthValue);
            Assert.AreEqual(0, boards.Visible.GetLength(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForCriticalWidthValue()
        {
            Boards boards = new Boards(TestBoards.validHeightValue, TestBoards.criticalBorderValueZero);
            Assert.AreEqual(0, boards.Visible.GetLength(1));
        }

        [TestMethod]
        public void TestPropertyVisibleForGettingCorrectValue()
        {           
            Assert.IsTrue(boards.Visible.GetLength(0) == TestBoards.validHeightValue &&
                          boards.Visible.GetLength(1) == TestBoards.validWidthValue);
        }

        [TestMethod]
        public void TestPropertyHasMineForGettingCorrectValue()
        {
            Assert.IsTrue(boards.HasMine.GetLength(0) == TestBoards.validHeightValue &&
                          boards.HasMine.GetLength(1) == TestBoards.validWidthValue);
        }

        [TestMethod]
        public void TestPropertyIsShownForGettingCorrectValue()
        {
            Assert.IsTrue(boards.IsShown.GetLength(0) == TestBoards.validHeightValue &&
                          boards.IsShown.GetLength(1) == TestBoards.validWidthValue);
        }

        [TestMethod]
        public void TestPropertyNumberOfNeighbourMinesForGettingCorrectValue()
        {
            Assert.IsTrue(boards.NumberOfNeighbourMines.GetLength(0) == TestBoards.validHeightValue &&
                          boards.NumberOfNeighbourMines.GetLength(1) == TestBoards.validWidthValue);
        }

        [TestMethod]
        public void TestBoardsForHeightAndWidthEqualToOne()
        {
            Boards newBoards = new Boards(TestBoards.criticalBorderValueOne, TestBoards.criticalBorderValueOne);
           
        }
    }
}

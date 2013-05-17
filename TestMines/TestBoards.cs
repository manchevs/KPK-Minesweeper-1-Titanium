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
        private const int criticalBorderValue = 0;
        
       
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
            Boards boards = new Boards(TestBoards.criticalBorderValue, TestBoards.validWidthValue);
            Assert.AreEqual(0, boards.Visible.GetLength(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForCriticalWidthValue()
        {
            Boards boards = new Boards(TestBoards.validHeightValue, TestBoards.criticalBorderValue);
            Assert.AreEqual(0, boards.Visible.GetLength(1));
        }
    }
}

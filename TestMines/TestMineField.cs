using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mines;

namespace TestMines
{
    [TestClass]
    public class TestMineField
    {
        private const int invalidHeightValue = -10;
        private const int invalidWidthValue = -111;
        private const int invalidPositiveRowValue = 11;
        private const int invalidPositiveColValue = 6;
        private const int invalidNegativeRowValue = -1;
        private const int invalidNegativeColValue = -100;
        private const int validColValue = 9;
        private const int validRowValue = 4;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForInvalidHeightAndWidth()
        {
            MineField mineField = new MineField(TestMineField.invalidWidthValue, TestMineField.invalidHeightValue);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsMineWithInValidPositiveRowAndCol()
        {
            MineField field = new MineField();
            bool checkForMine = field.IsMine(TestMineField.invalidPositiveRowValue, TestMineField.invalidPositiveColValue);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsMineWithInValidNegativeRowAndCol()
        {
            MineField field = new MineField();
            bool checkForMine = field.IsMine(TestMineField.invalidNegativeRowValue,
                                             TestMineField.invalidNegativeColValue);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsAlreadyShownWithInvalidPositiveRowAndCol()
        {
            MineField field = new MineField();
            bool checkIsAlreadyShown = field.IsAlreadyShown(TestMineField.invalidPositiveRowValue, TestMineField.invalidPositiveColValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsAlreadyShownWithInvalidNegativeRowAndCol()
        {
            (new MineField()).IsAlreadyShown(TestMineField.invalidNegativeRowValue,
                                             TestMineField.invalidNegativeColValue);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRevealBlockWithInvalidPositiveRowAndCol()
        {
            MineField field = new MineField();
            field.RevealBlock(TestMineField.invalidPositiveRowValue, TestMineField.invalidPositiveColValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRevealBlockWithInvalidНegativeRowAndCol()
        {
            MineField field = new MineField();
            field.RevealBlock(TestMineField.invalidNegativeRowValue, TestMineField.invalidNegativeColValue);
        }

    }
}

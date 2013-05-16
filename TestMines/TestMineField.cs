using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mines;

namespace TestMines
{
    [TestClass]
    public class TestMineField
    {
        private const int invalidHeightValue = -1;
        private const int invalidWidthValue = -20;
        private const int invalidXValue = 11;
        private const int invalidYValue = 6;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForInvalidHeightAndWidth()
        {
            MineField mineField = new MineField(TestMineField.invalidWidthValue, TestMineField.invalidHeightValue);
            
        }

        [TestMethod]
        public void TestIsInsideTheFieldWithInValidXAndY()
        {
            MineField field=new MineField();
            bool isInsideField = field.IsInsideTheField(TestMineField.invalidXValue, TestMineField.invalidYValue);
            Assert.IsFalse(isInsideField);
                     
        }

        [TestMethod]
        public void MyTestMethod()
        {
            MineField field = new MineField();
            field.RevealBlock(3,4);
        }

       
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvelopBL;

namespace EnvelopeBL.Test
{
    [TestClass]
    public class InsertedArgsValidatorTests
    {
        [TestMethod]
        [DataRow(new string[] { "123", "sad", "1,0" }, new double[] { 123.0, 1.0 })]
        [DataRow(new string[] { " ", "sad", "-1,0" }, new double[] { -1.0 })]
        [DataRow(new string[] { }, new double[] {})]

        public void ParseInsertedStringTest(string[] args, double[] expected)
        {
            //Arrange
            InsertedArgsValidator validator = new InsertedArgsValidator();
            double[] actual;

            //Act
            actual = validator.ParseInsertedString(args);

            //Assert        
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}

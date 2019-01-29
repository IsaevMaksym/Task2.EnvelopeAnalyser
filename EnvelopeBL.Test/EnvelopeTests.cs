using System;
using EnvelopBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnvelopeBL.Test
{
    [TestClass]
    public class EnvelopeTests
    {
        [TestMethod]

        [DataRow(13.5, 10.1, 13.5, 10.1, 0)]
        [DataRow(10.5, 10.1, 13.0, 12, 1)]
        [DataRow(10.5, 10.1, 13.0, 5.0, -1)]
        [DataRow(13.0, 5.0, 10.5, 10.1, -1)]
        [DataRow(0, 0, 0, 0, -1)]
        [DataRow(0, 0, 0, 0, -1)]

        public void Compare_EnvelopeToOtherEnvelope(double width1, double length1, double width2, double length2, int expected)
        {
            //Arrange
            Envelope first = new Envelope(width1, length1);
            Envelope second = new Envelope(width2, length2);
            int result;

            //Act
            result = first.CompareTo(second);

            //Assert
            Assert.AreEqual(expected, result);
        }

         [TestMethod]
        public void Compare_EnvelopeToNullObject_Minus_1_Expected()
        {
            //Arrange
            Envelope first = new Envelope(10.0, 10.0);
            Envelope second = null;
            int expected = -1;
            int result;
                       
            //Act
            result = first.CompareTo(second);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

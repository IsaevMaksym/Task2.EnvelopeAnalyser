using System;
using EnvelopBL;
using Resourses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnvelopeBL.Test
{
    [TestClass]
    public class EnvelopesAnalyserTests
    {
        [TestMethod]
        [DataRow(10.5, 5.4, 12.0, 5.6, CompareResult.FirstInSecond)]
        [DataRow(3.2, 5.3, 5.3, 10.5, CompareResult.FirstInSecond)]
        [DataRow(12.1, 10.1, 10.0, 5.0, CompareResult.SecondInFirst)]
        [DataRow(10.1, 12.1, 5.0, 10.0, CompareResult.SecondInFirst)]

        [DataRow(13.5, 10.1, 13.0, 10.5, CompareResult.NotComparable)]        
        [DataRow(10.5, 10.1, 13.0, 5.0, CompareResult.NotComparable)]
        [DataRow(5.1, 6.0, 6.5, 5.0, CompareResult.NotComparable)]
        [DataRow(0, 0, 0, 0, CompareResult.NotComparable)]
        [DataRow(-5,-6,-6,-7, CompareResult.NotComparable)]

        public void CompareEnvelopesTest(double height1, double width1, double height2, double width2, CompareResult expected)
        {
            //Arrange
            Envelope first = new Envelope(height1, width1);
            Envelope second = new Envelope(height2, width2);
            EnvelopesAnalyser analyser = new EnvelopesAnalyser();

            //Act
            analyser.CompareEnvelopes(first, second);

            //Assert
            Assert.AreEqual(expected, analyser.CompareEnvelopes(first, second));
        }

        [TestMethod]
        public void Insert_FirstNull_CompareResultAreEmptyExpected()
        {
            //Arrange
            Envelope first = null;
            Envelope second = new Envelope(10.2, 15.6);
            EnvelopesAnalyser analyser = new EnvelopesAnalyser();
            CompareResult expected = CompareResult.AreEmpty;
            CompareResult result;

            //Act
            result = analyser.CompareEnvelopes(first, second);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Insert_SecondNull_CompareResultAreEmptyExpected()
        {
            //Arrange
            Envelope first = new Envelope(10.2, 15.6);
            Envelope second = null;            
            EnvelopesAnalyser analyser = new EnvelopesAnalyser();
            CompareResult expected = CompareResult.AreEmpty;
            CompareResult result;

            //Act
            result = analyser.CompareEnvelopes(first, second);

            //Assert
            Assert.AreEqual(expected, result);
        }

    }
}

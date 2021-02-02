using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadJokes.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DadJokes.UnitTests.DadJokes.Utilities
{
    [TestClass]
    public class StringExtensionsTests
    {
        #region [ EmphasizeWithUppercase() ]

        [TestMethod]
        public void EmphasizeWithUppercase_ContainsLowercaseTermToEmphasize_ReturnsWithAllUppercaseTerm()
        {
            // Arrange
            string input = "This is the input string.";
            string termToEmphasize = "input";
            string expected = "This is the INPUT string.";

            // Act
            string actual = input.EmphasizeWithUppercase(termToEmphasize);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EmphasizeWithUppercase_ContainsTitlecaseTermToEmphasize_ReturnsWithAllUppercaseTerm()
        {
            // Arrange
            string input = "This is the input string.";
            string termToEmphasize = "This";
            string expected = "THIS is the input string.";

            // Act
            string actual = input.EmphasizeWithUppercase(termToEmphasize);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EmphasizeWithUppercase_DoesNotContainTermToEmphasize_ReturnsUnmodified()
        {
            // Arrange
            string input = "This is the input string.";
            string termToEmphasize = "not_in_input";
            string expected = input;

            // Act
            string actual = input.EmphasizeWithUppercase(termToEmphasize);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EmphasizeWithUppercase_NullTermToEmphasize_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            string input = "This is the input string.";
            string termToEmphasize = null;

            // Act

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => input.EmphasizeWithUppercase(termToEmphasize));
        }

        [TestMethod]
        public void EmphasizeWithUppercase_WhitespceTermToEmphasize_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            string input = "This is the input string.";
            string termToEmphasize = " ";

            // Act

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => input.EmphasizeWithUppercase(termToEmphasize));
        }

        #endregion

        #region [ GetNumberOfWords() ]

        [TestMethod]
        public void GetNumberOfWords_ExtraSpacedInput_IgnoresExtraSpace()
        {
            // Arrange
            string inputSingleSpaced = "This is the input string.";
            string inputExtraSpaced = "This is     the  input   string.  ";

            // Act
            int singleSpaced = inputSingleSpaced.GetNumberOfWords();
            int extraSpaced = inputExtraSpaced.GetNumberOfWords();

            // Assert
            Assert.AreEqual(singleSpaced, extraSpaced);
        }

        [TestMethod]
        public void GetNumberOfWords_SingleSpacedInput_ReturnsCorrectValue()
        {
            // Arrange
            string input = "This is the input string.";
            int expected = 5;

            // Act
            int actual = input.GetNumberOfWords();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region [ ToGroupByWordLength() ]

        #endregion
    }
}

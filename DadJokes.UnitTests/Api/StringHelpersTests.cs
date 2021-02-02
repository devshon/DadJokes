using System;
using DadJokes.Api.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DadJokes.UnitTests.Utilities
{
    [TestClass]
    public class StringHelpersTests
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
    }
}

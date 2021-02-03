using System.Linq;
using DadJokes.Api.Entities;
using DadJokes.Api.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DadJokes.UnitTests.Api
{
    [TestClass]
    public class DadJokeServiceHelpersTests
    {
        #region [ EmphasizeWithUppercase() ]

        [TestMethod]
        public void EmphasizeWithUppercase_MultipleSearchTermMatches_EmphasizesAllTerms()
        {
            // Arrange

            // Act

            // Assert

        }

        [TestMethod]
        public void EmphasizeWithUppercase_MultipleSearchTermOneMatch_EmphasizesMatchingTermOnly()
        {
            // Arrange

            // Act

            // Assert

        }

        [TestMethod]
        public void EmphasizeWithUppercase_SingleSearchTermMatch_EmphasizesMatchingTerm()
        {
            // Arrange

            // Act

            // Assert

        }

        [TestMethod]
        public void EmphasizeWithUppercase_ZeroMatches_DoesNotEmphasize()
        {
            // Arrange

            // Act

            // Assert

        }

        #endregion

        #region [ GetSearchRequestUriWithQueryString() ]

        [TestMethod]
        public void GetSearchRequestUriWithQueryString_ValidInputs_ReturnsCorrectly()
        {
            // Arrange
            string expected = "search?limit=30&term=dog";

            string inputEndpoint = "search";
            string inputTerm = "dog";
            int inputLimit = 30;

            // Act
            string actual = DadJokeServiceHelpers.GetSearchRequestUriWithQueryString(inputEndpoint, inputTerm, inputLimit);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region [ GroupByJokeSize() ]

        [TestMethod]
        public void GroupByJokeSize_AllJokeSizes_GroupsCorrectly()
        {
            // Arrange
            var jokeShort1 = new JokeResponse() { Joke = "one two three" };
            var jokeShort2 = new JokeResponse() { Joke = "one two three four five six seven eight nine" };
            var jokeMedium1 = new JokeResponse() { Joke = "one two three four five six seven eight nine ten" };
            var jokeMedium2 = new JokeResponse() { Joke = "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteen" };
            var jokeLong1 = new JokeResponse() { Joke = "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteen twenty" };
            var jokeLong2 = new JokeResponse() { Joke = "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteen twenty twenty-one" };

            var input = new JokeResponse[]
            {
                jokeShort1,
                jokeShort2, 
                jokeMedium1,
                jokeMedium2,
                jokeLong1,
                jokeLong2
            };

            // Act
            var output = DadJokeServiceHelpers.GroupByJokeSize(input);

            // Assert
            foreach (var group in output)
            {
                foreach (var joke in group.Value)
                {
                    Assert.AreEqual(group.Key, joke.Size);
                }
            }
        }

        [TestMethod]
        public void GroupByJokeSize_EmptyInput_ReturnsEmptyForAllSizes()
        {
            // Arrange
            int expected = 0;

            var input = new JokeResponse[] { };

            // Act
            var output = DadJokeServiceHelpers.GroupByJokeSize(input);
            int actualShortCount = output.Where(p => p.Key == JokeSize.Short.ToString()).Select(p => p.Value).SingleOrDefault().Count();
            int actualMediumCount = output.Where(p => p.Key == JokeSize.Medium.ToString()).Select(p => p.Value).SingleOrDefault().Count();
            int actualLongCount = output.Where(p => p.Key == JokeSize.Long.ToString()).Select(p => p.Value).SingleOrDefault().Count();

            // Assert
            Assert.AreEqual(expected, actualShortCount);
            Assert.AreEqual(expected, actualMediumCount);
            Assert.AreEqual(expected, actualLongCount);
        }

        [TestMethod]
        public void GroupByJokeSize_OnlyLongJokeSizes_ReturnsEmptyForOtherSizes()
        {
            // Arrange
            int expected = 0;

            var jokeLong1 = new JokeResponse() { Joke = "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteen twenty" };
            var jokeLong2 = new JokeResponse() { Joke = "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen sixteen seventeen eighteen nineteen twenty twenty-one" };

            var input = new JokeResponse[]
            {
                jokeLong1,
                jokeLong2
            };

            // Act
            var output = DadJokeServiceHelpers.GroupByJokeSize(input);
            int actualShortCount = output.Where(p => p.Key == JokeSize.Short.ToString()).Select(p => p.Value).SingleOrDefault().Count();
            int actualMediumCount = output.Where(p => p.Key == JokeSize.Medium.ToString()).Select(p => p.Value).SingleOrDefault().Count();

            // Assert
            Assert.AreEqual(expected, actualShortCount);
            Assert.AreEqual(expected, actualMediumCount);
        }

        #endregion
    }
}

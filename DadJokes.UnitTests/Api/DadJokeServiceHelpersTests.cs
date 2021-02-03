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

        }

        [TestMethod]
        public void EmphasizeWithUppercase_MultipleSearchTermOneMatch_EmphasizesMatchingTermOnly()
        {

        }

        [TestMethod]
        public void EmphasizeWithUppercase_SingleSearchTermMatch_EmphasizesMatchingTerm()
        {

        }

        [TestMethod]
        public void EmphasizeWithUppercase_ZeroMatches_DoesNotEmphasize()
        {

        }

        #endregion

        #region [ GetSearchRequestUriWithQueryString() ]

        [TestMethod]
        public void GetSearchRequestUriWithQueryString_conditions_expected()
        {

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

        #endregion
    }
}

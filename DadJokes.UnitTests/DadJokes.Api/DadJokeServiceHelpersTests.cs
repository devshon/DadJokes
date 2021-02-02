using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadJokes.Api.Entities;
using DadJokes.Api.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DadJokes.UnitTests.DadJokes.Api
{
    [TestClass]
    public class DadJokeServiceHelpersTests
    {
        [TestMethod]
        public void GroupByJokeSize_Condition_Expected()
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
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetFrameworkWebApplication.Classes;

namespace DotNetFrameworkWebApplication.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValidSentence()
        {
            //Arrange
            Sentence sentence = new Sentence();
            //Act   Assert
            Assert.IsTrue(sentence.IsValidSentence("The quick brown fox said \"hello Mr lazy dog\"."));
            Assert.IsTrue(sentence.IsValidSentence("The quick brown fox said hello Mr lazy dog."));
            Assert.IsTrue(sentence.IsValidSentence("One lazy dog is too few, 13 is too many."));
            Assert.IsTrue(sentence.IsValidSentence("One lazy dog is too few, thirteen is too many."));
            Assert.IsTrue(sentence.IsValidSentence("How many \"lazy dogs\" are there?"));
        }

        [TestMethod]
        public void TestInValidSentence()
        {
            //Arrange
            Sentence sentence = new Sentence();
            //Act   Assert
            Assert.IsFalse(sentence.IsValidSentence("The quick brown fox said \"hello Mr. lazy dog\"."));
            Assert.IsFalse(sentence.IsValidSentence("the quick brown fox said \"hello Mr lazy dog\"."));
            Assert.IsFalse(sentence.IsValidSentence("\"The quick brown fox said \"hello Mr lazy dog.\""));
            Assert.IsFalse(sentence.IsValidSentence("One lazy dog is too few, 12 is too many."));
            Assert.IsFalse(sentence.IsValidSentence("Are there 11, 12, or 13 lazy dogs?"));
            Assert.IsFalse(sentence.IsValidSentence("There is no punctuation in this sentence"));
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TDD.NumberManager.Tests
{
    [TestFixture]
    public class NumberToWordManagerTests
    {
        private INumberToWordManager _sut;

        [SetUp]
        public void Init()
        {
            _sut = new NumberToWordManager();
        }

        [Test]
        public void OnConvert_WhenInputIntegersFromOneToTen_ShouldPrintCorrespondingWordOfEachNumber()
        {
            //Arrange
            IList<String> expected = new List<String> { "Zero","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
            IList<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Act
            var words = _sut.Convert(numbers);

            //Assert
            Assert.AreEqual(numbers.Count, words.Count);
            Assert.AreEqual(expected, words);
        }

        [Test]
        public void OnConvert_WhenInputInvalidNumber_ShouldThrowArgumentOutOfRangeExceptionWithAnErrorMessage()
        {
            // arrange
            IList<int> numbers = new List<int> { -1, 2, 3, 1000, 1276};

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Convert(numbers));
        }

        [Test]
        public void OnConvert_WhenInputIntegersFromOneToNinteen_ShouldPrintCorrespondingWordOfEachNumber()
        {
            //Arrange
            IList<String> expected = new List<String> {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven",
                                                        "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                                                        "SixTeen", "Seventeen", "Eighteen", "Nineteen"};
            IList<int> numbers = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19};

            //Act
            var words = _sut.Convert(numbers);

            //Assert
            Assert.AreEqual(numbers.Count, words.Count);
            Assert.AreEqual(expected, words);
        }

        [Test]
        public void OnConvert_WhenUnsortedInputIntegersFromOneToNinteen_ShouldPrintCorrespondingWordOfEachNumber()
        {
            //Arrange
            IList<String> expected = new List<String> { "One", "Fifteen", "Three", "Ten", "Five", "Nineteen", "Eleven",
                                                        "Eight", "Twelve", "Thirteen", "SixTeen"};
            IList<int> numbers = new List<int> { 1, 15, 3, 10, 5, 19, 11, 8, 12, 13, 16};

            //Act
            var words = _sut.Convert(numbers);

            //Assert
            Assert.AreEqual(numbers.Count, words.Count);
            Assert.AreEqual(expected, words);
        }

        [Test]
        public void OnConvert_WhenMixOfUnsortedInputIntegersFromOneToNinteen_ShouldPrintCorrespondingWordOfEachNumber()
        {
            //Arrange
            IList<String> expected = new List<String> { "One", "Two", "One", "Nineteen", "Fifteen", "Two", "One",
                                                       "Ten", "Five", "Fourteen", "Thirteen"};
            IList<int> numbers = new List<int> { 1, 2, 1, 19, 15, 2, 1, 10, 5, 14, 13};

            //Act
            var words = _sut.Convert(numbers);

            //Assert
            Assert.AreEqual(numbers.Count, words.Count);
            Assert.AreEqual(expected, words);
        }

        [Test]
        public void OnConvert_WhenInputIntegersOfMultiplesOfTenFromTenToHundered_ShouldPrintCorrespondingWordOfEachNumber()
        {
            //Arrange
            IList<String> expected = new List<String> {"Zero", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty",
                                                        "Seventy", "Eighty", "Ninty"};
            IList<int> numbers = new List<int> {0, 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            //Act
            var words = _sut.Convert(numbers);

            //Assert
            Assert.AreEqual(numbers.Count, words.Count);
            Assert.AreEqual(expected, words);
        }

        [Test]
        public void OnConvert_WhenInputIntegersAreBetweenTwentyAndHundred_ShouldPrintCorrespondingWordOfEachNumber()
        {
            //Arrange
            IList<String> expected = new List<String> { "Twenty One", "Twenty Five", "Thirty Six", "Fourty Nine",
                                                        "Sixty Seven", "Seventy Eight", "Ninty Nine"};
            IList<int> numbers = new List<int> { 21, 25, 36, 49, 67, 78, 99 };

            //Act
            var words = _sut.Convert(numbers);

            //Assert
            Assert.AreEqual(numbers.Count, words.Count);
            Assert.AreEqual(expected, words);
        }

        [Test]
        public void OnConvert_WhenInputIntegersAreBetweenHundredAndThousand_ShouldPrintCorrespondingWordOfEachNumber()
        {
            //Arrange
            IList<String> expected = new List<String> { "One Hundred", "One Hundred and Fifty", "One Hundred and Fifty One", "Three Hundred",
                                                        "Five Hundred and Ninty Nine", "Seven Hundred and One",
                                                        "Eight Hundred and Seventy Five","Nine Hundred and Ninty Nine"};
            IList<int> numbers = new List<int> { 100, 150, 151, 300, 599, 701, 875, 999 };

            //Act
            var words = _sut.Convert(numbers);

            //Assert
            Assert.AreEqual(numbers.Count, words.Count);
            Assert.AreEqual(expected, words);
        }

        [Test]
        public void OnConvert_WhenInputIntegersAreBetweenOneAndThousand_ShouldPrintCorrespondingWordOfEachNumber()
        {
            //Arrange
            IList<String> expected = new List<String> { "One", "Sixty Nine", "Ninty", "One Hundred and One",
                                                        "Two Hundred and Ninty Nine", "Three Hundred and Fifty",
                                                        "Eight Hundred and Eighty Five","Nine Hundred and Ninty Nine"};
            IList<int> numbers = new List<int> { 1, 69, 90, 101, 299, 350, 885, 999 };

            //Act
            var words = _sut.Convert(numbers);

            //Assert
            Assert.AreEqual(numbers.Count, words.Count);
            Assert.AreEqual(expected, words);
        }

        [Test]
        public void OnConvert_WhenInputIntegersAreMultiplesOfThousand_ShouldPrintCorrespondingWordOfEachNumber()
        {
            //Arrange
            IList<String> expected = new List<String> { "Zero", "One Hundred", "Two Hundred", "Three Hundred",
                                                        "Four Hundred", "Five Hundred", "Six Hundred",
                                                        "Seven Hundred","Eight Hundred", "Nine Hundred"};
            IList<int> numbers = new List<int> { 0, 100, 200, 300, 400, 500, 600, 700, 800, 900};

            //Act
            var words = _sut.Convert(numbers);

            //Assert
            Assert.AreEqual(numbers.Count, words.Count);
            Assert.AreEqual(expected, words);
        }
    }


}

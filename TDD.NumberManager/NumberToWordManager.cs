using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.NumberManager
{
    public class NumberToWordManager : INumberToWordManager
    {
        private readonly IDictionary<int, string> keyWords = new Dictionary<int, string>()
        {
            {0, "Zero"},
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "SixTeen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
            {20, "Twenty"},
            {30, "Thirty"},
            {40, "Fourty"},
            {50, "Fifty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninty"}
        };

        public List<string> Convert(IList<int> numbers)
        {
            var words = new List<String>();

            foreach (var num in numbers)
            {
                string word = null;
                string word1, word2, word3;

                if (num < 0 || num >= 1000)
                {
                    throw new ArgumentOutOfRangeException(nameof(num), "Invalid Number, Number should be between 0-999");
                }

                if (num >= 0 && num <= 19)
                {
                    if (keyWords.TryGetValue(num, out word1))
                    {
                        word = word + word1;
                    }
                }
                else if (num >= 20 && num <= 99)
                {
                    int secondDigit = num % 10;
                    int firstDigit = num - secondDigit;

                    if (keyWords.TryGetValue(firstDigit, out word1))
                    {
                        word = word + word1;
                    }
                    if (keyWords.TryGetValue(secondDigit, out word2) && secondDigit > 0)
                    {
                        word = word + " " + word2;
                    }
                }
                else
                {
                    int thirdDigit = num % 10;
                    int multipleOfTen = num % 100;
                    int secondDigit = multipleOfTen - multipleOfTen % 10;
                    int multipleOfHundred = num - multipleOfTen;
                    int firstDigit = multipleOfHundred / 100;

                    if (keyWords.TryGetValue(firstDigit, out word1))
                    {
                        word = word + word1 + " Hundred";
                    }
                    if (keyWords.TryGetValue(secondDigit, out word2) && secondDigit > 0)
                    {
                        word = word + " and " + word2;
                    }
                    if (keyWords.TryGetValue(thirdDigit, out word3) && thirdDigit > 0)
                    {
                        if (secondDigit == 0)
                        {
                            word = word + " and " + word3;
                        }
                        else
                        {
                            word = word + " " + word3;
                        } 
                    }
                }
                words.Add(word);
            }
            return words;
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections.Tests
{
    public class CollectionsTests
    {
        [Test]
        public void GetPrimeNumbers_LimitIsNegative_ThrowArgumentException() =>
             Assert.Throws<ArgumentException>(() => CollectionsMethods.Collections.GetPrimeNumbers(-5));

        [TestCase(200, ExpectedResult = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199 })]
        [TestCase(2, ExpectedResult = new int[] { 2 })]
        [TestCase(15, ExpectedResult = new int[] { 2, 3, 5, 7, 11, 13 })]
        public int[] GetPrimeNumbers_LimitIsGiven_ReturnPrimeNumbers(int limit)
        {
            return CollectionsMethods.Collections.GetPrimeNumbers(limit).ToArray();
        }

        [Test]
        public void CheckIfParenthesisAreBalanced_InputStringIsNull_ThrowArgumentNullException() =>
          Assert.Throws<ArgumentNullException>(() => CollectionsMethods.Collections.CheckIfParenthesisAreBalanced(null));

        [TestCase("", ExpectedResult = true)]
        [TestCase("[288 votes so far. Categories: {Everything Else (47 votes), C# (61 votes), C++ (39 votes), Database (44 votes), Mobile (45 votes), Web Dev (52 votes)}]", ExpectedResult = true)]
        [TestCase("[{}()<sometext>[[{{}}]]]", ExpectedResult = true)]
        [TestCase("[ ( ] )", ExpectedResult = false)]
        [TestCase("(x+8)*[((some)]", ExpectedResult = false)]
        [TestCase("(x+8)*[(some)]", ExpectedResult = true)]
        public bool CheckIfParenthesisAreBalanced_InputString_ReturnResult(string input)
        {
            return CollectionsMethods.Collections.CheckIfParenthesisAreBalanced(input);
        }

        [Test]
        public void GetUniqueWords_NullGiven_ThrowArgumentNullException() =>
          Assert.Throws<ArgumentNullException>(() => CollectionsMethods.Collections.GetUniqueWords(null));

        [TestCase("Some text, some text, new words added to the sequence. Sequence", ExpectedResult =
            new string[] {"some", "text", "new", "words", "added", "to", "the", "sequence"})]
        [TestCase("hello HELLO hi, hello", ExpectedResult = new string[] { "hello", "hi" })]
        [TestCase("", ExpectedResult = new string[] { })]
        public string[] GetUniqueWords_TextGiven_ReturnWords(string text)
        {
            var actualWords = CollectionsMethods.Collections.GetUniqueWords(text).ToArray();
            return actualWords;
        }

        [Test]
        public void GetUniqueWordsWithFrequency_NullGiven_ThrowArgumentNullException() =>
          Assert.Throws<ArgumentNullException>(() => CollectionsMethods.Collections.GetUniqueWords(null));

        private static IEnumerable<TestCaseData> TestCasesForWordsWithFrequency
        {
            get
            {
                yield return new TestCaseData(arg1: "hello HELLO hi, hello", arg2: new Dictionary<string, int>() { ["hello"] = 2, ["HELLO"] = 1, ["hi"] = 1});
                yield return new TestCaseData(arg1: "", arg2: new Dictionary<string, int>() { });
                yield return new TestCaseData(arg1: "Some text, some text, new words added to. To to the sequence. Sequence: some",
                    arg2: new Dictionary<string, int>()
                    {
                        ["Some"] = 1,
                        ["some"] = 2,
                        ["text"] = 2,
                        ["new"] = 1,
                        ["words"] = 1,
                        ["added"] = 1,
                        ["to"] = 2,
                        ["To"] = 1,
                        ["the"] = 1,
                        ["sequence"] = 1,
                        ["Sequence"] = 1
                    }
                    );
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForWordsWithFrequency))]
        public void GetUniqueWordsWithFrequency_TextPassed_ReturnStats(string text, IEnumerable<KeyValuePair<string, int>> expected)
        {
            var wordsStats = CollectionsMethods.Collections.GetUniqueWordsWithFrequency(text);
            CollectionAssert.AreEqual(expected, wordsStats);
        }      
    }
}

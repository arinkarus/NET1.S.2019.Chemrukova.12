using NUnit.Framework;
using System;
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

    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsMethods
{
    /// <summary>
    /// Contains methods that works with collections.
    /// </summary>
    public static class Collections
    {
        /// <summary>
        /// Returns prime numbers that are below limit.
        /// </summary>
        /// <param name="limit">Given limit.</param>
        /// <returns>Found prime numbers.</returns>
        public static IEnumerable<int> GetPrimeNumbers(int limit)
        {
            CheckIfPositiveNumber(limit);
            return SieveOfEratosthenes(limit);

            IEnumerable<int> SieveOfEratosthenes(int upperLimit)
            {
                int sieveBound = (upperLimit - 1) / 2;
                int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;
                var bits = new BitArray(sieveBound + 1, true);
                yield return 2;
                for (int i = 1; i <= upperSqrt; i++)
                {
                    if (bits.Get(i))
                    {
                        yield return 2 * i + 1;
                        for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                        {
                            bits.Set(j, false);
                        }
                    }
                }
           
                for (int i = upperSqrt + 1; i <= sieveBound; i++)
                {
                    if (bits.Get(i))
                    {
                        yield return 2 * i + 1;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if brackets are balanced.
        /// </summary>
        /// <param name="input">Given string.</param>
        /// <returns>True if parenthesis are balanced.</returns>
        public static bool CheckIfParenthesisAreBalanced(string input)
        {
            input.CheckOnNull();
            Dictionary<char, char> dictionary = GetParenthesisDictionary();
            var stack = new Stack<char>();
            foreach (var symbol in input)
            {
                if (dictionary.Values.Contains(symbol))
                {
                    stack.Push(symbol);
                }
                else
                {
                   if (dictionary.Keys.Contains(symbol))
                   {
                       char openingBracket = stack.Peek();
                       if (!(openingBracket == dictionary[symbol]))
                       {
                            return false;
                       }

                       stack.Pop();
                   }             
                }
            }

            return true;
        }

        /// <summary>
        /// Returns unique words that are found in text. Words written in different letter-cases 
        /// are considered equal.
        /// </summary>
        /// <param name="input">Given text.</param>
        /// <returns>Unique words.</returns>
        public static IEnumerable<string> GetUniqueWords(string input)
        {
            CheckOnNull(input);
            IEnumerable<string> GetWords(string text)
            {
                string[] words = input.ToLower().Split(GetDelimiters(), StringSplitOptions.RemoveEmptyEntries);
                var setOfWords = new HashSet<string>();
                foreach (var word in words)
                {
                    if (setOfWords.Add(word))
                    {
                        yield return word;
                    }

                    setOfWords.Add(word);
                }
            }

            return GetWords(input);
        }

        /// <summary>
        /// Returns unique words that are found in text. Words written in different letter-cases 
        /// are considered different.
        /// </summary>
        /// <param name="input">Given text.</param>
        /// <returns>Unique words with their frequency in the text.</returns>
        public static IEnumerable<KeyValuePair<string, int>> GetUniqueWordsWithFrequency(string input)
        {
            CheckOnNull(input);
            string[] words = input.Split(GetDelimiters(), StringSplitOptions.RemoveEmptyEntries);
            var wordsStatistics = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordsStatistics.ContainsKey(word))
                {
                    wordsStatistics[word]++;
                }
                else
                {
                    wordsStatistics.Add(word, 1);
                }
            }

            return wordsStatistics;
        }

        public static T GetRemainingItemInCircle<T>(IEnumerable<T> initialItems)
        {
            CheckOnNull(initialItems);
            var list = new LinkedList<T>(initialItems);
            var current = list.First;
            while (list.Count != 1)
            {
                list.Remove(current.Next ?? list.First);
                current = current.Next ?? list.First;
            }
            return current.Value;
        }

        private static bool Contains(this IEnumerable<char> openingParenthesis, char symbol)
        {
            foreach (var bracket in openingParenthesis)
            {
                if (symbol == bracket)
                {
                    return true;
                }
            }

            return false;
        }
   
        private static char[] GetDelimiters() => new char[] { '.', ',', '!', '?', '-',  ':',  ':',  ' '};

        private static Dictionary<char, char> GetParenthesisDictionary() => 
            new Dictionary<char, char>
            {
                [')'] = '(',
                [']'] = '[',
                ['}'] = '{',
            };
        
        private static void CheckIfPositiveNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"{nameof(number)} has to be greater than 1.");
            }
        }

        private static void CheckOnNull(this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"{nameof(obj)} can't be null!");
            }
        }
    }
}

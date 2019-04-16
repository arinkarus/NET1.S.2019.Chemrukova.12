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
                BitArray bits = new BitArray(sieveBound + 1, true);
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

        private static Dictionary<char, char> GetParenthesisDictionary() {
            return 
            new Dictionary<char, char>
            {
                [')'] = '(',
                [']'] = '[',
                ['}'] = '{',
            };
        }

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

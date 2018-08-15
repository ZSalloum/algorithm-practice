using System;
using NUnit.Framework;

namespace AlgorithmPractice.Strings
{

    /*
     * https://www.geeksforgeeks.org/count-number-of-substrings-with-exactly-k-distinct-characters/
     * 
     Count number of substrings with exactly k distinct characters
    Given a string of lowercase alphabets, count all possible substrings (not necessarily distinct) that has exactly k distinct characters.
    Examples:

    Input: abc, k = 2
    Output: 2
    Possible substrings are {"ab", "bc"}

    Input: aba, k = 2
    Output: 3
    Possible substrings are {"ab", "ba", "aba"}

    Input: aa, k = 1
    Output: 3
    Possible substrings are {"a", "a", "aa"} 
     */
    public class CountKSubStrings
    {
        // Function to count number of substrings
        // with exactly k unique characters
        public int CountSubstr(String str, int k)
        {
            // Initialize result
            int res = 0;

            int n = str.Length;

            // To store count of characters from 'a' to 'z'
            int[] cnt = new int[26];

            // Consider all substrings beginning with
            // str[i]
            for (int i = 0; i < n; i++)
            {
                int dist_count = 0;

                // Initializing count array with 0
                Fill(cnt, 0);

                // Consider all substrings between str[i..j]
                for (int j = i; j < n; j++)
                {
                    // If this is a new character for this
                    // substring, increment dist_count.
                    if (cnt[str[j] - 'a'] == 0)
                        dist_count++;

                    // Increment count of current character
                    cnt[str[j] - 'a']++;

                    // If distinct character count becomes k,
                    // then increment result.
                    if (dist_count == k)
                        res++;
                }
            }

            return res;
        }

        private void Fill(int[] ar, int v){
            for (int i = 0; i < ar.Length; i++){
                ar[i] = v;
            }
        }
    }

    [TestFixture]
    public class Test_CountKSubStrings{

        CountKSubStrings obj;

        [SetUp]
        public void Init(){
            obj = new CountKSubStrings();
        }

        [Test]
        public void Should_Return_2(){
            int r = obj.CountSubstr("abc", 2);
            Assert.IsTrue(r == 2);
        }

        [Test]
        public void Should_Return_8()
        {
            int r = obj.CountSubstr("abcbaa", 3);
            Assert.IsTrue(r == 8);
        }
    }
}

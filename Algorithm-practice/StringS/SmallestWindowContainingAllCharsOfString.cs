using System;
using NUnit;
using NUnit.Framework;

namespace AlgorithmPractice.Strings
{

    /**
     * https://www.geeksforgeeks.org/find-the-smallest-window-in-a-string-containing-all-characters-of-another-string/
     
     * Find the smallest window in a string containing all characters of another string
        Given two strings string1 and string2, find the smallest substring in string1 containing all characters of string2 efficiently.
        For Example:

        Input :  string = "this is a test string"
                 pattern = "tist"
        Output :  Minimum window is "t stri"
        Explanation: "t stri" contains all the characters
                      of pattern.

        Input :  string = "geeksforgeeks"
                 pattern = "ork" 
        Output :  Minimum window is "ksfor"
     * 
     */

    public class SmallestWindowContainingAllCharsOfString
    {

        const int NO_OF_CHARS = 256;

        // Function to find smallest window containing
        // all characters of 'pat'
        public String FindSubString(String str, String pat)
        {
            int len1 = str.Length;
            int len2 = pat.Length;

            // check if string's length is less than pattern's
            // length. If yes then no such window can exist
            if (len1 < len2)
            {
                Console.WriteLine("No such window exists");
                return "";
            }

            int[] hash_pat = new int[NO_OF_CHARS];
            int[] hash_str = new int[NO_OF_CHARS];

            // store occurrence ofs characters of pattern
            for (int i = 0; i < len2; i++)
                hash_pat[pat[i]]++;

            int start = 0, start_index = -1, min_len = Int32.MaxValue;

            // start traversing the string
            int count = 0;  // count of characters
            for (int j = 0; j < len1; j++)
            {
                // count occurrence of characters of string
                hash_str[str[j]]++;

                // If string's char matches with pattern's char
                // then increment count
                if (hash_pat[str[j]] != 0 &&
                    hash_str[str[j]] <= hash_pat[str[j]])
                    count++;

                // if all the characters are matched
                if (count == len2)
                {
                    // Try to minimize the window i.e., check if
                    // any character is occurring more no. of times
                    // than its occurrence  in pattern, if yes
                    // then remove it from starting and also remove
                    // the useless characters.
                    while (hash_str[str[start]] > hash_pat[str[start]]
                           || hash_pat[str[start]] == 0)
                    {

                        if (hash_str[str[start]] > hash_pat[str[start]])
                            hash_str[str[start]]--;
                        start++;
                    }

                    // update window size
                    int len_window = j - start + 1;
                    if (min_len > len_window)
                    {
                        min_len = len_window;
                        start_index = start;
                    }
                }
            }

            // If no window found
            if (start_index == -1)
            {
                Console.WriteLine("No such window exists");
                return "";
            }

            // Return substring starting from start_index
            // and length min_len
            return str.Substring(start_index, min_len);
        }
    }

    [TestFixture]
    public class Test_SmallestWindowContainingAllCharsOfString{

        private SmallestWindowContainingAllCharsOfString item;

        [SetUp]
        public void Init(){
            item = new SmallestWindowContainingAllCharsOfString();
        }

        [Test]
        public void Should_Return_TIST(){
            String str = "this is a test string";
            String pat = "tist";

            String result = item.FindSubString(str, pat);
            Assert.True(result == "t stri");
        }

        [Test]
        public void Should_Return_CC()
        {
            String str = "abcdecfcc";
            String pat = "cc";

            String result = item.FindSubString(str, pat);
            Assert.True(result == "cc");
        }

        [Test]
        public void Should_Return_Empty()
        {
            String str = "abcdecfcc";
            String pat = "xyz";

            String result = item.FindSubString(str, pat);
            Assert.True(result == "");
        }
    }
}

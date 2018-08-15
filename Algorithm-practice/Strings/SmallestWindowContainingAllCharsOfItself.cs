using System;
using System.Text;
using System.Collections.Generic;
using NUnit;
using NUnit.Framework;

namespace AlgorithmPractice.Strings
{

    /**
     * 
     * https://www.geeksforgeeks.org/smallest-window-contains-characters-string/
     * 
    Smallest window that contains all characters of string itself
    Given a string, find the smallest window length with all distinct characters of the given string. For eg. str = “aabcbcdbca”, then the result would be 4 as of the smallest window will be “dbca” .

    Examples:

    Input  : aabcbcdbca
    Output : dcba
    Explanation : 
    dbca of length 4 is the smallest 
    window with highest number of distinct
    characters.         

    Input : aaab
    Output : ab
    Explanation : 
    ab of length 2 is the smallest window 
    with highest number of distinct characters.
     * 
     */

    public class SmallestWindowContainingAllCharsOfItself
    {
        
        // Function to find smallest window containing
        // all characters of 'pat'
        public String FindSubString(String str)
        {
            HashSet<char> found = new HashSet<char>();
            StringBuilder sb = new StringBuilder();

            foreach(var c in str){
                if(!found.Contains(c)){
                    found.Add(c);
                    sb.Append(c);
                }
            }

            SmallestWindowContainingAllCharsOfString smallest = new SmallestWindowContainingAllCharsOfString();
            String result = smallest.FindSubString(str, sb.ToString());

            return result;
           
        }
    }

    [TestFixture]
    public class Test_SmallestWindowContainingAllCharsOfItself{

        private SmallestWindowContainingAllCharsOfItself item;

        [SetUp]
        public void Init(){
            item = new SmallestWindowContainingAllCharsOfItself();
        }


        [Test]
        public void Should_Return_dbca()
        {
            String str = "aabcbcdbca";

            String result = item.FindSubString(str);
            Assert.True(result == "dbca");
        }

        [Test]
        public void Should_Return_ab()
        {
            String str = "aaab";

            String result = item.FindSubString(str);
            Assert.True(result == "ab");
        }

        [Test]
        public void Should_Return_Itsef()
        {
            String str = "abcdefgh";

            String result = item.FindSubString(str);
            Assert.True(result == "abcdefgh");
        }
    }
}

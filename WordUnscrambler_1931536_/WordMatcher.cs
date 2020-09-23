using System;
using System.Collections.Generic;

namespace WordUnscrambler_1931536_
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
            {
                foreach (string word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {

                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });

                    }
                    else
                    {
                       
                        char[] scrambledWordArray = scrambledWord.ToCharArray();
                        char[] wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        string scrambledString = new string(scrambledWordArray);
                        string wordString = new string(wordArray);

                        if (wordString.Equals(scrambledString,StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word}) ;
                        }
                        //convert strings into character arrays i.e. ToCharArray()
                        //sort both character arrays
                        //convert sorted character arrays into strings (toString)
                        // 
                        //compare the two sorted strings. If they match, build the MatchWord
                        //struct and add to matchedWords list.
                    }

                }
            }

            return matchedWords;
        }

        MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedWord;
        }



    }
}

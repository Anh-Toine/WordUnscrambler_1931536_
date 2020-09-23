using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler_1931536_
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            bool again = true;
            string input = "y";
            bool error = true;
            while (again && error)
            {

                try
                {
                    Console.WriteLine("Enter the scrambled words manually or as a file: f - file, m = manual");

                    string option = Console.ReadLine() ?? throw new Exception("String is null");

                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.Write("Enter the full path and filename > ");
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.Write("Enter word(s) separated by a comma > ");
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            throw new Exception("The entered option was not recognized");
                    }
                    Console.WriteLine("Would you like to do it again?[y/n]");
                    input = Console.ReadLine();
                    if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        again = true;
                        error = true;
                    }
                    else
                    {
                        again = false;
                        error = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Sorry an error has occurred.. " + e.Message);
                    error = true;
                }
            }
        }
        //Console.ReadKey();

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.Read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            // 1 get the user's input - comma separated string containing scrambled words
            // 2 Extract the words into a string (red,blue,green) 
            // 3 Call the DisplayMatchedUnscrambledWords method passing the scrambled words string array
            string stdin = Console.ReadLine();
            string[] stdinArray = stdin.Split(',');
            DisplayMatchedScrambledWords(stdinArray);

        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(@"wordlist.txt"); // Put in a constants file. CAPITAL LETTERS.  READONLY.

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);


            // Rule:  Use a formatter to display ... eg:  {0}{1}

            // Rule:  USe an IF to determine if matchedWords is empty or not......
            //            if empty - display no words found message.
            //            if NOT empty - Display the matches.... use "foreach" with the list (matchedWords)
            if (matchedWords.Count == 0)
            {
                Console.WriteLine("No match(es) found.");
            }
            else
            {
                foreach (MatchedWord matched in matchedWords)
                {
                    Console.WriteLine("Match found for {0}: {1}", matched.ScrambledWord, matched.Word);
                }
            }
        }
    }
}


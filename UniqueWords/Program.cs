using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniqueWords
{
    class Program
    {
        private static string ReadString()
        {
            Console.Write("Enter string: ");
            return Console.ReadLine();
        }

        private static string[] SplitString(string input)
        {
            return input.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries
            );
        }

        private static string StripString(string input)
        {
            return Regex.Replace(input, "[^(a-zA-Z)( )]", ""); ;
        }

        private static IEnumerable<string> UniqueWords(string[] words)
        {
            return (from string word in words orderby word select word.ToUpper()).Distinct();
        }
        
        private static void PrintWords(IEnumerable<string> words)
        {
            Console.WriteLine();

            if (words.Count() > 0)
            {
                Console.WriteLine("List of words:");

                foreach (var word in words)
                {
                    Console.WriteLine(word);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"There are {words.Count()} unique words");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Increase WriteLine limit from 254
            Console.SetIn(new StreamReader(Console.OpenStandardInput(int.MaxValue)));

            while (true)
            {
                var input = ReadString();
                var uniqueWords = UniqueWords(SplitString(StripString(input)));
                PrintWords(uniqueWords);
                Console.WriteLine();
            }
        }
    }
}

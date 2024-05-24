using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class AnagramSolver
{
    // Method to load and filter words from a file
    static string[] LoadWords(string filename)
    {
        List<string> words = new List<string>();
        using (StreamReader file = new StreamReader(filename))
        {
            HashSet<int> seen = new HashSet<int>();
            while (!file.EndOfStream)
            {
                string word = file.ReadLine();
                if (word.Length != 5) continue;

                // Sort letters and check for duplicate letters
                string sortedWord = String.Concat(word.OrderBy(c => c));
                bool badWord = false;
                for (int i = 0; i < 4; ++i)
                {
                    if (sortedWord[i] == sortedWord[i + 1])
                    {
                        badWord = true;
                        break;
                    }
                }
                if (badWord) continue;

                // Create a unique hash for the word and filter out anagrams
                int hash = 0;
                for (int i = 0; i < sortedWord.Length; i++)
                {
                    hash = hash * 26 + (sortedWord[i] - 'a');
                }
                if (seen.Contains(hash)) continue;
                seen.Add(hash);
                words.Add(word);
            }
        }
        return words.ToArray();
    }

    // Recursive method to find and print all valid sets of 5 words
    static void FindUniqueCombinations(string[] words, int[] masks, int start, List<int> currentCombination, int currentMask, ref int combinationsFound, object lockObject)
    {
        if (currentCombination.Count == 5)
        {
            lock (lockObject)
            {
                combinationsFound++;
                for (int i = 0; i < currentCombination.Count; i++)
                {
                    Console.Write(words[currentCombination[i]] + " ");
                }
                Console.WriteLine();
            }
            return;
        }

        for (int i = start; i < words.Length; i++)
        {
            if ((currentMask & masks[i]) == 0)
            {
                currentCombination.Add(i);
                FindUniqueCombinations(words, masks, i + 1, currentCombination, currentMask | masks[i], ref combinationsFound, lockObject);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }
    }

    // Method to solve the problem by finding valid word combinations
    static void Solve(string[] words)
    {
        int[] masks = new int[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            int mask = 0;
            for (int j = 0; j < words[i].Length; j++)
            {
                mask |= 1 << (words[i][j] - 'a');
            }
            masks[i] = mask;
        }

        int combinationsFound = 0;
        object lockObject = new object();

        // Parallelize the search for the first word
        Parallel.For(0, words.Length, i =>
        {
            List<int> localCombination = new List<int> { i };
            FindUniqueCombinations(words, masks, i + 1, localCombination, masks[i], ref combinationsFound, lockObject);
        });

        Console.WriteLine("Total combinations found: " + combinationsFound);
    }

    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string path = @"C:\H2Opgaver\5UniqueIn5Words\ConsoleAppRecursive\Words 2.txt";
        string[] words = LoadWords(path);

        Console.WriteLine("Total words: {0}", words.Length);
        Console.WriteLine("Valid 5-letter words with unique letters: {0}\n", words.Length);

        Solve(words);

        stopwatch.Stop();
        Console.WriteLine("Time elapsed: " + stopwatch.Elapsed);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TheBrains
{
    public class Brain
    {
        // Method to load and filter words from a file
        public string[] LoadWords(string filename)
        {
            // List to store valid words
            List<string> words = new List<string>();

            // Read from file and process each word
            using (StreamReader file = new StreamReader(filename))
            {
                // HashSet to store unique hashes of words
                HashSet<int> seen = new HashSet<int>();
                while (!file.EndOfStream)
                {
                    string word = file.ReadLine();
                    // Ignore words that are not of length 5
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
        private void FindUniqueCombinations(string[] words, int[] masks, int start, List<int> currentCombination, int currentMask, ref int combinationsFound, object lockObject, List<List<string>> resultStorage)
        {
            if (currentCombination.Count == 5)
            {
                // Increment combination count and add the combination to result storage
                lock (lockObject)
                {
                    combinationsFound++;
                    resultStorage.Add(currentCombination.Select(index => words[index]).ToList());
                }
                return;
            }

            // Iterate through remaining words to find valid combinations
            for (int i = start; i < words.Length; i++)
            {
                if ((currentMask & masks[i]) == 0)
                {
                    currentCombination.Add(i);
                    FindUniqueCombinations(words, masks, i + 1, currentCombination, currentMask | masks[i], ref combinationsFound, lockObject, resultStorage);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }
        }

        // Method to solve the problem by finding valid word combinations
        public List<List<string>> Solve(string filename)
        {
            // Load and filter words from the file
            string[] words = LoadWords(filename);

            // Create masks for each word
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

            // Initialize variables for counting combinations and locking access
            int combinationsFound = 0;
            object lockObject = new object();
            List<List<string>> resultStorage = new List<List<string>>();

            // Parallelize the search for the first word
            Parallel.For(0, words.Length, i =>
            {
                List<int> localCombination = new List<int> { i };
                FindUniqueCombinations(words, masks, i + 1, localCombination, masks[i], ref combinationsFound, lockObject, resultStorage);
            });

            // Output total combinations found and return the result storage
            Console.WriteLine("Total combinations found: " + combinationsFound);
            return resultStorage;
        }
    }
}

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    class AnagramSolver
    {
        static List<string> LoadWords(string filename)
        {
            List<string> words = new List<string>();
            using (StreamReader file = new StreamReader(filename))
            {
                HashSet<int> seen = new HashSet<int>();
                while (!file.EndOfStream)
                {
                    string word = file.ReadLine();
                    if (word.Length != 5) continue;
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
                    int hash = 0;
                    foreach (char c in sortedWord)
                    {
                        hash = hash * 26 + (c - 'a');
                    }
                    if (seen.Contains(hash)) continue;
                    seen.Add(hash);
                    words.Add(word);
                }
            }
            return words;
        }

        static void OutputAllSets(List<List<bool>> can_construct, List<string> words, List<int> masks, List<int> result, int mask, int start_from)
        {
            if (result.Count == 5)
            {
                foreach (int index in result)
                {
                    Console.Write(words[index] + " ");
                }
                Console.WriteLine();
                return;
            }
            for (int curWord = start_from; curWord < words.Count; ++curWord)
            {
                if (((mask & masks[curWord]) == masks[curWord]) && (result.Count == 4 || can_construct[3 - result.Count][mask ^ masks[curWord]]))
                {
                    result.Add(curWord);
                    OutputAllSets(can_construct, words, masks, result, mask ^ masks[curWord], curWord + 1);
                    result.RemoveAt(result.Count - 1);
                }
            }
        }

        static void Solve(List<string> words)
        {
            List<List<bool>> can_construct = new List<List<bool>>();
            for (int i = 0; i < 5; i++)
            {
                can_construct.Add(new List<bool>(Enumerable.Repeat(false, 1 << 26).ToArray()));
            }
            List<int> masks = new List<int>();
            foreach (string word in words)
            {
                int mask = 0;
                foreach (char c in word)
                {
                    mask |= 1 << (c - 'a');
                }
                masks.Add(mask);
                can_construct[0][mask] = true;
            }
            for (int cnt = 0; cnt < 4; ++cnt)
            {
                for (int mask = 0; mask < (1 << 26); ++mask)
                {
                    if (!can_construct[cnt][mask]) continue;
                    for (int i = 0; i < words.Count; ++i)
                    {
                        if ((masks[i] & mask) == 0)
                        {
                            can_construct[cnt + 1][masks[i] | mask] = true;
                        }
                    }
                }
            }

            Console.WriteLine("DP done");

            List<int> result = new List<int>();
            for (int mask = 0; mask < (1 << 26); ++mask)
            {
                if (can_construct[4][mask])
                {
                    OutputAllSets(can_construct, words, masks, result, mask, 0);
                }
            }
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<string> words = LoadWords("Words.txt");
            Solve(words);

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: " + stopwatch.Elapsed);
        }
    }

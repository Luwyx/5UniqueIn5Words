using System;
using System.Diagnostics;
using TheBrains; 

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\H2Opgaver\5UniqueIn5Words\ConsoleAppRecursive\Words 2.txt";

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Brain anagramSolver = new Brain();
        var combinations = anagramSolver.Solve(path);

        stopwatch.Stop();

        foreach (var combination in combinations)
        {
            Console.WriteLine(string.Join(" ", combination));
        }

        Console.WriteLine("Total combinations found: " + combinations.Count);
        Console.WriteLine("Time elapsed: " + stopwatch.Elapsed);
    }
}

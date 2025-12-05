using System;

namespace AdventOfCode.Lobby;

public static class LobbyRunner
{
    public static void Run()
    {
        var puzzle = """
            
            """;

        var password = puzzle
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => new Bank(line))
            .Select(bank => bank.GetJoltage(maxBatteries: 12))
            .Sum();

        Console.WriteLine($"The sum of the joltage of all banks is: {password}");
    }
}

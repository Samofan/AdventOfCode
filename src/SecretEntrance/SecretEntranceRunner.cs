using AdventOfCode.SecretEntrance.Models;
using AdventOfCode.SecretEntrance.Yeggmen;
using AdventOfCode.SecretEntrance.Yeggmen.Strategies;

namespace AdventOfCode.SecretEntrance;

public static class SecretEntranceRunner
{
    public static void Run()
    {
        var puzzleInput =
            """
            L68
            L30
            R48
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """;

        var rotations = Rotation.FromMultilineInput(puzzleInput);
        var yeggman = new Yeggman(new AnyClickStrategy());
        const int startingPoint = 50;

        var password = yeggman.GetPassword(startingPoint, rotations);

        Console.WriteLine($"The password is {password}.");
    }
}


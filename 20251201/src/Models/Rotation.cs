namespace SecretEntrance.Models;

public sealed class Rotation(char direction, int clicks)
{
    public char Direction { get; } = direction;
    public int Clicks { get; } = clicks;

    public static Rotation Parse(string input)
    {
        var direction = input[0];
        var clicks = int.Parse(input[1..]);

        return new Rotation(direction, clicks);
    }

    public static Rotation[] FromMultilineInput(string input)
    {
        return input
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(Parse)
            .ToArray();
    }
}
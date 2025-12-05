namespace AdventOfCode.InvalidIdentifiers;

public static class InvalidIdentifiersRunner
{
    public static void Run()
    {
        var exampleIds = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        var ranges = Range.ParseMultiple(exampleIds);
        var invalidIds = ranges.SelectMany(r => r.GetInvalidIdentifiers());
        var password = invalidIds.Aggregate((acc, id) => acc + id);

        Console.WriteLine($"The password is: {password}");
    }
}

namespace InvalidIdentifier.Models;

public sealed record class Range(long Min, long Max)
{
    public long DigitsCount 
        => Math.Max((long)Math.Floor(Math.Log10(Min) + 1), (long)Math.Floor(Math.Log10(Max) + 1));

    public IEnumerable<long> GetAllIdentifiers()
    {
        for (long id = Min; id <= Max; id++)
        {
            yield return id;
        }
    }

    public IEnumerable<long> GetInvalidIdentifiers()
    {
        var suitableIds = GetAllIdentifiers()
            .Where(id => (int)Math.Floor(Math.Log10(id) + 1) % 2 == 0);

        var invalidIds = new HashSet<long>();

        foreach (var id in suitableIds)
        {
            long firstHalf = (long)Math.Floor(id / Math.Pow(10, DigitsCount / 2));
            long invalidIdCandidate = long.Parse(firstHalf.ToString() + firstHalf.ToString());
            
            if (invalidIdCandidate >= Min && invalidIdCandidate <= Max)
            {
                invalidIds.Add(invalidIdCandidate);
            }
        }

        return invalidIds;
    }

    public static Range Parse(string input)
    {
        var parts = input.Split('-');
        return new Range(long.Parse(parts[0]), long.Parse(parts[1]));
    }

    public static IEnumerable<Range> ParseMultiple(string input)
    {
        var parts = input.Split(',');
        foreach (var part in parts)
        {
            yield return Parse(part);
        }
    }
}
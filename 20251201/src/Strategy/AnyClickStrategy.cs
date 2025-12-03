using SecretEntrance.Models;

namespace SecretEntrance.Strategy;

public sealed class AnyClickStrategy : IYeggmanStrategy
{
    public int GetPassword(int startingPoint, Rotation[] rotations)
    {
        var leftClickStrategy = new LeftClickStrategy();

        var expanded = rotations
            .SelectMany(r => Enumerable.Range(0, r.Clicks).Select(_ => new Rotation(r.Direction, 1)))
            .ToArray();

        return leftClickStrategy.GetPassword(startingPoint, expanded);
    }
}

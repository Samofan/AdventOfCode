using SecretEntrance.Models;
using SecretEntrance.Yeggman.Strategy;

namespace SecretEntrance.Yeggman;

public sealed class Yeggman(IYeggmanStrategy strategy) : IYeggman
{
    private readonly IYeggmanStrategy _strategy = strategy;

    public int GetPassword(int startingPoint, Rotation[] rotations)
    {
        return _strategy.GetPassword(startingPoint, rotations);
    }

    public static int ApplyNextRotation(int currentPosition, Rotation rotation)
    {
        return rotation.Direction switch
        {
            'L' => (currentPosition - rotation.Clicks) % 100,
            'R' => (currentPosition + rotation.Clicks) % 100,
            _ => throw new ArgumentException("Invalid rotation direction")
        };
    }
}

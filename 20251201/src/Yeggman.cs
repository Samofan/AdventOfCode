namespace SecretEntrance;

public sealed class Yeggman(YeggmanStrategy strategy) : IYeggman
{
    public int GetPassword(int startingPoint, Rotation[] rotations)
    {
        return strategy switch
        {
            YeggmanStrategy.LeftClick => GetPasswordLeftClickStrategy(startingPoint, rotations),
            YeggmanStrategy.AnyClick => GetPasswordAnyClickStrategy(startingPoint, rotations),
            _ => throw new NotImplementedException()
        };
    }

    private static int GetPasswordLeftClickStrategy(int startingPoint, Rotation[] rotations)
    {
        return rotations
            .Aggregate(
                (position: startingPoint, password: 0),
                (state, rotation) =>
                {
                    var newPosition = ApplyNextRotation(state.position, rotation);
                    var newPassword = state.position == 0 ? state.password + 1 : state.password;
                    return (newPosition, newPassword);
                })
            .password;
    }

    private static int GetPasswordAnyClickStrategy(int startingPoint, Rotation[] rotations)
    {
        var expanded = rotations
            .SelectMany(r => Enumerable.Range(0, r.Clicks).Select(_ => new Rotation(r.Direction, 1)))
            .ToArray();

        return GetPasswordLeftClickStrategy(startingPoint, expanded);
    }

    private static int ApplyNextRotation(int currentPosition, Rotation rotation)
    {
        return rotation.Direction switch
        {
            'L' => (currentPosition - rotation.Clicks) % 100,
            'R' => (currentPosition + rotation.Clicks) % 100,
            _ => throw new ArgumentException("Invalid rotation direction")
        };
    }
}

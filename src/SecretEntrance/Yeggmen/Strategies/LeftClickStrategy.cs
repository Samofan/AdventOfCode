using AdventOfCode.SecretEntrance.Models;
using AdventOfCode.SecretEntrance.Yeggmen;

namespace AdventOfCode.SecretEntrance.Yeggmen.Strategies;

public sealed class LeftClickStrategy : IYeggmanStrategy
{
    public int GetPassword(int startingPoint, Rotation[] rotations)
    {
        return rotations
            .Aggregate(
                (position: startingPoint, password: 0),
                (state, rotation) =>
                {
                    var newPosition = Yeggman.ApplyNextRotation(state.position, rotation);
                    var newPassword = state.position == 0 ? state.password + 1 : state.password;
                    return (newPosition, newPassword);
                })
            .password;
    }   
}
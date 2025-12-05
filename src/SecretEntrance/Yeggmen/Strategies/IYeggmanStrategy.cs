using AdventOfCode.SecretEntrance.Models;

namespace AdventOfCode.SecretEntrance.Yeggmen.Strategies;

public interface IYeggmanStrategy
{
    int GetPassword(int startingPoint, Rotation[] rotations);
}

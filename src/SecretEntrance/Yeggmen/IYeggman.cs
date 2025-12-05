using AdventOfCode.SecretEntrance.Models;

namespace AdventOfCode.SecretEntrance.Yeggmen;

public interface IYeggman
{
    int GetPassword(int startingPoint, Rotation[] rotations);
}
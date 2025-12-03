using SecretEntrance.Models;

namespace SecretEntrance.Strategy;

public interface IYeggmanStrategy
{
    int GetPassword(int startingPoint, Rotation[] rotations);
}

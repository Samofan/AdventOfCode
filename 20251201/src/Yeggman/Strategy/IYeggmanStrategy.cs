using SecretEntrance.Models;

namespace SecretEntrance.Yeggman.Strategy;

public interface IYeggmanStrategy
{
    int GetPassword(int startingPoint, Rotation[] rotations);
}

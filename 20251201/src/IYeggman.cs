using SecretEntrance.Models;

namespace SecretEntrance;

public interface IYeggman
{
    int GetPassword(int startingPoint, Rotation[] rotations);
}
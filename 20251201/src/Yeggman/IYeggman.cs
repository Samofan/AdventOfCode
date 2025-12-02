using SecretEntrance.Models;

namespace SecretEntrance.Yeggman;

public interface IYeggman
{
    int GetPassword(int startingPoint, Rotation[] rotations);
}
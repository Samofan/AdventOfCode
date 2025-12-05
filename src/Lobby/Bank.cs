namespace AdventOfCode.Lobby;

public class Bank(string batteryArrangement, int maxBatteries = 2)
{
    private readonly string _batteryArrangement = batteryArrangement.Trim();

    public long GetJoltage()
    {
        HashSet<long> possibleNumbers = [];

        for (int i = 0; i < _batteryArrangement.Length; i++)
        {
            for (int j = i + 1; j < _batteryArrangement.Length; j++)
            {
                string number = _batteryArrangement[i].ToString();

                for (int k = 0; k < maxBatteries - 1; k++)
                {
                    if (j + k >= _batteryArrangement.Length) break;
                    number += _batteryArrangement[j + k].ToString();
                }

                possibleNumbers.Add(long.Parse(number));
            }
        }

        return possibleNumbers.Max();
    }
}

using System.Linq;

namespace AdventOfCode.Lobby;

public class Bank(string batteryArrangement)
{
    private readonly string _batteryArrangement = batteryArrangement.Trim();

    public long GetJoltage(string joltage = "", int startIndex = 0, int maxBatteries = 2)
    {
        if (maxBatteries <= 0 || startIndex >= _batteryArrangement.Length)
        {
            return long.Parse(joltage);
        }

        long highestNumber = long.Parse(_batteryArrangement[startIndex].ToString());
        int foundIndex = startIndex;
        
        for (int i = startIndex + 1; i <= _batteryArrangement.Length - maxBatteries; i++)
        {
            long currentNumber = long.Parse(_batteryArrangement[i].ToString());
            if (currentNumber > highestNumber)
            {
                highestNumber = currentNumber;
                foundIndex = i;
            }
        }

        return GetJoltage(joltage + highestNumber.ToString(), foundIndex + 1, maxBatteries - 1);
    }
}

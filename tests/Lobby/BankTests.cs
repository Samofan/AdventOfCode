using AdventOfCode.Lobby;

using Shouldly;

namespace AdventOfCode.Tests.Lobby;

public class BankTests
{
    [Fact]
    public void GIVEN_BatteryArrangement_WHEN_GetJoltage_THEN_ReturnsExpectedJoltage()
    {
        // Arrange
        var batteryArrangement = "987654321111111";
        var bank = new Bank(batteryArrangement);

        // Act
        var result = bank.GetJoltage();

        // Assert
        result.ShouldBe(98);
    }

    [Fact]
    public void GIVEN_BatteryArrangement_WITH_LeadingWhitespace_WHEN_GetJoltage_THEN_ReturnsExpectedJoltage()
    {
        // Arrange
        var batteryArrangement = "  987654321111111";
        var bank = new Bank(batteryArrangement);

        // Act
        var result = bank.GetJoltage();

        // Assert
        result.ShouldBe(98);
    }

    [Fact]
    public void GIVEN_BatteryArrangement_WITH_TrailingWhitespace_WHEN_GetJoltage_THEN_ReturnsExpectedJoltage()
    {
        // Arrange
        var batteryArrangement = "987654321111111  ";
        var bank = new Bank(batteryArrangement);

        // Act
        var result = bank.GetJoltage();

        // Assert
        result.ShouldBe(98);
    }

    [Fact]
    public void GIVEN_BatteryArrangement_WITH_TwelveMaxBatteries_WHEN_GetJoltage_THEN_ReturnsExpectedJoltage()
    {
        // Arrange
        var batteryArrangement = "234234234234278";
        var bank = new Bank(batteryArrangement);

        // Act
        var result = bank.GetJoltage(maxBatteries: 12);

        // Assert
        result.ShouldBe(434234234278);
    }

    [Fact]
    public void GIVEN_BatteryArrangement_WITH_TwelveMaxBatteries_WHEN_GetJoltage_THEN_ReturnsExpectedJoltage_2()
    {
        // Arrange
        var batteryArrangement = "818181911112111";
        var bank = new Bank(batteryArrangement);

        // Act
        var result = bank.GetJoltage(maxBatteries: 12);

        // Assert
        result.ShouldBe(888911112111);
    }

    [Fact]
    public void GIVEN_BatteryArrangement_WITH_TwelveMaxBatteries_WHEN_GetJoltage_THEN_ReturnsExpectedJoltage_3()
    {
        // Arrange
        var batteryArrangement = "811111111111119";
        var bank = new Bank(batteryArrangement);

        // Act
        var result = bank.GetJoltage(maxBatteries: 12);

        // Assert
        result.ShouldBe(811111111119);
    }
}

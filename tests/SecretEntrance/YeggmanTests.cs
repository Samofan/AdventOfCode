using AdventOfCode.SecretEntrance.Models;
using AdventOfCode.SecretEntrance.Yeggmen;
using AdventOfCode.SecretEntrance.Yeggmen.Strategies;

using Shouldly;

namespace AdventOfCode.Tests.SecretEntrance;

public class YeggmanTests
{
    [Fact]
    public void GIVEN_ExampleStartingPoint_WITH_ExampleRotations_WHEN_GetPassword_THEN_ReturnsLeftClickExampleSolution()
    {
        // Arrange
        Rotation[] rotations =
        [
            new('L', 68),
            new('L', 30),
            new('R', 48),
            new('L', 5),
            new('R', 60),
            new('L', 55),
            new('L', 1),
            new('L', 99),
            new('R', 14),
            new('L', 82)
        ];

        const int startingPoint = 50;

        var sut = new Yeggman(new LeftClickStrategy());

        // Act
        var result = sut.GetPassword(startingPoint, rotations);

        // Assert
        result.ShouldBe(3);
    }

    [Fact]
    public void GIVEN_ExampleStartingPoint_WITH_ExampleRotations_WHEN_GetPassword_THEN_ReturnsAnyClickExampleSolution()
    {
        // Arrange
        Rotation[] rotations =
        [
            new('L', 68),
            new('L', 30),
            new('R', 48),
            new('L', 5),
            new('R', 60),
            new('L', 55),
            new('L', 1),
            new('L', 99),
            new('R', 14),
            new('L', 82)
        ];

        const int startingPoint = 50;

        var sut = new Yeggman(new AnyClickStrategy());

        // Act
        var result = sut.GetPassword(startingPoint, rotations);

        // Assert
        result.ShouldBe(6);
    }
}

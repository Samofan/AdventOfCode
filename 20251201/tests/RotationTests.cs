using SecretEntrance.Models;
using Shouldly;

namespace SecretEntrance.Tests;

public class RotationTests
{
    [Fact]
    public void GIVEN_SingleLineString_WITH_LeftRotation_WHEN_Parsing_THEN_ReturnsCorrectRotation()
    {
        // Arrange
        var leftRotationString = "L13";

        // Act
        var result = Rotation.Parse(leftRotationString);

        // Assert
        result.Direction.ShouldBe('L');
        result.Clicks.ShouldBe(13);
    }

    [Fact]
    public void GIVEN_SingleLineString_WITH_RightRotation_WHEN_Parsing_THEN_ReturnsCorrectRotation()
    {
        // Arrange
        var leftRotationString = "R12";

        // Act
        var result = Rotation.Parse(leftRotationString);

        // Assert
        result.Direction.ShouldBe('R');
        result.Clicks.ShouldBe(12);
    }

    [Fact]
    public void GIVEN_MultilineString_WITH_Rotations_WHEN_ParsingMultilineString_THEN_ReturnsCorrectRotations()
    {
        // Arrange
        var multilineRotationString = 
        """
        R13
        L12
        L1
        R2
        """;

        // Act
        var result = Rotation.FromMultilineInput(multilineRotationString);

        // Assert
        result.Length.ShouldBe(4);
        
        result[0].Direction.ShouldBe('R');
        result[0].Clicks.ShouldBe(13);

        result[1].Direction.ShouldBe('L');
        result[1].Clicks.ShouldBe(12);

        result[2].Direction.ShouldBe('L');
        result[2].Clicks.ShouldBe(1);

        result[3].Direction.ShouldBe('R');
        result[3].Clicks.ShouldBe(2);
    }
}

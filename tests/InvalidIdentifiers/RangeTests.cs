using Range = AdventOfCode.InvalidIdentifiers.Range;

using Shouldly;

namespace AdventOfCode.Tests.InvalidIdentifiers;

public class RangeTests
{
    [Fact]
    public void GIVEN_String_WITH_MultipleIds_WHEN_ParseMultiple_THEN_ReturnsCorrectRanges()
    {
        // Arrange
        var exampleIds = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
    
        // Act
        var result = Range.ParseMultiple(exampleIds);

        // Assert
        result.Count().ShouldBe(11);
        result.ElementAt(0).ShouldBe(new Range(11, 22));
        result.ElementAt(1).ShouldBe(new Range(95, 115));
        result.ElementAt(10).ShouldBe(new Range(2121212118, 2121212124));
    }

    [Fact]
    public void GIVEN_String_WITH_SingleIdRange_WHEN_Parse_THEN_ReturnsCorrectRange()
    {
        // Arrange
        var exampleId = "100-200";

        // Act
        var result = Range.Parse(exampleId);

        // Assert
        result.ShouldBe(new Range(100, 200));
    }

    [Fact]
    public void GIVEN_Range_WITH_MaxHigherCount_WHEN_CountDigits_THEN_ReturnsCorrectDigitCount()
    {
        // Arrange
        var maxHigher = new Range(100, 2000);

        // Act
        var result = maxHigher.DigitsCount;

        // Assert
        result.ShouldBe(4);
    }

    [Fact]
    public void GIVEN_Range_WITH_NumberGreaterThanIntegerMax_WHEN_GetInvalidIdentifiers_THEN_ReturnsCorrectIds()
    {
        // Arrange
        var range = new Range(3434061167, 3434167492);

        // Act
        var result = range.GetInvalidIdentifiers();

        // Assert
        result.ShouldBe([3434134341]);
    }

    [Fact]
    public void GIVEN_Range_WITH_MinHigherCount_WHEN_CountDigits_THEN_ReturnsCorrectDigitCount()
    {
        // Arrange
        var minHigher = new Range(2000, 100);

        // Act
        var result = minHigher.DigitsCount;

        // Assert
        result.ShouldBe(4);
    }

    [Fact]
    public void GIVEN_Range_WITH_InvalidIdentifiers_WHEN_GetInvalidIdentifiers_THEN_ReturnsCorrectIds()
    {
        // Arrange
        var exampleIds = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        var ranges = Range.ParseMultiple(exampleIds);

        // Act
        var result = ranges.SelectMany(r => r.GetInvalidIdentifiers());

        // Assert
        result.ShouldBe([11, 22, 99, 1010, 1188511885, 222222, 446446, 38593859]);
    }
}

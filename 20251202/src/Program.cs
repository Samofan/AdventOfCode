using Range = InvalidIdentifier.Models.Range;


var exampleIds = "";
var ranges = Range.ParseMultiple(exampleIds);
var invalidIds = ranges.SelectMany(r => r.GetInvalidIdentifiers());
var password = invalidIds.Aggregate((acc, id) => acc + id);

Console.WriteLine($"The password is: {password}");
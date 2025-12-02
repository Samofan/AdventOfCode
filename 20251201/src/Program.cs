using SecretEntrance;
using SecretEntrance.Models;

var puzzleInput = 
"""
L68
L30
R48
L5
R60
L55
L1
L99
R14
L82
""";

var rotations = Rotation.FromMultilineInput(puzzleInput);
var yeggman = new Yeggman(new AnyClickStrategy());

var password = yeggman.GetPassword(50, rotations);

Console.WriteLine($"The password is {password}.");
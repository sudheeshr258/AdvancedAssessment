
using AdvancedAssessment.Models;
using AdvancedAssessment.Services.Implementations;

Console.WriteLine("Hi there, now you can control the Mars Rover");
var result = 'Y';
var grid = new Grid
{
    Row = 1,
    Coloumn = 1
};
var rover = new Mars(grid, 0);
var roverMover = new RoverMover(rover);

while (result == 'Y')
{
    var commands = new List<string>();

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Enter the {i + 1}th command");
        commands.Add(Console.ReadLine().ToString());
    }
    rover.RoverStatus = true;
    foreach (var command in commands)
    {
        roverMover.MoveRover(command);
    }

    var direction = roverMover.FindDirection(rover.Direction);
    var position = rover[rover.RoverPosition];

    Console.WriteLine($"Current rover posistion is {position},{direction}");

    Console.WriteLine("Would you like to continue? (Y or N)");
    result = Char.ToUpper(Convert.ToChar(Console.Read()));
    Console.ReadLine();
}





namespace AdvancedAssessment.Services.Interfaces
{
    public interface IRoverMover
    {
        /// <summary>
        /// Moves rover based on the command.
        /// </summary>
        /// <param name="command"></param>
        public void MoveRover(string command);

        /// <summary>
        /// Helps to get the direction on Rover.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public string FindDirection(int direction);
    }
}

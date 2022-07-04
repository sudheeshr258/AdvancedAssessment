

namespace AdvancedAssessment.Models
{
    /// <summary>
    /// This class represents the Mars.
    /// </summary>
    public class Mars
    {
        public Mars(Grid grid, int direction)
        {
            RoverPosition = grid;
            Direction = direction;
            RoverStatus = true;
        }

        /// <summary>
        /// 0 - South, 1- East , 2- North, 3- West
        /// </summary>
        public int Direction { get; set; }

        public Grid RoverPosition { get; set; }

        public bool RoverStatus { get; set; }

        public int this[Grid grid]
        {
            get
            {
                return (grid.Row - 1) * 100 + grid.Coloumn;
            }

        }
    }
}

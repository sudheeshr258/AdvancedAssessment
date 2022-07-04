using AdvancedAssessment.Models;
using AdvancedAssessment.Services.Interfaces;

namespace AdvancedAssessment.Services.Implementations
{
    /// <summary>
    /// This class provides methods useful to move the Rover on Mars.
    /// </summary>
    public class RoverMover : IRoverMover
    {
        private readonly Mars _mars;

        public RoverMover(Mars gridPanel)
        {
            this._mars = gridPanel;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="command"></param>
        public void MoveRover(string command)
        {
            if (_mars.RoverStatus is true)
            {
                if (command.ToUpper() == "LEFT")
                {
                    _mars.Direction = _mars.Direction + 1 > 3 ? 0 : _mars.Direction + 1;

                }

                else if (command.ToUpper() == "RIGHT")
                {
                    _mars.Direction = _mars.Direction < 0 ? 0 : _mars.Direction - 1;
                }

                else
                {
                    if (command.EndsWith('m') || command.EndsWith('M'))
                        command = command.Remove(command.Length - 1, 1);
                    int.TryParse(command, out var distance);

                    if (_mars.Direction == 0)
                    {
                        var grid = new Grid
                        {
                            Coloumn = _mars.RoverPosition.Coloumn
                        };

                        if (_mars.RoverPosition.Row + distance > 100)
                        {
                            grid.Row = _mars.RoverPosition.Row;
                            _mars.RoverStatus = false;
                            return;
                        }
                        grid.Row = _mars.RoverPosition.Row + distance;
                        _mars.RoverPosition = grid;
                    }

                    if (_mars.Direction == 1)
                    {
                        var grid = new Grid
                        {
                            Row = _mars.RoverPosition.Row
                        };
                        if (_mars.RoverPosition.Coloumn + distance > 100)
                        {
                            grid.Coloumn = _mars.RoverPosition.Coloumn;
                            _mars.RoverStatus = false;
                            return;
                        }
                        grid.Coloumn = _mars.RoverPosition.Coloumn + distance;
                        _mars.RoverPosition = grid;
                    }

                    if (_mars.Direction == 3)
                    {
                        var grid = new Grid
                        {
                            Row = _mars.RoverPosition.Row
                        };
                        if (_mars.RoverPosition.Coloumn - distance < 0)
                        {
                            grid.Coloumn = _mars.RoverPosition.Coloumn;
                            _mars.RoverStatus = false;
                            return;
                        }
                        grid.Coloumn = _mars.RoverPosition.Coloumn - distance;
                        _mars.RoverPosition = grid;
                    }

                    if (_mars.Direction == 2)
                    {
                        var grid = new Grid
                        {
                            Coloumn = _mars.RoverPosition.Coloumn
                        };

                        if (_mars.RoverPosition.Row - distance < 0)
                        {
                            grid.Row = _mars.RoverPosition.Row;
                            _mars.RoverStatus = false;
                            return;
                        }
                        grid.Row = _mars.RoverPosition.Row - distance;
                        _mars.RoverPosition = grid;
                    }

                }
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="direction">integer value of direction</param>
        /// <returns>Actual direction</returns>
        public string FindDirection(int direction)
        {
            return direction switch
            {
                0 => "South",
                1 => "East",
                2 => "North",
                3 => "West",
                _ => "",
            };
        }
    }
}

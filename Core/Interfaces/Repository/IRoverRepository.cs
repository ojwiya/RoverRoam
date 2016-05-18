using System.Collections.Generic;
using Core.Models;


namespace Core.Interfaces
{
    public interface IRoverRepository
    {
        void SavePositions(Rover Rover);
        Rover GetRover(Rover Rover);
        Rover[] GetRovers(Rover Rover);

    }
}
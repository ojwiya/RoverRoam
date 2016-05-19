using Core.Models;
using System;
namespace Core.Interfaces
{
    public interface IPositionService
    {
        int ConvertBearingToDegree(string bearing);
        string ConvertDegreeToBearing(int degree);
        void SetNewPosition(Rover rover);
    }
}

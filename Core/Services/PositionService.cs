using System.Collections.Generic;
using Core.Interfaces;
using Core.Models;
using System;

namespace Core.Services
{
    public class PositionService : IPositionService
    {
        private int[,] _plateau;

        public int ConvertBearingToDegree(string bearing)
        {
            int degree;
            switch (bearing)
            {
                case "N":
                    degree = 360;
                    break;
                case "S":
                    degree = 180;
                    break;
                case "W":
                    degree = 270;
                    break;
                case "E":
                    degree = 90;
                    break;
                default:
                    degree = -1;
                    break;
            }

            return degree;

        }

        public string ConvertDegreeToBearing(int degree)
        {
            string bearing;
            switch (degree)
            {
                case 360:
                    bearing = "N";
                    break;
                case 180:
                    bearing = "S";
                    break;
                case 270:
                    bearing = "W";
                    break;
                case 90:
                    bearing = "E";
                    break;
                default:
                    bearing = "";
                    break;
            }

            return bearing;

        }

        public void SetNewPosition(Rover rover)
        {
            switch (rover.Bearing.Abbreviation)
            {
                case "N":
                    GoNorth(rover.CurrentPosition);
                    break;
                case "S":
                    GoSouth(rover.CurrentPosition);
                    break;
                case "W":
                    GoWest(rover.CurrentPosition);
                    break;
                case "E":
                    GoEast(rover.CurrentPosition);
                    break;
  
            }
            
        }

        private void GoWest(Position pos)
        {
            pos.X = pos.X - 1;
        }

        private void GoEast(Position pos)
        {
            pos.X = pos.X + 1;
        }

        private void GoNorth(Position pos)
        {
            pos.Y =  pos.Y + 1;
        }

        private void GoSouth(Position pos)
        {
            pos.Y = pos.Y - 1;
        } 

    }
}

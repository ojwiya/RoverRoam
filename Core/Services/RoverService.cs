using System.Collections.Generic;
using Core.Interfaces;
using Core.Models;
using System;

namespace Core.Services
{
    public class RoverService : IRoverService
    {
        private readonly IPositionService _positionService;
        private int[,] _plateau;

        public RoverService(IPositionService positionService)
        {
            _positionService = positionService; 
        }

        public string[] Roam(string plateauSize, Instruction[] instructions)
        {
        
            // Generate plateau grid -- Array
           GeneratePlateauGrid(plateauSize);
           
          // Iterate through rover instructions and execute
           var rovers = ProcessInstructions(instructions);

           return GetFinalPositions(rovers);   
        }
        
        private void GeneratePlateauGrid(string plateauSize)
        {
            string[] size = plateauSize.Split(' ');
            int h = Convert.ToInt16(size[0]);
            int w = Convert.ToInt16(size[1]);

            _plateau = new int[h,w];
        }

       
        private Rover[] ProcessInstructions(Instruction[] instructions)
        {

            // Translate input into structured data model
            Rover[] roverData = PrepareRoverData(instructions);

            // Iterate through data structure and update shift rover.
            MoveRovers(roverData);

            return roverData;
        }
        
        private Rover[] PrepareRoverData(Instruction[] instructions)
        {
            Rover[] results = new Rover[instructions.Length];

            for (int i = 0; i < instructions.Length; i++)
			{
                Rover rover = new Rover();

                rover.Id = instructions[i].RoverId;
                rover.Instruction = instructions[i].Movements.ToCharArray();
                rover.StartPosition = GetPositionFromInstructions(instructions[i].StartPosition);
                rover.CurrentPosition = rover.StartPosition;
                rover.Bearing = GetBearingsFromInstructions(instructions[i].StartPosition);

                results[i] = rover;
			}

            return results;
        }

        private void MoveRovers(Rover[] roverInstructions)
        {
            foreach (var r in roverInstructions)
            {
                foreach (var command in r.Instruction)
                {
                    Execute(command, r);  
                }
                        
            }

        }

        private void Execute(char command, Rover rover)
        {
            //execute instructions
            switch (command)
            {
                case 'L':
                    rover.Bearing.Degree = ValidateAngle(rover.Bearing.Degree - 90);
                    rover.Bearing.Abbreviation = _positionService.ConvertDegreeToBearing(
                rover.Bearing.Degree); 
                    break;
                case 'R':
                    rover.Bearing.Degree = ValidateAngle(rover.Bearing.Degree + 90);
                    rover.Bearing.Abbreviation = _positionService.ConvertDegreeToBearing(
                                                        rover.Bearing.Degree); 
                    break;
                case 'M':
                    _positionService.SetNewPosition(rover); 
                    break;
                default:
                    break;
            }


        }
       
        private Position GetPositionFromInstructions(string startPosition)
        {
            var _startPosition = startPosition.Split(' ');
            return new Position()
            {
                X = Convert.ToInt16(_startPosition[0]),
                Y = Convert.ToInt16(_startPosition[1])
            };
        }

        private Bearing GetBearingsFromInstructions(string startPosition)
        {
            var _startPosition = startPosition.Split(' ');
            return new Bearing()
            {
                Abbreviation = _startPosition[2],
                Degree = _positionService.ConvertBearingToDegree(_startPosition[2])
            };
        }
        
        private int ValidateAngle(int angle)
        {
            if (angle > 360) {
                return angle % 360;
            }
            else if (angle <= 0) {
                return 360-(angle % 360);
            }

            return angle;
        }
       
         private string[] GetFinalPositions(Rover[] rovers)
        {
            string[] positions = new string[rovers.Length];            
            for (int i = 0; i < rovers.Length; i++)
			{
                positions[i] = rovers[i].CurrentPosition.X 
                                + " " +  rovers[i].CurrentPosition.Y
                                + " " + rovers[i].Bearing.Abbreviation;
			}

            return positions;
        }

    }
}

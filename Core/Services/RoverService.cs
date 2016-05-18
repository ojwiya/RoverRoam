using System.Collections.Generic;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class RoverService : IRoverService
    {
        //private readonly IRoverRepository _roverRepository;

        public RoverService(/*IRoverRepository roverRepository*/)
        {
            //_roverRepository = roverRepository;
        }

        public string[] Roam(string plateauSize, Instruction[] instructions)
        {
          
           string[] result = { "" };
        // Generate plateau grid -- Array

          // Interprete input into data structures

          // Iterate through controllers 
        
             return result;   


        }

    }
}

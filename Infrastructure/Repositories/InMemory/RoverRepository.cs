using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Core.Interfaces;
using Core.Models;
using Newtonsoft.Json;


namespace Infrastructure.Repositories
{
    public class RoverRepository : IRoverRepository
    {

        public void SavePositions(Rover Rover)
        {
            throw new NotImplementedException();
        }

        public Rover GetRover(Rover Rover)
        {
            throw new NotImplementedException();
        }

        public Rover[] GetRovers(Rover Rover)
        {
            throw new NotImplementedException();
        }
    }
}
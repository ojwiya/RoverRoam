using System.Collections.Generic;
using Core.Models;


namespace Core.Interfaces
{
    public interface IRoverService
    {
        string[] Roam(string plateauSize, Instruction[] instructions); 

    }
}
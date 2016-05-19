using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
   {

       public class Rover{
            public Int32 Id {get;set;}
            public Position CurrentPosition {get;set;}
            public Position StartPosition { get; set; }
            public Bearing Bearing { get; set; }
            public int CurrentInstruction {get;set;}
            public Boolean IsComplete {get;set;}
            public Char[] Instruction {get;set;}
          
    }
}

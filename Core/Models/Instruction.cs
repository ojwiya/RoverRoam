using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Instruction
    {
        public int RoverId { get; set; }
        public string StartPosition { get; set; }
        public string Movements { get; set; }
    }
}

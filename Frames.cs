using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Frames
    {
        public int rollI { get; set; }
        public int rollII { get; set; }
        public int rollIII { get; set; }
        public int framePosition { get; set; }
        public int total { get; set; }        
        public int bonus { get; set; }

        public Frames ()
        {
            rollI = -1;
            rollII = -1;
            rollIII = -1;
            framePosition = 0;
            total = 0;            
            bonus = 0;
        }
    }
}

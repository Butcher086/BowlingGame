using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            BowlingGame b = new BowlingGame();

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            //tirada 10
            b.roll(2);
            b.roll(8);
            b.roll(6);           

            b.score();
        }
    }
}

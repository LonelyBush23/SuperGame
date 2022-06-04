using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public class Barrier : Essence
    {
        public bool BarrierWithTrap;
        public Barrier(int x, int y)
        {
            PosX = x;
            PosY = y;
            EssenceName = EssenceName.Barrier;
        }
    }
}

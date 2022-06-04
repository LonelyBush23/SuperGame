using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public class GameBarrier : Essence
    {
        public bool BarrierWithTrap;
        public GameBarrier(int x, int y)
        {
            PosX = x;
            PosY = y;
            EssenceName = EssenceName.Barrier;
        }
    }
}

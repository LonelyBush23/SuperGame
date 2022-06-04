using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public enum TrapBehaviour
    {
        OpenAllTime,
        CloseAllTime,
        Open,
        Close
    }
    public class Trap : Essence
    {
        public Trap(int x, int y)
        {
            PosX = x;
            PosY = y;
            EssenceName = EssenceName.Trap;
        }
    }
}

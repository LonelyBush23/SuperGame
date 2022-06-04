using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public enum EssenceName
    {
        Barrier,
        Enemy,
        Trap,
        Floor,
        Empty,
        Wall,
        Soul
    }

    public class Essence
    {
        public int PosX { get; private protected set; }
        public int PosY { get; private protected set; }
        public EssenceName EssenceName { get; private protected set; }

        public void Move(int dirX, int dirY)
        {
            PosX += dirX;
            PosY += dirY;
        }
    }

}

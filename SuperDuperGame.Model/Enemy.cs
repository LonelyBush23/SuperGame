using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public class Enemy : Essence
    {
        public Enemy(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public void MoveByPush(int dirX, int dirY)
        {
            PosX += dirX;
            PosY += dirY;
        }
    }
}

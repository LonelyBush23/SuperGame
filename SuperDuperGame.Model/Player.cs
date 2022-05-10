using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public class Player : Essence
    {
        public Player (int x, int y)
        {
            PosX = x;
            PosY = y;
            EssenceName = EssenceName.Barrier;
        }

        public void Move (int dirX, int dirY)
        {
            PosX += dirX;
            PosY += dirY;
        }

    }
}


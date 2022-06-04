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
        private bool availabilityOfSoul = false;
        public Player (int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public void AvailabilityOfSoulSetTrue()
        {
            availabilityOfSoul = true;
        }

        public bool HaveSoul()
        {
            return availabilityOfSoul;
        }
    }
}


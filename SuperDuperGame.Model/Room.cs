using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public class Room
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Room(int width, int height)
        {
            Width = width;
            Height = height;    
        }
    }
}

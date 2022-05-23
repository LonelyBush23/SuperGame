using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public class Room 
    {
        public EssenceName[,] room { get; set; }
        public int width { get; protected set; }
        public int height { get; protected set; }

        public Room(int width, int height)
        {
            this.width = width*64;
            this.height = height*64;
            room = new EssenceName[this.width, this.height];

            for (var i = 0; i < this.width; i+=64)
            for (var j = 0; j < this.height; j+=64)
            {
                room[i, j] = EssenceName.Empty;
            }
        }
    }
}

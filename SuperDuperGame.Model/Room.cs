using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public class Room 
    {
        public Essence[,] room { get; set; }
        public int width { get; protected set; }
        public int height { get; protected set; }

        public Room(int width, int height)
        {
            this.width = width*64;
            this.height = height*64;
            room = new Essence[this.width, this.height];

            for (var i = 0; i < this.width; i+=64)
            for (var j = 0; j < this.height; j+=64)
            {
                room[i, j] = new Empty();
            }
        }

        public void Move(Essence essence, int x, int y)
        {
            room[essence.PosX, essence.PosY] = new Floor();
            room[essence.PosX + x, essence.PosY + y] = essence;
            essence.Move(x , y);
        }
    }
}

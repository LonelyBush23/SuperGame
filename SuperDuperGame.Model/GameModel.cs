using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public class GameModel
    {
        public Player Player { get; set; }
        public List<Enemy> Enemys = new List<Enemy>();
        public List<Trap> Traps = new List<Trap>();
        public List<GameBarrier> Barriers = new List<GameBarrier>();
        public TrapBehaviour TrapsBehaviour;
        public Room Room { get; set; }
        public StepCount StepCount { get; set; }
        public readonly int LvlNumber;

        public GameModel(Point posPlayer, Point roomSize, int[,] map, int stepCount, TrapBehaviour trapBehaviour)
        {
            Room = new Room(roomSize.X, roomSize.Y);
            StepCount = new StepCount(stepCount);
            TrapsBehaviour = trapBehaviour;
            Player = new Player(posPlayer.X, posPlayer.Y);

            for (var i = 0; i < Room.width; i += 64)
            for (var j = 0; j < Room.height; j += 64)
            {
                var di = i / 64;
                var dj = j / 64;

                if (map[dj, di] == 0)
                {
                    Room.room[i, j] = new Empty();
                }

                if (map[dj, di] == 1)
                {
                    Room.room[i, j] = new Floor();
                }

                if (map[dj, di] == 2)
                {
                    Room.room[i, j] = new Wall();
                }

                if (map[dj, di] == 5)
                {
                    Room.room[i, j] = new GameBarrier(i, j);
                    Barriers.Add(new GameBarrier(i,j));
                }

                if (map[dj, di] == 3)
                {
                    Room.room[i, j] = new Enemy(i, j);
                    Enemys.Add(new Enemy(i , j));
                }

                if (map[dj, di] == 4)
                {
                    Room.room[i, j] = new Trap(i, j);
                    Traps.Add(new Trap(i, j));
                }
                if (map[dj, di] == 6)
                {
                    Room.room[i, j] = new Soul();
                }
                if (map[dj, di] == 7)
                {
                    Room.room[i, j] = new GameBarrier(i, j) {BarrierWithTrap = true};
                    Barriers.Add(new GameBarrier(i, j));
                    Traps.Add(new Trap(i, j));
                }
            }
        }

        public Point PlayerNextPosition(Player player, Point dirMove) 
        {
            return new Point(player.PosX + dirMove.X, player.PosY + dirMove.Y);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
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
        public List<Barrier> Barriers = new List<Barrier>();
        public Room Room { get; set; }

        public GameModel(Point posPlayer, Point roomSize, int[,] map)
        {
            Room = new Room(roomSize.X, roomSize.Y);

            for (var i = 0; i < Room.width; i += 64)
            for (var j = 0; j < Room.height; j += 64)
            {
                if (map[j / 64, i / 64] == 1)
                    Room.room[i,j] = EssenceName.Air;
                if (map[j / 64, i / 64] == 2)
                    Room.room[i, j] = EssenceName.Barrier;
                if (map[j / 64, i / 64] == 3)
                    Room.room[i, j] = EssenceName.Enemy;
                if (map[j / 64, i / 64] == 4)
                    Room.room[i, j] = EssenceName.Trap;
            }

            //foreach (var point in posBarriers)
            //{
            //    Room.room[point.X, point.Y] = EssenceName.Barrier;
            //}

            //foreach (var point in posEnemys)
            //{ 
            //    Room.room[point.X, point.Y] = EssenceName.Enemy;
            //}

            //foreach (var point in posTraps)
            //{
            //    Room.room[point.X, point.Y] = EssenceName.Trap;
            //}

            Player = new Player(posPlayer.X, posPlayer.Y);

            //foreach (var posBar in posBarriers)
                //Barriers.Add(new Barrier(posBar.X, posBar.Y));

            //foreach (var posEn in posEnemys)
            //    Enemys.Add(new Enemy(posEn.X, posEn.Y));

            //foreach (var posTr in posTraps)
            //    Traps.Add(new Trap(posTr.X, posTr.Y));
        }

        public Point PlayerNextPosition(Player player, Point dirMove) 
        {
            return new Point(player.PosX + dirMove.X, player.PosY + dirMove.Y);
        }

        //public EssenceName GetEssenceName<T>(int x, int y) where T : Essence
        //{
            
        //}
    }
}

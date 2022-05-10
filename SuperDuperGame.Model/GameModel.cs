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
        public List<Barrier> Barriers = new List<Barrier>();
        public Room Room { get; set; }

        public GameModel(Point posPlayer, Point[] posBarriers)
        {
            Player = new Player(posPlayer.X, posPlayer.Y);
            Room = new Room(736, 895);
            foreach (var posBar in posBarriers)
                Barriers.Add(new Barrier(posBar.X, posBar.Y));
        }

        public Point NextPosition<T>(T essence, Point dirMove) where  T : Essence
        {
            return new Point(essence.PosX + dirMove.X, essence.PosY + dirMove.Y);
        }

        //public EssenceName GetEssenceName<T>(int x, int y) where T : Essence
        //{
            
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SuperDuperGame.Model;

namespace SuperDuperGame
{
    class RoomView
    {
        private readonly Room room;
        public Image AirSprite;
        public Image EmptySprite;

        public RoomView(Room room, string sprite)
        {
            this.room = room;
            AirSprite = new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                sprite));
            EmptySprite = new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                new Sprites().empty));

        }

        public void View(Graphics e, EssencesView<Barrier> barrier, EssencesView<Trap> trapView, EssencesView<Enemy> enemyView)
        {
            for (var i = 0; i < room.width; i+=64)
            for (var j = 0; j < room.height; j+=64)
            {
                if (room.room[i,j] == EssenceName.Air)
                    e.DrawImage(AirSprite, i, j);
                if (room.room[i,j] == EssenceName.Barrier)
                    e.DrawImage(barrier.sprite, i, j);
                if (room.room[i, j] == EssenceName.Trap)
                    e.DrawImage(trapView.sprite, i, j);
                if (room.room[i, j] == EssenceName.Enemy)
                    e.DrawImage(enemyView.sprite, i, j);
                if (room.room[i, j] == EssenceName.Empty)
                    e.DrawImage(EmptySprite, i, j);
            }
        }
    }
}

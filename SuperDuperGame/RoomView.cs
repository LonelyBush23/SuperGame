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
        private readonly string mapName;
        public Sprites Sprites = new Sprites();


        public RoomView(Room room, string mapName)
        {
            this.room = room;
            this.mapName = mapName;
        }

        public void View(Graphics e, List<EssenceView<Barrier>> barrierView, List<EssenceView<Trap>> trapView, TrapBehaviour trapBehaviour , List<EssenceView<Enemy>> enemyView)
        {
            e.DrawImage(Sprites.MakeSprite(mapName), 0, 0);
            for (var i = 0; i < room.width; i+=64)
            for (var j = 0; j < room.height; j+=64)
            {
                if (room.room[i, j].EssenceName == EssenceName.Barrier)
                {
                    if (barrierView.Select(x => x).First(x => x.essence.PosX == i && x.essence.PosY == j).essence
                            .BarrierWithTrap == true)
                    {
                        foreach (var trap in trapView)
                        {
                            e.DrawImage(trapBehaviour == TrapBehaviour.Open || trapBehaviour == TrapBehaviour.OpenAllTime ? trap.sprite : Sprites.MakeSprite(Sprites.trapSpriteS), i, j);
                        }
                    }
                    e.DrawImage(
                        barrierView.Select(x => x).First(x => x.essence.PosX == i && x.essence.PosY == j).sprite, i, j);
                }

                if (room.room[i, j].EssenceName == EssenceName.Trap)
                {
                    foreach (var trap in trapView)
                    {
                        e.DrawImage(trapBehaviour == TrapBehaviour.Open || trapBehaviour == TrapBehaviour.OpenAllTime ? trap.sprite : Sprites.MakeSprite(Sprites.trapSpriteS), i, j);
                    }
                }

                if (room.room[i, j].EssenceName == EssenceName.Soul)
                {
                    e.DrawImage(Sprites.MakeSprite(Sprites.soul), i, j);
                }

                if (room.room[i, j].EssenceName == EssenceName.Enemy)
                {
                    if (enemyView.Select(x => x).First(x => x.essence.PosX == i && x.essence.PosY == j).essence
                            .EnemyWithTrap == true)
                    {
                        foreach (var trap in trapView)
                        {
                            e.DrawImage(trapBehaviour == TrapBehaviour.Open || trapBehaviour == TrapBehaviour.OpenAllTime ? trap.sprite : Sprites.MakeSprite(Sprites.trapSpriteS), i, j);
                        }
                    }
                    e.DrawImage(enemyView.Select(x => x).First(x => x.essence.PosX == i && x.essence.PosY == j).sprite,
                        i, j);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using SuperDuperGame.Model;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace SuperDuperGame
{
    partial class Form1 : Form
    {
        private readonly Sprites sprites = new Sprites();
        private EssencesView<Barrier> barrierView;
        private EssencesView<Trap> trapView;
        private EssencesView<Enemy> enemyView;
        private EssenceView<Player> playerView;
        private RoomView roomView;
        private GameModel gameModel;

         public Form1()
        {
            InitializeComponent();
            Init();
            Invalidate();
        }

        public void Init()
        {
            Size = new Size(624, 647);
            gameModel = new GameModel(new Point(512,384), new Point(20,10), new Lvl().air);
            playerView = new EssenceView<Player>(gameModel.Player, sprites.playerSpriteS);
            barrierView = new EssencesView<Barrier>(gameModel.Barriers, sprites.barrierSpriteS);
            trapView = new EssencesView<Trap>(gameModel.Traps, sprites.trapSpriteS);
            enemyView = new EssencesView<Enemy>(gameModel.Enemys, sprites.enemySpriteS);
            roomView = new RoomView(gameModel.Room, sprites.room);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            roomView.View(e.Graphics, barrierView, trapView, enemyView);
            //barrierView.View(e.Graphics);
            //trapView.View(e.Graphics);
            //enemyView.View(e.Graphics);
            playerView.View(e.Graphics);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                {
                    var nextPos = gameModel.PlayerNextPosition(gameModel.Player, new Point(64, 0));
                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Air 
                        || gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Trap)
                        gameModel.Player.Move(64, 0);

                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Barrier)
                    {
                        if (gameModel.Room.room[nextPos.X+64, nextPos.Y] == EssenceName.Barrier || gameModel.Room.room[nextPos.X + 64, nextPos.Y] == EssenceName.Empty)
                            gameModel.Player.Move(0,0);
                        else
                        {
                            gameModel.Player.Move(64,0);
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY] = EssenceName.Air;
                            gameModel.Room.room[gameModel.Player.PosX + 64, gameModel.Player.PosY] = EssenceName.Barrier;
                        }
                    }

                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Enemy)
                    {
                        if (gameModel.Room.room[nextPos.X + 64, nextPos.Y] == EssenceName.Barrier || gameModel.Room.room[nextPos.X + 64, nextPos.Y] == EssenceName.Empty)
                        {
                            gameModel.Player.Move(0, 0);
                            gameModel.Room.room[nextPos.X, nextPos.Y] = EssenceName.Air;
                        }
                        else
                        {
                            gameModel.Player.Move(64, 0);
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY] = EssenceName.Air;
                            gameModel.Room.room[gameModel.Player.PosX + 64, gameModel.Player.PosY] = EssenceName.Enemy;
                        }
                    }

                    break;
                }
                case Keys.A:
                {
                    var nextPos = gameModel.PlayerNextPosition(gameModel.Player, new Point(-64, 0));

                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Air 
                        || gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Trap)
                        gameModel.Player.Move(-64, 0);

                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Barrier)
                    {
                        if (gameModel.Room.room[nextPos.X - 64, nextPos.Y] == EssenceName.Barrier || gameModel.Room.room[nextPos.X - 64, nextPos.Y] == EssenceName.Empty)
                            gameModel.Player.Move(0, 0);
                        else
                        {
                            gameModel.Player.Move(-64, 0);
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY] = EssenceName.Air;
                            gameModel.Room.room[gameModel.Player.PosX - 64, gameModel.Player.PosY] = EssenceName.Barrier;
                        }
                    }

                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Enemy)
                    {
                        if (gameModel.Room.room[nextPos.X - 64, nextPos.Y] == EssenceName.Barrier || gameModel.Room.room[nextPos.X - 64, nextPos.Y] == EssenceName.Empty)
                        {
                            gameModel.Player.Move(0, 0);
                            gameModel.Room.room[nextPos.X, nextPos.Y] = EssenceName.Air;
                        }
                        else
                        {
                            gameModel.Player.Move(-64, 0);
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY] = EssenceName.Air;
                            gameModel.Room.room[gameModel.Player.PosX - 64, gameModel.Player.PosY] = EssenceName.Enemy;
                        }
                    }
                    break;
                }
                case Keys.W:
                {
                    var nextPos = gameModel.PlayerNextPosition(gameModel.Player, new Point(0, -64));
                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Air
                        || gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Trap)
                        gameModel.Player.Move(0, -64);
                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Barrier)
                    {
                        if (gameModel.Room.room[nextPos.X, nextPos.Y - 64] == EssenceName.Barrier || gameModel.Room.room[nextPos.X , nextPos.Y -64] == EssenceName.Empty)
                            gameModel.Player.Move(0, 0);
                        else
                        {
                            gameModel.Player.Move(0, -64);
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY] = EssenceName.Air;
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY - 64] = EssenceName.Barrier;
                        }
                    }

                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Enemy)
                    {
                        if (gameModel.Room.room[nextPos.X, nextPos.Y - 64] == EssenceName.Barrier || gameModel.Room.room[nextPos.X, nextPos.Y - 64] == EssenceName.Empty)
                        {
                            gameModel.Player.Move(0, 0);
                            gameModel.Room.room[nextPos.X, nextPos.Y] = EssenceName.Air;
                        }
                        else
                        {
                            gameModel.Player.Move(0, -64);
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY] = EssenceName.Air;
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY - 64] = EssenceName.Enemy;
                        }
                    }
                    break;
                }

                case Keys.S:
                {
                    var nextPos = gameModel.PlayerNextPosition(gameModel.Player, new Point(0, 64));
                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Air
                        || gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Trap)
                        gameModel.Player.Move(0, 64);
                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Barrier)
                    {
                        if (gameModel.Room.room[nextPos.X, nextPos.Y + 64] == EssenceName.Barrier || gameModel.Room.room[nextPos.X, nextPos.Y + 64] == EssenceName.Empty)
                            gameModel.Player.Move(0, 0);
                        else
                        {
                            gameModel.Player.Move(0, 64);
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY] = EssenceName.Air;
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY + 64] = EssenceName.Barrier;
                        }
                    }

                    if (gameModel.Room.room[nextPos.X, nextPos.Y] == EssenceName.Enemy)
                    {
                        if (gameModel.Room.room[nextPos.X, nextPos.Y + 64] == EssenceName.Barrier || gameModel.Room.room[nextPos.X, nextPos.Y + 64] == EssenceName.Empty)
                        {
                            gameModel.Player.Move(0, 0);
                            gameModel.Room.room[nextPos.X, nextPos.Y] = EssenceName.Air;
                        }
                        else
                        {
                            gameModel.Player.Move(0, 32);
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY] = EssenceName.Air;
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY + 64] = EssenceName.Enemy;
                        }
                    }
                    break;
                }
            }
            Invalidate();
        }
    }
}

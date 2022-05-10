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
        private EssenceView<Player> playerView;
        private GameModel gameModel;

         public Form1()
        {
            InitializeComponent();
            Init();
            Invalidate();
        }

        public void Init()
        {
            Size = new Size(1000, 500);
            gameModel = new GameModel(new Point(0,0), new []{new Point(32,32), new Point(96,0)});
            playerView = new EssenceView<Player>(gameModel.Player, sprites.playerSpriteS);
            barrierView = new EssencesView<Barrier>(gameModel.Barriers, sprites.barrierSpriteS);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            playerView.View(e.Graphics);
            barrierView.View(e.Graphics);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                {
                    gameModel.Player.Move(32, 0);

                        //if (gameModel.Barriers.Any(x => x.PosX == gameModel.Player.PosX && x.PosY == gameModel.Player.PosY))
                        //gameModel.Barriers
                        //    .Where(x => x.PosX == gameModel.Player.PosX && x.PosY == gameModel.Player.PosY)
                        //    .Select(x => x).First().MoveByPush(32, 0);


                        if (gameModel.Barriers.Any(x =>
                                x.PosX == gameModel.Player.PosX && x.PosY == gameModel.Player.PosY))
                        {
                            var nextPosition = gameModel.NextPosition<Player>(gameModel.Player, new Point(32, 0));

                            if (!gameModel.Barriers.Any(x => x.PosX == nextPosition.X && x.PosY == nextPosition.Y))
                                gameModel.Barriers
                                    .Where(x => x.PosX == gameModel.Player.PosX && x.PosY == gameModel.Player.PosY)
                                    .Select(x => x).First().MoveByPush(32, 0);
                        }
                        break;
                }
                case Keys.A: 
                {
                    gameModel.Player.Move(-32, 0);
                    if (gameModel.Barriers.Any(x =>
                            x.PosX == gameModel.Player.PosX && x.PosY == gameModel.Player.PosY))
                    {
                        var nextPosition = gameModel.NextPosition<Player>(gameModel.Player, new Point(-32, 0));

                        if (!gameModel.Barriers.Any(x => x.PosX == nextPosition.X && x.PosY == nextPosition.Y))
                            gameModel.Barriers
                                .Where(x => x.PosX == gameModel.Player.PosX && x.PosY == gameModel.Player.PosY)
                                .Select(x => x).First().MoveByPush(-32, 0);
                    }
                    break;
                    }
                case Keys.W:
                {
                    gameModel.Player.Move(0, -32);
                    if (gameModel.Barriers.Any(x =>
                            x.PosX == gameModel.Player.PosX && x.PosY == gameModel.Player.PosY))
                    {
                        var nextPosition = gameModel.NextPosition<Player>(gameModel.Player, new Point(0, -32));

                        if (!gameModel.Barriers.Any(x => x.PosX == nextPosition.X && x.PosY == nextPosition.Y))
                            gameModel.Barriers
                                .Where(x => x.PosX == gameModel.Player.PosX && x.PosY == gameModel.Player.PosY)
                                .Select(x => x).First().MoveByPush(0, -32);
                    }
                    break;
                    }
                case Keys.S:
                {
                    gameModel.Player.Move(0, 32);
                    if (gameModel.Barriers.Any(x =>
                            x.PosX == gameModel.Player.PosX && x.PosY == gameModel.Player.PosY))
                    {
                        var nextPosition = gameModel.NextPosition<Player>(gameModel.Player, new Point(0, 32));

                        if (!gameModel.Barriers.Any(x => x.PosX == nextPosition.X && x.PosY == nextPosition.Y))
                            gameModel.Barriers
                                .Where(x => x.PosX == gameModel.Player.PosX && x.PosY == gameModel.Player.PosY)
                                .Select(x => x).First().MoveByPush(0, 32);
                    }
                    break;
                    }
            }
            Invalidate();
        }
    }
}

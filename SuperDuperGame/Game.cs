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
    partial class Game : Form
    {
        private int TimerTick = 0;
        private int MoveTimerTick = 0;
        private readonly Sprites sprites = new Sprites();
        private readonly List<EssenceView<Barrier>> barrierView = new List<EssenceView<Barrier>>();
        private readonly List<EssenceView<Trap>> trapView = new List<EssenceView<Trap>>();
        private readonly List <EssenceView<Enemy>> enemyView = new List<EssenceView<Enemy>>();
        private EssenceView<Player> playerView;
        private RoomView roomView;
        private GameModel gameModel;
        private readonly Lvls lvl = new Lvls();

        private Point posPlayer { get; }
        private Point roomSize { get; }
        private int[,] map { get; }
        private int stepCount { get; }
        private TrapBehaviour trapBehaviour { get; }
        private string mapName { get; }

        public Game(Point posPlayer, Point roomSize, int[,] map, int stepCount, TrapBehaviour trapBehaviour, string mapName)
        {
            this.posPlayer = posPlayer;
            this.roomSize = roomSize;
            this.map = map;
            this.stepCount = stepCount;
            this.trapBehaviour = trapBehaviour;
            this.mapName = mapName;

            InitializeComponent();
            Init();
            Timer();
        }

         private void Timer()
         {
             timer1.Interval = 5;
             timer1.Tick += new EventHandler(Update);
         }

         private void Update(object sender, EventArgs e)
         {
             if (gameModel.StepCount.stepCount <= 0)
                 GameOver();
            if (TimerTick > 100)
            {
                GoNextLvl();
            }
            Invalidate();
         }

        public void Init()
        {
            gameModel = new GameModel(posPlayer, roomSize, map, stepCount, trapBehaviour);
            playerView = new EssenceView<Player>(gameModel.Player, sprites.player1);
            foreach (var barrier in gameModel.Barriers)
                barrierView.Add(new EssenceView<Barrier>(barrier, sprites.barrierSpriteS));
            foreach (var enemy in gameModel.Enemys)
                enemyView.Add(new EssenceView<Enemy>(enemy, sprites.enemy1));
            foreach (var trap in gameModel.Traps)
                trapView.Add(new EssenceView<Trap>(trap, sprites.trapSpriteS2));

            roomView = new RoomView(gameModel.Room, mapName);
            timer1.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            roomView.View(e.Graphics, barrierView, trapView, gameModel.TrapsBehaviour ,enemyView);
            if (gameModel.Player.HaveSoul())
            {
                PlayEndnimation();
            }
            else
            {
                PlayStandartAnimation(e.Graphics);
            }
            playerView.View(e.Graphics);
            label1.Text = "Count: " + gameModel.StepCount.stepCount.ToString();
        }

        public void PlayEndnimation()
        {
            if (TimerTick == 1)
            {
                playerView.sprite = sprites.MakeSprite(sprites.enemy1);
            }

            if (TimerTick == 11)
            {
                playerView.sprite = sprites.MakeSprite(sprites.enemy2);
            }
            if (TimerTick == 21)
            {
                playerView.sprite = sprites.MakeSprite(sprites.enemy3);
            }
            if (TimerTick == 31)
            {
                playerView.sprite = sprites.MakeSprite(sprites.enemy4);
            }
            if (TimerTick == 41)
            {
                playerView.sprite = sprites.MakeSprite(sprites.enemy1);
            }
        }

        public void PlayStandartAnimation(Graphics e)
        {
            if (TimerTick == 1)
            {
                foreach (var enemy in enemyView)
                {
                   enemy.sprite = sprites.MakeSprite(sprites.enemy1);
                }
                playerView.sprite = sprites.MakeSprite(sprites.player1);
            }

            if (TimerTick == 11)
            {
                foreach (var enemy in enemyView)
                {
                    enemy.sprite = sprites.MakeSprite(sprites.enemy2);
                }
                playerView.sprite = sprites.MakeSprite(sprites.player2);
            }
            if (TimerTick == 21)
            {
                foreach (var enemy in enemyView)
                {
                    enemy.sprite = sprites.MakeSprite(sprites.enemy3);
                }
                playerView.sprite = sprites.MakeSprite(sprites.player3);
            }
            if (TimerTick == 31)
            {
                foreach (var enemy in enemyView)
                {
                    enemy.sprite = sprites.MakeSprite(sprites.enemy2);
                }
                playerView.sprite = sprites.MakeSprite(sprites.player2);
            }
            if (TimerTick == 41)
            {
                foreach (var enemy in enemyView)
                {
                    enemy.sprite = sprites.MakeSprite(sprites.enemy1);
                }
                playerView.sprite = sprites.MakeSprite(sprites.player1);
                TimerTick = 1;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.R:
                {
                    timer1.Stop();
                    this.Close();
                    var lvl1 = new Game(posPlayer, roomSize, map, stepCount, trapBehaviour, mapName);
                    lvl1.Show();
                }
                    break;

                case Keys.Escape:
                {
                        timer1.Stop();
                        var pauseMenu = new PauseMenu();
                        pauseMenu.Show();
                }
                    break;
            }
            if (MoveTimerTick > 6)
            {
                var currentPos = new Point(gameModel.Player.PosX, gameModel.Player.PosY);
                switch (e.KeyCode)
                {
                    case Keys.D:
                    {
                        var nextPos = gameModel.PlayerNextPosition(gameModel.Player, new Point(64, 0));
                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Soul)
                        {
                            gameModel.Player.Move(64, 0);
                            gameModel.Player.AvailabilityOfSoulSetTrue();
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Floor
                            || gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Trap)
                        {
                            if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Trap &&
                                (gameModel.TrapsBehaviour == TrapBehaviour.Close ||
                                 gameModel.TrapsBehaviour == TrapBehaviour.OpenAllTime))
                            {
                                gameModel.StepCount.StepCountDown();
                            }

                            gameModel.Player.Move(64, 0);

                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Barrier)
                        {
                            if (gameModel.Room.room[nextPos.X + 64, nextPos.Y].EssenceName == EssenceName.Barrier ||
                                gameModel.Room.room[nextPos.X + 64, nextPos.Y].EssenceName == EssenceName.Wall)
                                gameModel.Player.Move(0, 0);
                            else
                            {
                                gameModel.Player.Move(0, 0);

                                if (gameModel.Room.room[nextPos.X + 64, nextPos.Y].EssenceName == EssenceName.Trap)
                                {
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y)
                                        .BarrierWithTrap = true;
                                }
                                else
                                {
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y)
                                        .BarrierWithTrap = false;
                                }

                                gameModel.Room.Move(
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y), 64,
                                    0);
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                            }
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Enemy)
                        {
                            gameModel.Player.Move(0, 0);
                            if (gameModel.Room.room[nextPos.X + 64, nextPos.Y].EssenceName == EssenceName.Barrier ||
                                gameModel.Room.room[nextPos.X + 64, nextPos.Y].EssenceName == EssenceName.Wall)
                            {
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                                else
                                {
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = new Floor();
                                }
                            }
                            else
                            {
                                if (gameModel.Room.room[nextPos.X + 64, nextPos.Y].EssenceName == EssenceName.Trap)
                                {
                                    gameModel.Enemys
                                        .Select(x => x)
                                        .First(x => x.PosX == nextPos.X && x.PosY == nextPos.Y)
                                        .EnemyWithTrap = true;
                                }
                                else
                                {
                                    gameModel.Enemys
                                        .Select(x => x)
                                        .First(x => x.PosX == nextPos.X && x.PosY == nextPos.Y)
                                        .EnemyWithTrap = false;
                                }

                                gameModel.Room.Move(
                                    gameModel.Enemys
                                        .Select(enemy => enemy)
                                        .First(enemy => enemy.PosX == nextPos.X && enemy.PosY == nextPos.Y), 64, 0);
                                enemyView.Where(x => x.essence.PosX == nextPos.X + 64 && x.essence.PosY == nextPos.Y)
                                    .Select(x => x).First().sprite = sprites.MakeSprite(sprites.enemy4);
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                            }

                        }

                        playerView.DirectionRight = true;
                        if (gameModel.TrapsBehaviour != TrapBehaviour.OpenAllTime)
                            gameModel.TrapsBehaviour = gameModel.TrapsBehaviour == TrapBehaviour.Open
                                ? TrapBehaviour.Close
                                : TrapBehaviour.Open;
                        if (gameModel.Player.PosX == currentPos.X && gameModel.Player.PosY == currentPos.Y &&
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY].EssenceName ==
                            EssenceName.Trap && (gameModel.TrapsBehaviour == TrapBehaviour.Open ||
                                                 gameModel.TrapsBehaviour == TrapBehaviour.OpenAllTime))
                            gameModel.StepCount.StepCountDown();
                        playerView.sprite = sprites.MakeSprite(sprites.player4);
                        gameModel.StepCount.StepCountDown();
                        break;
                    }
                    case Keys.A:
                    {
                        var nextPos = gameModel.PlayerNextPosition(gameModel.Player, new Point(-64, 0));
                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Soul)
                        {
                            gameModel.Player.Move(-64, 0);
                            gameModel.Player.AvailabilityOfSoulSetTrue();
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Floor
                            || gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Trap)
                        {
                            if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Trap &&
                                (gameModel.TrapsBehaviour == TrapBehaviour.Close ||
                                 gameModel.TrapsBehaviour == TrapBehaviour.OpenAllTime))
                            {
                                gameModel.StepCount.StepCountDown();
                            }

                            gameModel.Player.Move(-64, 0);
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Barrier)
                        {
                            if (gameModel.Room.room[nextPos.X - 64, nextPos.Y].EssenceName == EssenceName.Barrier ||
                                gameModel.Room.room[nextPos.X - 64, nextPos.Y].EssenceName == EssenceName.Wall)
                                gameModel.Player.Move(0, 0);
                            else
                            {
                                gameModel.Player.Move(0, 0);

                                if (gameModel.Room.room[nextPos.X - 64, nextPos.Y].EssenceName == EssenceName.Trap)
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y)
                                        .BarrierWithTrap = true;
                                else
                                {
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y)
                                        .BarrierWithTrap = false;
                                }

                                gameModel.Room.Move(
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y), -64,
                                    0);
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                            }
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Enemy)
                        {
                            gameModel.Player.Move(0, 0);
                            if (gameModel.Room.room[nextPos.X - 64, nextPos.Y].EssenceName == EssenceName.Barrier ||
                                gameModel.Room.room[nextPos.X - 64, nextPos.Y].EssenceName == EssenceName.Wall)
                            {
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                                else
                                {
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = new Floor();
                                }
                            }
                            else
                            {
                                if (gameModel.Room.room[nextPos.X - 64, nextPos.Y].EssenceName == EssenceName.Trap)
                                    gameModel.Enemys
                                        .Select(x => x)
                                        .First(x => x.PosX == nextPos.X && x.PosY == nextPos.Y)
                                        .EnemyWithTrap = true;
                                else
                                {
                                    gameModel.Enemys
                                        .Select(x => x)
                                        .First(x => x.PosX == nextPos.X && x.PosY == nextPos.Y)
                                        .EnemyWithTrap = false;
                                }

                                gameModel.Room.Move(
                                    gameModel.Enemys
                                        .Select(enemy => enemy)
                                        .First(enemy => enemy.PosX == nextPos.X && enemy.PosY == nextPos.Y), -64, 0);
                                enemyView.Where(x => x.essence.PosX == nextPos.X - 64 && x.essence.PosY == nextPos.Y)
                                    .Select(x => x).First().sprite = sprites.MakeSprite(sprites.enemy4);
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                            }
                        }

                        playerView.DirectionRight = false;
                        if (gameModel.TrapsBehaviour != TrapBehaviour.OpenAllTime)
                            gameModel.TrapsBehaviour = gameModel.TrapsBehaviour == TrapBehaviour.Open
                                ? TrapBehaviour.Close
                                : TrapBehaviour.Open;
                        if (gameModel.Player.PosX == currentPos.X && gameModel.Player.PosY == currentPos.Y &&
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY].EssenceName ==
                            EssenceName.Trap && (gameModel.TrapsBehaviour == TrapBehaviour.Open ||
                                                 gameModel.TrapsBehaviour == TrapBehaviour.OpenAllTime))
                            gameModel.StepCount.StepCountDown();
                        playerView.sprite = sprites.MakeSprite(sprites.player4);
                        gameModel.StepCount.StepCountDown();
                        break;
                    }
                    case Keys.W:
                    {
                        var nextPos = gameModel.PlayerNextPosition(gameModel.Player, new Point(0, -64));
                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Soul)
                        {
                            gameModel.Player.Move(0, -64);
                            gameModel.Player.AvailabilityOfSoulSetTrue();
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Floor
                            || gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Trap)
                        {
                            if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Trap &&
                                (gameModel.TrapsBehaviour == TrapBehaviour.Close ||
                                 gameModel.TrapsBehaviour == TrapBehaviour.OpenAllTime))
                            {
                                gameModel.StepCount.StepCountDown();
                            }

                            gameModel.Player.Move(0, -64);
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Barrier)
                        {
                            if (gameModel.Room.room[nextPos.X, nextPos.Y - 64].EssenceName == EssenceName.Barrier ||
                                gameModel.Room.room[nextPos.X, nextPos.Y - 64].EssenceName == EssenceName.Wall)
                                gameModel.Player.Move(0, 0);
                            else
                            {
                                gameModel.Player.Move(0, 0);

                                if (gameModel.Room.room[nextPos.X, nextPos.Y - 64].EssenceName == EssenceName.Trap)
                                {
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y)
                                        .BarrierWithTrap = true;
                                }
                                else
                                {
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y)
                                        .BarrierWithTrap = false;
                                }

                                gameModel.Room.Move(
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y), 0,
                                    -64);
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                            }
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Enemy)
                        {
                            gameModel.Player.Move(0, 0);
                            if (gameModel.Room.room[nextPos.X, nextPos.Y - 64].EssenceName == EssenceName.Barrier ||
                                gameModel.Room.room[nextPos.X, nextPos.Y - 64].EssenceName == EssenceName.Wall)
                            {
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                                else
                                {
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = new Floor();
                                }
                            }
                            else
                            {
                                if (gameModel.Room.room[nextPos.X, nextPos.Y - 64].EssenceName == EssenceName.Trap)
                                    gameModel.Enemys
                                        .Select(x => x)
                                        .First(x => x.PosX == nextPos.X && x.PosY == nextPos.Y)
                                        .EnemyWithTrap = true;
                                else
                                {

                                    gameModel.Barriers
                                        .Select(x => x)
                                        .First(x => x.PosX == nextPos.X && x.PosY == nextPos.Y)
                                        .BarrierWithTrap = false;
                                }

                                gameModel.Room.Move(
                                    gameModel.Enemys
                                        .Select(enemy => enemy)
                                        .First(enemy => enemy.PosX == nextPos.X && enemy.PosY == nextPos.Y), 0, -64);
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                            }
                        }

                        if (gameModel.TrapsBehaviour != TrapBehaviour.OpenAllTime)
                            gameModel.TrapsBehaviour = gameModel.TrapsBehaviour == TrapBehaviour.Open
                                ? TrapBehaviour.Close
                                : TrapBehaviour.Open;
                        if (gameModel.Player.PosX == currentPos.X && gameModel.Player.PosY == currentPos.Y &&
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY].EssenceName ==
                            EssenceName.Trap && (gameModel.TrapsBehaviour == TrapBehaviour.Open ||
                                                 gameModel.TrapsBehaviour == TrapBehaviour.OpenAllTime))
                            gameModel.StepCount.StepCountDown();
                        playerView.sprite = sprites.MakeSprite(sprites.player4);
                        gameModel.StepCount.StepCountDown();
                        break;
                    }

                    case Keys.S:
                    {
                        var nextPos = gameModel.PlayerNextPosition(gameModel.Player, new Point(0, 64));
                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Soul)
                        {
                            gameModel.Player.Move(0, 64);
                            gameModel.Player.AvailabilityOfSoulSetTrue();
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Floor
                            || gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Trap)
                        {
                            if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Trap &&
                                (gameModel.TrapsBehaviour == TrapBehaviour.Close ||
                                 gameModel.TrapsBehaviour == TrapBehaviour.OpenAllTime))
                            {
                                gameModel.StepCount.StepCountDown();
                            }

                            gameModel.Player.Move(0, 64);
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Barrier)
                        {
                            if (gameModel.Room.room[nextPos.X, nextPos.Y + 64].EssenceName == EssenceName.Barrier ||
                                gameModel.Room.room[nextPos.X, nextPos.Y + 64].EssenceName == EssenceName.Wall)
                                gameModel.Player.Move(0, 0);
                            else
                            {
                                gameModel.Player.Move(0, 0);

                                if (gameModel.Room.room[nextPos.X, nextPos.Y + 64].EssenceName == EssenceName.Trap)
                                {
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y)
                                        .BarrierWithTrap = true;
                                }
                                else
                                {
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y)
                                        .BarrierWithTrap = false;
                                }

                                gameModel.Room.Move(
                                    gameModel.Barriers
                                        .Select(barrier => barrier)
                                        .First(barrier => barrier.PosX == nextPos.X && barrier.PosY == nextPos.Y), 0,
                                    64);
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                            }
                        }

                        if (gameModel.Room.room[nextPos.X, nextPos.Y].EssenceName == EssenceName.Enemy)
                        {
                            gameModel.Player.Move(0, 0);
                            if (gameModel.Room.room[nextPos.X, nextPos.Y + 64].EssenceName == EssenceName.Barrier ||
                                gameModel.Room.room[nextPos.X, nextPos.Y + 64].EssenceName == EssenceName.Wall)
                            {
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                                else
                                {
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = new Floor();
                                }
                            }
                            else
                            {
                                if (gameModel.Room.room[nextPos.X, nextPos.Y + 64].EssenceName == EssenceName.Trap)
                                {
                                    gameModel.Enemys
                                        .Select(x => x)
                                        .First(x => x.PosX == nextPos.X && x.PosY == nextPos.Y)
                                        .EnemyWithTrap = true;
                                }
                                else
                                {
                                    gameModel.Enemys
                                        .Select(x => x)
                                        .First(x => x.PosX == nextPos.X && x.PosY == nextPos.Y)
                                        .EnemyWithTrap = false;
                                }

                                gameModel.Room.Move(
                                    gameModel.Enemys
                                        .Select(enemy => enemy)
                                        .First(enemy => enemy.PosX == nextPos.X && enemy.PosY == nextPos.Y), 0, 64);
                                if (gameModel.Traps.Exists(x => x.PosX == nextPos.X && x.PosY == nextPos.Y))
                                    gameModel.Room.room[nextPos.X, nextPos.Y] = gameModel.Traps
                                        .Select(x => x).First(x =>
                                            x.PosX == nextPos.X && x.PosY == nextPos.Y);
                            }
                        }

                        if (gameModel.TrapsBehaviour != TrapBehaviour.OpenAllTime)
                            gameModel.TrapsBehaviour = gameModel.TrapsBehaviour == TrapBehaviour.Open
                                ? TrapBehaviour.Close
                                : TrapBehaviour.Open;
                        if (gameModel.Player.PosX == currentPos.X && gameModel.Player.PosY == currentPos.Y &&
                            gameModel.Room.room[gameModel.Player.PosX, gameModel.Player.PosY].EssenceName ==
                            EssenceName.Trap && (gameModel.TrapsBehaviour == TrapBehaviour.Open ||
                                                 gameModel.TrapsBehaviour == TrapBehaviour.OpenAllTime))
                            gameModel.StepCount.StepCountDown();
                        playerView.sprite = sprites.MakeSprite(sprites.player4);
                        gameModel.StepCount.StepCountDown();
                        break;
                    }
                }
                MoveTimerTick = 0;
            }
        }

        protected void GameOver()
        {
            timer1.Stop();
            var lvl1 = new Game(posPlayer, roomSize, map, stepCount, trapBehaviour, mapName);
            lvl1.Show();
            this.Close();
        }

        protected void GoNextLvl()
        {
            timer1.Stop();
            if (mapName == sprites.lvl1)
            {
                var lvl2 = new Game(new Point(448, 384), new Point(20, 10), lvl.lvl2, 34, TrapBehaviour.OpenAllTime, sprites.lvl2);
                lvl2.Show();
            }
            if (mapName == sprites.lvl2)
            {
                var lvlMenu = Application.OpenForms[1];
                lvlMenu.Show();
            }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerTick++;
            MoveTimerTick++;
        }
    }
}

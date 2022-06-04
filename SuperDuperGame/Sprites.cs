using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace SuperDuperGame
{
    public class Sprites
    {
        public readonly string player1 = "Resources\\Player\\Player1.png";
        public readonly string player2 = "Resources\\Player\\Player2.png";
        public readonly string player3 = "Resources\\Player\\Player3.png";
        public readonly string player4 = "Resources\\Player\\Player4.png";
        public readonly string barrierSpriteS = "Resources\\TestRock.png";
        public readonly string enemy1 = "Resources\\Enemy\\Enemy1.png";
        public readonly string enemy2 = "Resources\\Enemy\\Enemy2.png";
        public readonly string enemy3 = "Resources\\Enemy\\Enemy3.png";
        public readonly string enemy4 = "Resources\\Enemy\\Enemy4.png";
        public readonly string trapSpriteS = "Resources\\TestTrap.png";
        public readonly string trapSpriteS2 = "Resources\\TestTrap2.png";
        public readonly string soul = "Resources\\Soul\\Soul.png";
        public readonly string lvl1 = "Resources\\Background\\Lvl1.png";
        public readonly string lvl2 = "Resources\\Background\\Lvl2.png";

        public Image MakeSprite(string sprite)
        {
            return new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                sprite));
        }
    }
}

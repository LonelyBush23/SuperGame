using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperGame.Model
{
    public enum EssenceName
    {
        Player,
        Barrier,
        Enemy,
        Trap,
        Air,
        Empty
    }

    public class Essence
    {
        public int PosX { get; private protected set; }
        public int PosY { get; private protected set; }
        public EssenceName EssenceName { get; private protected set; }
        public int SpriteWidth { get; }
        public int SpriteHeight { get; }
    }
}

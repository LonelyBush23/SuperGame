using System.Net.Mime;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SuperDuperGame.Model;

namespace SuperDuperGame
{
    public class EssenceView<T> where T : Essence
    {
        public readonly T essence;
        public Image sprite;
        public bool DirectionRight = true;
        public bool move = false;

        public EssenceView(T essence, string sprite)
        {
            this.essence = essence;
            this.sprite = new Bitmap( Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                sprite));
        }

        public void View(Graphics e)
        { 
            if (DirectionRight)
                e.DrawImage(sprite, essence.PosX, essence.PosY);
            else
            {
                sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
                e.DrawImage(sprite, essence.PosX, essence.PosY);
                sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
        }
    }
}
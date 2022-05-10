using System.Collections.Generic;
using System.Net.Mime;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SuperDuperGame.Model;

namespace SuperDuperGame
{
    public class EssencesView<T> where T : Essence
    {
        private readonly List<T> essence;
        public Image sprite;

        public EssencesView(List<T> essence, string sprite)
        {
            this.essence = essence;
            this.sprite = new Bitmap(Path.Combine(
                    new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                    sprite));
        }

        public void View(Graphics e)
        {
            foreach (var val in essence)
            {
                e.DrawImage(sprite, val.PosX, val.PosY);
            }
        }
    }
}
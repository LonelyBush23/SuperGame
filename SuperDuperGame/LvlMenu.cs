using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperDuperGame.Model;

namespace SuperDuperGame
{
    public partial class LvlMenu : Form
    {
        private readonly Lvls lvl = new Lvls();
        private readonly Sprites sprites = new Sprites();
        public LvlMenu()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu.song.controls.stop();
            this.Hide();
            var lvl2 = new Game(new Point(448, 384), new Point(20, 10), lvl.lvl2, 34, TrapBehaviour.OpenAllTime, sprites.lvl2);
            lvl2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu.song.controls.stop();
            this.Hide();
            var lvl1 = new Game(new Point(704, 128), new Point(20, 10), lvl.lvl1, 35, TrapBehaviour.OpenAllTime, sprites.lvl1);
            lvl1.Show();
        }

        private void вМеню_Click(object sender, EventArgs e)
        {
            FadeOut(0);
            Close();
            var mainMenu = Application.OpenForms[0];
            mainMenu.Opacity = 0;
            mainMenu.Show();
            FadeIn(mainMenu, 0);
        }

        private void FadeIn(Form o, int speed)
        {
            for (int i = 0; i <= 100; i++)
            {
                o.Opacity = i / 100.0;
                System.Threading.Thread.Sleep(speed);//чем меньше число, тем быстрее появится
            }
        }

        private void FadeOut(int speed)
        {
            for (int i = 100; i >= 0; i--)
            {
                Opacity = i / 100.0;
                System.Threading.Thread.Sleep(speed); //чем меньше число, тем быстрее исчезнет
            }
        }
    }
}

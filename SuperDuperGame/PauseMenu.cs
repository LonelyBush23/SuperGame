using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperDuperGame
{
    public partial class PauseMenu : Form
    {
        public PauseMenu()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void Выход_Click(object sender, EventArgs e)
        {
            Game.gameSong.controls.stop();
            Application.Exit();
        }

        private void Продолжить_Click(object sender, EventArgs e)
        {
            Hide();
            Game.gameSong.controls.play();
        }

        private void кВыборуУровня_Click(object sender, EventArgs e)
        {
            Game.gameSong.controls.stop();
            MainMenu.song.controls.play();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "Game")
                {
                    Application.OpenForms[i].Close();
                }
            }
            var lvlMenu = Application.OpenForms[1];
            lvlMenu.Show();
            Hide();
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

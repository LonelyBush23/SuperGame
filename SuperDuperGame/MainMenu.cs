using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SuperDuperGame.Model;
using System.Drawing;
using System.IO;
using System.Media;
using WMPLib;

namespace SuperDuperGame
{
    public partial class MainMenu : Form
    {
        public static WindowsMediaPlayer song = new WindowsMediaPlayer();
        public MainMenu()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            CreateMusic();
        }

        private void CreateMusic()
        {
            song.URL = Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                "Resources\\Music\\Song1.wav");
            song.controls.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var lvlMenu = new LvlMenu();
            lvlMenu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Управление_Click(object sender, EventArgs e)
        {

        }
        
        //private void button1_MouseEnter(object sender, EventArgs e)
        //{
        //    Играть.BackgroundImage = global::SuperDuperGame.Properties.Resources.выход;
        //}

        //private void vkBtn_MouseLeave(object sender, EventArgs e)
        //{
        //    Играть.BackgroundImage = global::SuperDuperGame.Properties.Resources.Играть;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurGame
{
    public partial class Form1 : Form
    {
        PictureBox[] cloud;
        int cloudspeed;
        int PlayerSpeed = 5;
        Random rnd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            cloudspeed = 5;
            cloud = new PictureBox[20];
            rnd = new Random();
            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i] = new PictureBox();
                cloud[i].BorderStyle = BorderStyle.None;
                cloud[i].Location = new Point(rnd.Next(-1000, 1280), rnd.Next(140, 320));
                if (i % 2 == 1)
                {
                    cloud[i].Size = new Size(rnd.Next(100, 125), rnd.Next(30, 70));
                    cloud[i].BackColor = Color.FromArgb(rnd.Next(125, 125), 225, 200, 200);
                }
                else
                {
                    cloud[i].Size = new Size(150, 25);
                    cloud[i].BackColor = Color.FromArgb(rnd.Next(90, 125), 225, 205, 205);
                }
                this.Controls.Add(cloud[i]);
            }
        }

        private void time_cloud_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i].Left += cloudspeed - 4;
                if (cloud[i].Left >= 1280)
                {
                    cloud[i].Left = cloud[i].Height;
                }
            }
            for (int i = cloud.Length; i < cloud.Length; i++)
            {
                cloud[i].Left += cloudspeed - 10;
                if (cloud[i].Left >= 1280)
                {
                    cloud[i].Left = cloud[i].Left;
                }
            }
        }
            private void LeftMove_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Left>10)
            {
                mainPlayer.Left -= PlayerSpeed;
            }
        }

        private void RightMove_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Left<850)
            {
                mainPlayer.Left += PlayerSpeed;
            }
        }
        private void UpMove_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Top>320)
            {
                mainPlayer.Top -= PlayerSpeed;
            }
            
        }

        private void DownMove_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Top<450)
            {
                mainPlayer.Top += PlayerSpeed;
            } 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            mainPlayer.Image = Properties.Resources.cowboy_run;
            if(e.KeyCode == Keys.Up)
            {
                UpMove.Start();
            }
            if (e.KeyCode == Keys.Down)
            {
                DownMove.Start();
            }
            if (e.KeyCode==Keys.Left)
            {
                
                LeftMove.Start();
            }
            if (e.KeyCode == Keys.Right)
            {
                
                RightMove.Start();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            mainPlayer.Image = Properties.Resources.cowboy;

            LeftMove.Stop();
            RightMove.Stop();
            UpMove.Stop();
            DownMove.Stop();

        }

        
    }
    }


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.IO;

namespace OurGame
{
    public partial class Form1 : Form
    {
        PictureBox[] cloud;
        Random rnd;
        PictureBox[] bullets;
        PictureBox[] Enemy;

        string WrightList = @"myList.txt";
        int cloudspeed;
        int PlayerSpeed;
        int BulletsSpeed;
        int SizeEnemy;
        int EnemySpeed;
        int Score;
        //int Level;

        WindowsMediaPlayer Shoot;
        WindowsMediaPlayer GameSong;
        WindowsMediaPlayer Rip;

        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            

            cloudspeed = 5;
            PlayerSpeed = 5;
            BulletsSpeed = 80;

            Score = 0;
            //Level = 1;

            bullets = new PictureBox[1];
            cloud = new PictureBox[20];
            rnd = new Random();
            Enemy = new PictureBox[3];

            SizeEnemy = rnd.Next(60, 90);
            EnemySpeed = 3;


            Image eassyEnemy = Image.FromFile("Skin\\Enemy.gif");

            for (int i = 0; i < Enemy.Length; i++)
            {
                Enemy[i] = new PictureBox();
                Enemy[i].Size = new Size(SizeEnemy, SizeEnemy);
                Enemy[i].SizeMode = PictureBoxSizeMode.Zoom;
                Enemy[i].BackColor = Color.Transparent;
                Enemy[i].Image = eassyEnemy;
                Enemy[i].Location = new Point((i + 1) * rnd.Next(90, 160) + 1080, rnd.Next(320, 480));
                this.Controls.Add(Enemy[i]);
            }

            Shoot = new WindowsMediaPlayer();
            Shoot.URL = "song\\shoot.KvyDz.mp3";
            Shoot.settings.volume = 0;

            Rip = new WindowsMediaPlayer();
            Rip.URL = "song\\rip.mp3";
            Rip.settings.volume = 0;

            GameSong = new WindowsMediaPlayer();
            GameSong.URL = "song\\GameSong.mp3";
            GameSong.settings.setMode("loop", true);
            GameSong.settings.volume = 15;
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox();
                bullets[i].BorderStyle = BorderStyle.None;
                bullets[i].Size = new Size(20, 5);
                bullets[i].BackColor = Color.Red;
                this.Controls.Add(bullets[i]);
            }
            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i] = new PictureBox();
                cloud[i].BorderStyle = BorderStyle.None;
                cloud[i].Location = new Point(rnd.Next(-1000, 1280), rnd.Next(40, 220));
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
            GameSong.controls.play();
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
            
        }
        private void LeftMove_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= PlayerSpeed;
            }
        }

        private void RightMove_Tick(object sender, EventArgs e)
        {
            if (Player.Left < 850)
            {
                Player.Left += PlayerSpeed;
            }
        }
        private void UpMove_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 320)
            {
                Player.Top -= PlayerSpeed;
            }

        }

        private void DownMove_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 450)
            {
                Player.Top += PlayerSpeed;
            }
        }

        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                time_cloud.Stop();
            }
            Player.Image = Properties.Resources.run;
            if (e.KeyCode == Keys.Up)
            {
                UpMove.Start();
            }
            if (e.KeyCode == Keys.Down)
            {
                DownMove.Start();
            }
            if (e.KeyCode == Keys.Left)
            {

                LeftMove.Start();
            }
            if (e.KeyCode == Keys.Right)
            {

                RightMove.Start();
            }
            if (e.KeyCode == Keys.Space)
            {
                Intersect();
                Shoot.settings.volume = 10;
                Shoot.controls.play();

                Player.Image = Properties.Resources.shoot_2;

                for (int i = 0; i < bullets.Length; i++)
                {
                    
                    if (bullets[i].Left > 1000)
                    {
                        bullets[i].Location = new Point(Player.Location.X + 100 + i * 50, Player.Location.Y + 50);
                    }

                 
                }
                Player.Image = Properties.Resources.stay1;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player.Image = Properties.Resources.stay1;

            LeftMove.Stop();
            RightMove.Stop();
            UpMove.Stop();
            DownMove.Stop();

        }

        private void MoveBulletsTimer_Tick(object sender, EventArgs e)
        {
            Player.Image = Properties.Resources.shoot_2;
            for (int i = 0; i < bullets.Length; i++)
            {
                
                bullets[i].Left += BulletsSpeed;
            }
            //Player.Image = Properties.Resources.stay1;
        }

        private void tEnemy_Tick(object sender, EventArgs e)
        {
            MoveEnemy(Enemy, EnemySpeed);
        }

        private void MoveEnemy(PictureBox[] enemy, int speed)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].Left -= speed + (int)(Math.Sin(enemy[i].Left * Math.PI / 180) + Math.Cos(enemy[i].Left * Math.PI / 180));

                Intersect();
                if (enemy[i].Left < 10)
                {
                    int SizeEnemy = rnd.Next(60, 90);
                    enemy[i].Size = new Size(SizeEnemy, SizeEnemy);
                    enemy[i].Location = new Point((i + 1) * rnd.Next(150, 250) + 720, rnd.Next(320, 480));
                }
            }
        }

        private void Intersect()
        {
            for (int i = 0; i < Enemy.Length; i++)
            {
                if (bullets[0].Bounds.IntersectsWith(Enemy[i].Bounds))
                {
                    Score += 1;
                    label3.Text = (Score < 10) ? "0" + Score.ToString() : Score.ToString();

                    if (Score==23)
                    {
                        GameOver("YOU WIN!!!");
                    }
                    Enemy[i].Location = new Point((i + 1) * rnd.Next(150, 250) + 1020, rnd.Next(320, 480));
                    bullets[0].Location = new Point(2000, Player.Location.Y + 50);
                }
                if (Player.Bounds.IntersectsWith(Enemy[i].Bounds))
                {
                    GameSong.settings.volume = 0;
                    //Rip.settings.volume = 100;
                    Player.Visible = false;
                    GameSong.settings.volume = 15;
                    GameOver("GAME OVER");
                    string Kills;
                    using (StreamReader rd = new StreamReader(WrightList, System.Text.Encoding.Default))
                    {
                        Kills = rd.ReadLine();
                    }
                    if (Int32.Parse(Kills)<Score)
                    {
                        using (StreamWriter sw = new StreamWriter(WrightList, false))
                        {
                            sw.WriteLine(Score);
                        }
                    }
                    
                }
            }
        }

        private void GameOver(string H)
        {
            label1.Text = H;
            label1.Location = new Point(300, 100);
            label1.Visible = true;
            GameSong.controls.stop();
            Rip.settings.volume = 100;
            tEnemy.Stop();
            MoveBulletsTimer.Stop();
            ExitButton.Location = new Point(380, 200);
            ExitButton.Visible = true;

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }
    }
}


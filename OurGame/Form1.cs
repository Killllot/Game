//Подкючение требуемых библиотек
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
        //Объявление переменных 
        PictureBox[] cloud;
        Random rnd;
        PictureBox[] bullets;
        PictureBox[] Enemy;
        string WrightList = @"Resources\myList.txt";// Путь к файлу с рекордом игрока
        int cloudspeed;
        int PlayerSpeed;
        int BulletsSpeed;
        int SizeEnemy;
        int EnemySpeed;
        int Score;
        //Тип данных WindowsMediaPlayer хранится в библеотеке WMPLib и отвечает за хранение звуковых дорожек
        WindowsMediaPlayer Shoot;
        WindowsMediaPlayer GameSong;
        WindowsMediaPlayer Rip;

        public Form1()
        {
            InitializeComponent();

        }

        //Загрузка формы 1
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            //Кнопка выхода в меню
            ExitButton.Click += (s, a) => {
                Form2 form2 = new Form2();
                form2.Show();
                this.Close();
            };
            //Задание скорости движения персонажа, облаков, пули, врага
            cloudspeed = 5;
            PlayerSpeed = 5;
            BulletsSpeed = 80;
            EnemySpeed = 3;
            //Внутриигровой счетчик счета
            Score = 0; 
            //Задание количества одномоментра существующих врагов, пуль, облаков
            bullets = new PictureBox[1];
            cloud = new PictureBox[20];
            rnd = new Random();
            Enemy = new PictureBox[3];
            //Задание размера врага
            SizeEnemy = rnd.Next(60, 90);
            //Задание скина врага
            Image eassyEnemy = Properties.Resources.Enemy;
            //Массив врагов
            for (int i = 0; i < Enemy.Length; i++)
            {
                Enemy[i] = new PictureBox();//Присвоение переменной
                Enemy[i].Size = new Size(SizeEnemy, SizeEnemy);//размер
                Enemy[i].SizeMode = PictureBoxSizeMode.Zoom;//Подгонка размера скина
                Enemy[i].BackColor = Color.Transparent;//Цвет фона
                Enemy[i].Image = eassyEnemy;//Скин
                Enemy[i].Location = new Point((i + 1) * rnd.Next(30, 100) +rnd.Next(30,100)+ 1080,i*50+ rnd.Next(250, 310));//Место появления
                this.Controls.Add(Enemy[i]);//Добавление объекта враг
            }
            //Звук выстрела
            Shoot = new WindowsMediaPlayer();
            Shoot.URL = "Resources\\shoot.KvyDz.mp3";
            Shoot.settings.volume = 0;

            //Звук при смерти персонажа
            Rip = new WindowsMediaPlayer();
            Rip.URL = "Resources\\rip.mp3";
            Rip.settings.volume = 0;

            //Звук в главном меню
            GameSong = new WindowsMediaPlayer();
            GameSong.URL = "Resources\\GameSong.mp3";
            GameSong.settings.setMode("loop", true);
            GameSong.settings.volume = 15;

            //Массив пуль
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox();//Присвоение переменной
                bullets[i].BorderStyle = BorderStyle.None;//Граница
                bullets[i].Size = new Size(20, 5);//Размер
                bullets[i].BackColor = Color.Red;//Цвет
                this.Controls.Add(bullets[i]);//Добавление объекта пуля
            }

            //Масиив облаков
            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i] = new PictureBox();//Присвоение переменной
                cloud[i].BorderStyle = BorderStyle.None;//Граница
                cloud[i].Location = new Point(rnd.Next(-1000, 1280), rnd.Next(40, 220));//Точка появления
                //Облака 1-го типа
                if (i % 2 == 1)
                {
                    cloud[i].Size = new Size(rnd.Next(100, 125), rnd.Next(30, 70));//Размер
                    cloud[i].BackColor = Color.FromArgb(rnd.Next(125, 125), 225, 200, 200);//Прозрачность
                }
                //Облака 2-го типа
                else
                {
                    cloud[i].Size = new Size(150, 25);//Размер 
                    cloud[i].BackColor = Color.FromArgb(rnd.Next(90, 125), 225, 205, 205);//Прозрачность
                }
                this.Controls.Add(cloud[i]);//Добавлние объекта
            }
            GameSong.controls.play();//Запуск звуковой дорожки 
        }

        //Таймер передвижения облаков
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

        //Таймер перемещения персонажа влево
        private void LeftMove_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= PlayerSpeed;
            }
        }

        //Таймер перемещения персонажа вправо
        private void RightMove_Tick(object sender, EventArgs e)
        {
            if (Player.Left < 850)
            {
                Player.Left += PlayerSpeed;
            }
        }

        //Таймер перемещения персонажа вверх
        private void UpMove_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 280)
            {
                Player.Top -= PlayerSpeed;
            }

        }

        //Таймер перемещения персонажа вниз
        private void DownMove_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 500)
            {
                Player.Top += PlayerSpeed;
            }
        }

        //Захват кнопок
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            Player.Image = Properties.Resources.cowboy_run;// Смена анимации на передвижение

            //Запуск движения вверх
            if (e.KeyCode == Keys.Up)
            {
                UpMove.Start();
            }
            //Запуск движения вниз
            if (e.KeyCode == Keys.Down)
            {
                DownMove.Start();
            }
            //Запуск движения влево
            if (e.KeyCode == Keys.Left)
            {
                LeftMove.Start();
            }
            //Запуск движения вправо
            if (e.KeyCode == Keys.Right)
            {
                RightMove.Start();
            }
            //Запуск полета пули
            if (e.KeyCode == Keys.Space)
            {
                Intersect();//Вызов метода определения состояния 
                Shoot.settings.volume = 10;//Установление громкости звука выстрела
                Shoot.controls.play();//Запуск звука выстрела

                //Траектория пули
                for (int i = 0; i < bullets.Length; i++)
                {
                    if (bullets[i].Left > 1000)
                    {
                        bullets[i].Location = new Point(Player.Location.X + 100 + i * 50, Player.Location.Y + 50);
                    }

                }
            }
        }

        //При отпускании соответствующих клавиш, останавливает таймеры передвижения
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player.Image = Properties.Resources.cowboy;

            LeftMove.Stop();
            RightMove.Stop();
            UpMove.Stop();
            DownMove.Stop();

        }

        //Таймер перемещения пули
        private void MoveBulletsTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < bullets.Length; i++)
            {   
                bullets[i].Left += BulletsSpeed;
            }
        }

        //Таймер передвижения врага
        private void tEnemy_Tick(object sender, EventArgs e)
        {
            MoveEnemy(Enemy, EnemySpeed);
        }
        //Передвижение врага
        private void MoveEnemy(PictureBox[] enemy, int speed)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].Left -= speed + (int)(Math.Sin(enemy[i].Left * Math.PI / 180) + Math.Cos(enemy[i].Left * Math.PI / 180));//Нелинейная скорость врага

                Intersect();//Вызов метода просчета состояния

                //Если враг уходит за левый край экрана
                if (enemy[i].Left < 10)
                {
                    int SizeEnemy = rnd.Next(60, 70);//Размер 
                    enemy[i].Size = new Size(SizeEnemy, SizeEnemy);//Присвоение размера
                    enemy[i].Location = new Point((i + 1) * rnd.Next(150, 250) + 620+i*100,i*50+ rnd.Next(250, 300));//Новавя позиция
                }
            }
        }

        //Метод определения состояния
        private void Intersect()
        {
            for (int i = 0; i < Enemy.Length; i++)
            {
                //Пуля-Враг соприкоснулись
                if (bullets[0].Bounds.IntersectsWith(Enemy[i].Bounds))
                {
                    //Добавление в счёт
                    Score += 1;
                    label3.Text = (Score < 10) ? "0" + Score.ToString() : Score.ToString();

                    //Выигрыш
                    if (Score==23)
                    {
                        GameOver("YOU WIN!!!");//Вызов метода игра окончена
                    }
                    //Смена расположения
                    Enemy[i].Location = new Point((i + 1) * rnd.Next(150, 250) + 1080, rnd.Next(140, 250)+ rnd.Next(140, 250));//Врага
                    bullets[0].Location = new Point(2000, Player.Location.Y + 50);//Пули
                }
                //Враг-игрок соприкоснулись
                if (Player.Bounds.IntersectsWith(Enemy[i].Bounds))
                {
                    GameSong.settings.volume = 0;//Заклушение звука
                    Player.Visible = false;//Смена прозрачности
                    GameSong.settings.volume = 15;//Возращение звука
                    GameOver("GAME OVER");//Вызов метода игра окончена
                    string Kills;//Объевление переменной убийств

                    //Считывание из файла рекорда убийств
                    using (StreamReader rd = new StreamReader(WrightList, System.Text.Encoding.Default))
                    {
                        Kills = rd.ReadLine();
                    }
                    //Сравнение счета за игру с рекордом
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

        //Метод игра окончена
        private void GameOver(string H)
        {
            label1.Text = H;//Присваивание полученного текста
            label1.Location = new Point(300, 100);//Расположение текста в заданной области
            label1.Visible = true;//Текст видим
            GameSong.controls.stop();//Остановка звука
            Rip.settings.volume = 100;//Уровень звучания звука смерти
            Rip.controls.play();//Запуск звука смерти
            tEnemy.Stop();//Остановка таймера врага
            MoveBulletsTimer.Stop();//Остановка таймера пули
            ExitButton.Location = new Point(380, 200);//Расположение кнопки выхода в меню
            ExitButton.Visible = true;//Кнопка выхода видна

        }
       
    }
}


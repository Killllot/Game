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
using System.IO;
using System.Globalization;
using System.Threading;
namespace OurGame
{
    public partial class Form2 : Form
    {

        
        public Form2()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");//Присваиваем начальную культуру
        
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        //Путь к текстовому файлу
        string WrightList = @"Resources\myList.txt";
        
        //Загрузка 
        private void Form2_Load(object sender, EventArgs e)
        {
            
            Form2 form = new Form2();
            //Кнопка выхода
            ExitGame.Click += (s, a) => { Application.Exit(); };
            //Кнопка старта игры
            button1.Click += (s, a) => {
                //Переключение и сокрытие формы
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            };
            //Чтение текста файла, путь к которому прописан в переменной WrightList и вывод его значение в поле рекорда
            using (StreamReader rd = new StreamReader(WrightList))
            {
                label1.Text = "Record: " + rd.ReadLine();
            }
        }

        //Кнопка смены языковой среды языковой среды
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                LocalizationHelper.ApplyCulture("en");
            }
            if (comboBox1.SelectedIndex==1)
            {
                LocalizationHelper.ApplyCulture("ru");
            }
        }
    }

    //Локализация
    public static class LocalizationHelper
    {
        public static void ApplyCulture(string cultureName = "en")
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureName);
            foreach (Form form in Application.OpenForms)
            {
                var res = new ComponentResourceManager(form.GetType());
                res.ApplyResources(form, "$this");
                foreach (Control ctrl in form.Controls)
                    ApplyCulture(res, ctrl);
            }
        }

        private static void ApplyCulture(ComponentResourceManager res, Control ctrl)
        {
            res.ApplyResources(ctrl, ctrl.Name);
            foreach (Control child in ctrl.Controls)
                ApplyCulture(res, child);
        }
    }
}

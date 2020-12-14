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

        string lan;
        public Form2()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");//присваиваем культуру
        
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            //Form2 dlg2 = new Form2();
            this.Hide();
        }

        string WrightList = @"myList.txt";
        
        private void Form2_Load(object sender, EventArgs e)
        {
            Form2 form = new Form2();
             
            using (StreamReader rd = new StreamReader(WrightList))
            {
                label1.Text = "Record: " + rd.ReadLine();
            }
        }

        private void ExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

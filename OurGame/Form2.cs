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

namespace OurGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            //Form2 dlg2 = new Form2();
            this.Hide();
        }

        string WrightList = @"Resources/myList.txt";
        
        private void Form2_Load(object sender, EventArgs e)
        {
            
            using (StreamReader rd = new StreamReader(WrightList))
            {
                label1.Text = "Record: " + rd.ReadLine();
            }
        }

        private void ExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

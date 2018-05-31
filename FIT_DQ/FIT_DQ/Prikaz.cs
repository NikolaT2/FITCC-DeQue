using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace FIT_DQ
{
    public partial class Prikaz : Form
    {
        private FormWindowState LastWindowState;
        public float vrijemeBlinkanja=0;
        private  bool vidljivost=false;
        public bool upaliBlinkanje = false;
        public Prikaz()
        {
            InitializeComponent();
            /*string filename = "test.test";
            
            File.WriteAllBytes(filename,Properties.Resources.digital_7);*/
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("fontDigital7.ttf");

            labela.Font = new Font(pfc.Families[0], 200);
        }

        private void labela_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            blinkanje(upaliBlinkanje);
        }
        private void blinkanje(bool upaliBlinkanje) {
            if (upaliBlinkanje)
            {
                vrijemeBlinkanja += (float)timer.Interval / 1000;
                if (vidljivost)
                {
                    vidljivost = false;
                    labela.ForeColor = Color.White;

                }
                else if (!vidljivost)
                {
                    labela.ForeColor = Color.Black;
                    vidljivost = true;
                }
            }
            else
                labela.ForeColor = Color.White;
        }

        private void Prikaz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
        }

        private void Prikaz_Load(object sender, EventArgs e)
        {
            LastWindowState = FormWindowState.Normal;
        }

        private void Prikaz_Resize(object sender, EventArgs e)
        {
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;
                if (WindowState == FormWindowState.Maximized)
                {
                    FormBorderStyle = FormBorderStyle.None;
                }
                if (WindowState == FormWindowState.Normal)
                {

                    FormBorderStyle = FormBorderStyle.Sizable;
                }
            }
        }
        
    }
}

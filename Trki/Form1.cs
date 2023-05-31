using System;
using System.Drawing;
using System.Windows.Forms;

namespace Trki
{
    public partial class Form1: Form
    {
        bool Levo, Desno, Gor, Dol;
        const int Premik = 7;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                Levo = true;

            if (e.KeyCode == Keys.Right)
                Desno = true;

            if (e.KeyCode == Keys.Up)
                Gor = true;

            if (e.KeyCode == Keys.Down)
                Dol = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                Levo = false;

            if (e.KeyCode == Keys.Right)
                Desno = false;

            if (e.KeyCode == Keys.Up)
                Gor = false;


            if (e.KeyCode == Keys.Down)
                Dol = false;
        }

        private void Casovnik_Tick(object sender, EventArgs e)
        {
            // Junak se premakne levo
            if (Levo == true && junak.Left > 0)
            {
                junak.Left -= Premik;
            }
            // Junak se premakne desno
            if (Desno == true && junak.Right < this.Width)
            {
                junak.Left += Premik;
            }
            // Junak se premakne gor
            if (Gor == true && junak.Top > 0)
            {
                junak.Top -= Premik;
            }
            // Junak se premakne dol
            if (Dol == true && junak.Bottom < this.Height)
            {
                junak.Top += Premik;
            }

            foreach (Control control in Controls)
            {
                if ((string)control.Tag == "senzor")
                {
                    if (junak.Bounds.IntersectsWith(control.Bounds))
                        control.BackColor = Color.Red;
                    else
                        control.BackColor = Color.Yellow;
                }
            }
        }
    }
}
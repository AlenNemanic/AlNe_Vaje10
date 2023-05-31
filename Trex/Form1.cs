using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace Letala
{
    // vir: https://www.mooict.com/c-tutorial-create-a-t-rex-endless-runner-game-in-visual-studio/
    public partial class Form1: Form
    {
        bool skakanje = false;
        int hitrostskoka;
        int sila = 12;
        int sttock = 0;
        int hitrostOvir = 10;
        Random rand = new Random();
        bool zacetek = true;
        bool konecIgre = false;
        int pozicija;
        string pot = @"Rezultati.json";
        Igralec uporabnik;
        private List<Igralec> igralci = new List<Igralec>();

        public Form1()
        {
            InitializeComponent();

            Reset();
        }

        private void casovnik_Tick(object sender, EventArgs e)
        {
            rex.Top += hitrostskoka;
            tocke.Text = sttock.ToString();

            if (skakanje == true && sila < 0)
            {
                skakanje = false;
            }
            if (skakanje == true)
            {
                hitrostskoka = -12;
                sila -= 1;
            }
            else
            {
                hitrostskoka = 12;
            }

            if (rex.Top > 275 && skakanje == false)
            {
                sila = 12;
                rex.Top = 276;
                hitrostskoka = 0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ovira")
                {
                    x.Left -= hitrostOvir;

                    if (x.Left < -100)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(200, 500) + (x.Width * 15);
                        sttock++;
                    }

                    if (rex.Bounds.IntersectsWith(x.Bounds))
                    {
                        casovnik.Stop();
                        KoncnoSporocilo.Text = $"Press R to restart the game!\n       Your score: {sttock}";
                        label1.Visible = false;
                        label2.Visible = false;
                        tocke.Visible = false;
                        najtocke.Visible = false;
                        konecIgre = true;
                    }
                }
            }
            if (sttock > 5)
            {
                hitrostOvir = 15;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && skakanje == false)
            {
                skakanje = true;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (skakanje == true)
            {
                skakanje = false;
            }

            if (e.KeyCode == Keys.R && konecIgre == true)
            {
                Reset();
            }
        }

        private void Reset()
        {
            sila = 12;
            hitrostskoka = 0;
            skakanje = false;
            sttock = 0;
            hitrostOvir = 10;
            tocke.Text = sttock.ToString();
            konecIgre = false;
            label1.Visible = true;
            label2.Visible = true;
            tocke.Visible = true;
            najtocke.Visible = true;
            KoncnoSporocilo.Text = "";
            igralci = LoadJson();
            rex.Top = 276;

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && (string)x.Tag == "ovira")
                {
                    pozicija = this.ClientSize.Width + rand.Next(500, 800) + (x.Width * 10);

                    x.Left = pozicija;
                }
            }

            casovnik.Start();

            if (zacetek)
            {
                List<Igralec> igr = LoadJson();
                igr.Reverse();
                if (igr.Count() > 0)
                {
                    int najboljsi = igr[0].Tocke;
                    najtocke.Text = najboljsi.ToString();
                }
            }
        }

        public List<Igralec> LoadJson()
        {
            if (File.Exists(pot))
            {
                using (StreamReader r = new StreamReader(pot))
                {

                    string json = r.ReadToEnd();
                    List<Igralec> podatki = JsonSerializer.Deserialize<List<Igralec>>(json);

                    podatki.Sort();

                    return podatki;
                }
            }
            else
            {
                return new List<Igralec>();
            }
        }
    }
}
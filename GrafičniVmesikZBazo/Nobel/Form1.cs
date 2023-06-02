using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Nobel
{
    public partial class Form1 : Form
    {
        private const string povNiz = @"Server=baza.fmf.uni-lj.si;User Id=student11;Password=student;Database=nobel2012;";
        private DataSet dataSet;

        public Form1()
        {
            InitializeComponent();
        }

        private void Poisci(object sender, MouseEventArgs e)
        {
            string podrocje = podrocjeComboBox.Text.ToString();
            int leto;
            textBox.Clear();
            string vnosLeto = letoTextBox.Text.Trim(' ');
            if (int.TryParse(vnosLeto, out leto))
            {
                DataRow[] rezultati = dataSet.Tables["nobel"].Select("subject = '" + podrocje + "' AND yr = " + leto);
                foreach (DataRow row in rezultati)
                {
                    string vrstica = "";
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        vrstica += row[i].ToString() + " ";
                    }
                    textBox.Text += " * " + vrstica;
                    textBox.AppendText(Environment.NewLine);
                }
            }
            else
            {
                MessageBox.Show("Nepravilni podatki!", "Napaka!");
                letoTextBox.Text = "";
            }
        }

        private void OknoNalozi(object sender, EventArgs e)
        {
            NpgsqlConnection povezava = new NpgsqlConnection(povNiz);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM nobel", povezava);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "nobel");
            DataTable dt = dataSet.Tables["nobel"];
            DataView view = new DataView(dt);
            DataTable vsaPodrocja = view.ToTable(true, "subject");
            podrocjeComboBox.DisplayMember = "subject";
            podrocjeComboBox.DataSource = vsaPodrocja;
        }
    }
}
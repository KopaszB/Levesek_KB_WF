using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Levesek_KB_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Leves ujleves = new Leves
            {
                Megnevezes = txt_Megnevezes.Text,
                Kaloria = int.Parse(txt_Kaloria.Text),
                Feherje = double.Parse(txt_Feherje.Text),
                Zsir = double.Parse(txt_Zsir.Text),
                Szenhidrat = double.Parse(txt_Szenhidrat.Text),
                Hamu = double.Parse(txt_Hamu.Text),
                Rost = double.Parse(txt_Rost.Text)
            };

            Adatbazis adatbazis = new Adatbazis();
            int eredmeny = adatbazis.ujlevesHozzaad(ujleves);
            MessageBox.Show("Sikeres rögzítés!");
            TextboxUrit();
           
        }

        private void TextboxUrit()
        {
            txt_Megnevezes.Text = "";
            txt_Kaloria.Text = "";
            txt_Feherje.Text = "";
            txt_Zsir.Text = "";
            txt_Szenhidrat.Text = "";
            txt_Hamu.Text = "";
            txt_Rost.Text = "";
        }
    }
}

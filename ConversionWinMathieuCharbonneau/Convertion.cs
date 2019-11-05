using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversionWinMathieuCharbonneau
{
    public partial class Convertion : Form
    {
        private double valeurChange;
        public Convertion()
        {
            InitializeComponent();
            valeurChange = GetCurrency();
            textBox1.Text = valeurChange.ToString();
        }


        private void buttonConvertir_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Veuillez sélectionner un sens de conversion");
            }else if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("La valeur de change doit être indiquée");
            }else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Le montant à convertir doit être indiqué");
            }else if (!IsNumeric(textBox1.Text)){
                MessageBox.Show("Veuillez saisir un nombre pour la valeur de change");
            }else if (!IsNumeric(textBox2.Text))
            {
                MessageBox.Show("Veuillez saisir un nombre pour le montant à convertir");
            }else
            {
                double valeurAConvertir = double.Parse(textBox2.Text);
                double reponse = 0;
                string currencySymbol = "";
                if(radioButton1.Checked)
                {
                    reponse = Math.Round((valeurAConvertir * (1 / valeurChange)), 2);
                    currencySymbol = "€";
                }
                if(radioButton2.Checked)
                {
                    reponse = Math.Round((valeurChange * valeurAConvertir),2);
                    currencySymbol = "$";
                }
                textBox3.Text = reponse.ToString() + " " + currencySymbol;
            }
        }

        public bool IsNumeric(string Nombre)
        {
            try
            {
                double.Parse(Nombre);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            labelRouge.Text = "CAD";
            labelBleu.Text = "EURO";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            labelRouge.Text = "EURO";
            labelBleu.Text = "CAD";
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            toutEffacer();
        }

        private void toutEffacer()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public double GetCurrency()
        {
            string apiCall = new System.Net.WebClient().DownloadString("https://api.exchangeratesapi.io/latest");
            dynamic currency = JsonConvert.DeserializeObject(apiCall);
            double EURValue = currency.rates.CAD;
            return EURValue;
        }
    }
}

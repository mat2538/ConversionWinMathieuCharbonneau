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
    public partial class Form1 : Form
    {
        private const int CHANCES = 3;
        private int errAuth;

        public Form1()
        {
            errAuth = 0;
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomAcces.Text) || string.IsNullOrWhiteSpace(textBoxMotDePasse.Text))
            {
                MessageBox.Show("Un nom d'utilisateur et un mot de passe sont requis pour obtenir accès au système");
                //nom d'utilisateur = admin    mdp= admin
            }else if(textBoxNomAcces.Text.GetHashCode() != 1156371652 || textBoxMotDePasse.Text.GetHashCode() != 1156371652)
            {
                errAuth++;
                if (errAuth == CHANCES)
                {
                    Environment.Exit(0);
                }
                MessageBox.Show("erreur d'authentification, il vous reste " + (CHANCES - errAuth) + " chances.");
            }else
            {
                Convertion fenetre = new Convertion();
                fenetre.Show();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet1TrainFerroviaire
{
    public partial class AddWagon : Form
    {
        // Accesseur publique et mutateur privé
        public Wagon wagon { get; private set; }

        // Constructeur par défaut
        public AddWagon()
        {
            InitializeComponent();
        }

        // Événement déclenché lors du clic sur le bouton "Ajouter Wagon"
        private void addWagon_btn_Click(object sender, EventArgs e)
        {
            //Radio button type wagon
            typeW? typeWagon = null;
            if (grain_rbtn.Checked) { typeWagon = typeW.grain; }
            if (animaux_rbtn.Checked) { typeWagon = typeW.animaux; }
            if (citerne_rbtn.Checked) { typeWagon = typeW.citerne; }

            //Radio button couleur
            Color? couleur = null;
            if (yellow_rbtn.Checked) { couleur = Color.Yellow; }
            if (gray_rbtn.Checked) { couleur = Color.Gray; }
            if (wood_rbtn.Checked) { couleur = Color.Brown; }
            if (black_rbtn.Checked) { couleur = Color.Black; }

            try
            {
                // Vérification si le type de locomotive ou la couleur est null
                if (typeWagon == null) { throw new Exception("Aucun type de wagon a été choisi."); }
                if (couleur == null) { throw new Exception("Aucune couleur a été choisi."); }

                // Crée une nouvelle instance de Wagon
                wagon = new Wagon((typeW)typeWagon,wagon_txt.Text, (Color)couleur);

                //Ferme le form avec succes
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) when (ex is Exception || ex is ChaineException || ex is EntierException)
            {
                // Affiche un message d'erreur en cas d'exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disableAllColorRadioButton()
        {
            yellow_rbtn.Enabled = false;
            gray_rbtn.Enabled = false;
            wood_rbtn.Enabled = false;
            black_rbtn.Enabled = false;
            yellow_rbtn.Checked = false;
            gray_rbtn.Checked = false;
            wood_rbtn.Checked = false;
            black_rbtn.Checked = false;
        }

        private void grain_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (grain_rbtn.Checked)
            {
                disableAllColorRadioButton();
                gray_rbtn.Enabled = true;
                wood_rbtn.Enabled = true;
            }
        }

        private void animaux_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (animaux_rbtn.Checked)
            {
                disableAllColorRadioButton();
                yellow_rbtn.Enabled = true;
                wood_rbtn.Enabled = true;
            }
        }

        private void citerne_rbtn_CheckedChanged(object sender, EventArgs e)
        {

            if (citerne_rbtn.Checked)
            {
                disableAllColorRadioButton();
                black_rbtn.Enabled = true;
                gray_rbtn.Enabled = true;
            }
        }
    }
}

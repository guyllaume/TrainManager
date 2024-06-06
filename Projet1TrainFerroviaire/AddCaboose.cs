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
    public partial class AddCaboose : Form
    {
        // Accesseur publique et mutateur privé
        public Caboose caboose { get; private set; }

        // Constructeur par défaut
        public AddCaboose()
        {
            InitializeComponent();
        }

        // Événement déclenché lors du clic sur le bouton "Ajouter Caboose"
        private void addCaboose_btn_Click(object sender, EventArgs e)
        {
            //Radio button type wagon
            typeCab? typeCaboose = null;
            if (restaurant_rbtn.Checked) { typeCaboose = typeCab.restaurant; }
            if (passager_rbtn.Checked) { typeCaboose = typeCab.passager; }

            //Radio button couleur
            Color? couleur = null;
            if (blue_rbtn.Checked) { couleur = Color.Blue; }
            if (green_rbtn.Checked) { couleur = Color.Green; }

            try
            {
                // Vérification si le type de locomotive ou la couleur est null
                if (typeCaboose == null) { throw new Exception("Aucun type de Caboose a été choisi."); }
                if (couleur == null) { throw new Exception("Aucune couleur a été choisi."); }

                // Crée une nouvelle instance de Caboose
                caboose = new Caboose((typeCab)typeCaboose, caboose_txt.Text, (Color)couleur);

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
    }
}

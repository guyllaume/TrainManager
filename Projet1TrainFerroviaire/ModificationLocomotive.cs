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
    public partial class ModificationLocomotive : Form
    {
        public TrainFerroviaire train { get; private set; }
        public ModificationLocomotive(TrainFerroviaire trainFerroviaire)
        {
            InitializeComponent();
            train = trainFerroviaire;
            Locomotive loco = (Locomotive)trainFerroviaire.Train[0];
            nomLocomotive_txt.Text = loco.Nom;
            switch (loco.TypeLocomotive)
            {
                case typeLocomotive.longVoyage:
                    longVoyage_rbtn.Checked = true;
                    break;
                case typeLocomotive.moyenVoyage:
                    moyenVoyage_rbtn.Checked = true;
                    break;
                case typeLocomotive.courtVoyage:
                    courtVoyage_rbtn.Checked = true;
                    break;
            }
            if(loco.Couleur == Color.Blue)
            {
                blue_rbtn.Checked = true;
            }else if(loco.Couleur == Color.Brown)
            {
                brown_rbtn.Checked = true;
            }else if(loco.Couleur == Color.Green) 
            {
                green_rbtn.Checked = true;
            }

        }

        private void modifierLocomotive_btn_Click(object sender, EventArgs e)
        {
            //Radio button couleur
            Color? couleur = null;
            if (blue_rbtn.Checked) { couleur = Color.Blue; }
            if (brown_rbtn.Checked) { couleur = Color.Brown; }
            if (green_rbtn.Checked) { couleur = Color.Green; }

            //Radio button type locomotive
            typeLocomotive? typeLoco = null;
            if (longVoyage_rbtn.Checked) { typeLoco = typeLocomotive.longVoyage; }
            if (moyenVoyage_rbtn.Checked) { typeLoco = typeLocomotive.moyenVoyage; }
            if (courtVoyage_rbtn.Checked) { typeLoco = typeLocomotive.courtVoyage; }

            try
            {
                if (typeLoco == null) { throw new Exception("Aucun type de locomotive a été choisi."); }
                if (couleur == null) { throw new Exception("Aucune couleur a été choisi."); }

                train.Modifier(nomLocomotive_txt.Text, (typeLocomotive)typeLoco, (Color)couleur);
               
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) when (ex is Exception || ex is ChaineException || ex is EntierException || ex is ExplosionException || ex is TrainException || ex is VitesseException)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

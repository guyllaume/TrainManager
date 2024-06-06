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
    public partial class AddTrainForm : Form
    {
        public TrainFerroviaire trainFerroviaire { get; private set; }
        public AddTrainForm()
        {
            InitializeComponent();

            // Sélectionne le premier élément des ComboBoxes au démarrage
            caboose_cb.SelectedIndex = 0;
            wagon_cb.SelectedIndex = 0;
        }

        private void AddTrain_btn_Click(object sender, EventArgs e)
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
                // Vérifie si le type de locomotive et la couleur sont sélectionnés
                if (typeLoco == null) { throw new Exception("Aucun type de locomotive a été choisi."); }
                if(couleur == null) { throw new Exception("Aucune couleur a été choisi."); }

                // Crée une nouvelle instance de Locomotive
                Locomotive locomotive = new Locomotive((typeLocomotive)typeLoco, nomLocomotive_txt.Text, (Color)couleur);

                // Crée une Liste pour stocker les véhicules
                List<Véhicule> listVehicules = new List<Véhicule>();

                // Ajoute les wagons
                for (int i = 0; i < int.Parse(wagon_cb.SelectedItem.ToString()); i++)
                {
                    // Création d'un formulaire d'ajout d'un Wagon
                    using (AddWagon addWagon = new AddWagon())
                    {
                        if (addWagon.ShowDialog() == DialogResult.OK)
                        {
                            listVehicules.Add(addWagon.wagon);
                        }
                    }
                }

                // Ajoute les Cabooses
                for (int i = 0; i < int.Parse(caboose_cb.SelectedItem.ToString()); i++)
                {
                    // Création d'un formulaire d'ajout d'un Caboose
                    using (AddCaboose addCaboose = new AddCaboose())
                    {
                        if (addCaboose.ShowDialog() == DialogResult.OK)
                        {
                            listVehicules.Add(addCaboose.caboose);
                        }
                    }
                }

                // Crée une nouvelle instance de TrainFerroviaire
                if (listVehicules.Count == 0)
                    trainFerroviaire = new TrainFerroviaire(nomTrain_txt.Text, locomotive);
                else
                    trainFerroviaire = new TrainFerroviaire(nomTrain_txt.Text, locomotive, listVehicules);

                // Ferme le formulaire avec un résultat OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }catch(Exception ex) when (ex is Exception || ex is ChaineException || ex is EntierException || ex is ExplosionException || ex is TrainException || ex is VitesseException || ex is NullReferenceException)
            {
                // Affiche un message d'erreur en cas d'exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

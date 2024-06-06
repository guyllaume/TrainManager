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
    public partial class Wagon_Caboose_Locomotive_Choice : Form
    {
        // Accesseur publique et mutateur privé
        public Véhicule véhicule {  get; private set; }

        // Constructeur par défaut
        public Wagon_Caboose_Locomotive_Choice()
        {
            InitializeComponent();
        }

        // Événement déclenché lors du clic sur le bouton "Wagon"
        private void AddWagon_Click(object sender, EventArgs e)
        {
            //Initialisation d'un nouveau formulaire pour ajouter un Wagon
            using (AddWagon addWagon = new AddWagon())
            {
                if (addWagon.ShowDialog() == DialogResult.OK)
                {
                    //Affecte le nouveau wagon au véhicule et ferme le form
                    véhicule = addWagon.wagon;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        // Événement déclenché lors du clic sur le bouton "Caboose"
        private void AddCaboose_Click(object sender, EventArgs e)
        {
            //Initialisation d'un nouveau formulaire pour ajouter un Caboose
            using (AddCaboose addCaboose = new AddCaboose())
            {
                if (addCaboose.ShowDialog() == DialogResult.OK)
                {
                    //Affecte le nouveau Caboose au véhicule et ferme le form
                    véhicule = addCaboose.caboose;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        // Événement déclenché lors du clic sur le bouton "Locomotive"
        private void AddLocomotive_Click(object sender, EventArgs e)
        {
            //Affiche un message d'erreur puisqu'il ne peut pas avoir 2 locomotive
            MessageBox.Show("Un train ne peut pas avoir plus d'une locomotive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

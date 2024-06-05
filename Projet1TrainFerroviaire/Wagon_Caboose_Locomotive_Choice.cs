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
        public Véhicule véhicule {  get; private set; }
        public Wagon_Caboose_Locomotive_Choice()
        {
            InitializeComponent();
        }

        private void AddWagon_Click(object sender, EventArgs e)
        {

            using (AddWagon addWagon = new AddWagon())
            {
                if (addWagon.ShowDialog() == DialogResult.OK)
                {
                    véhicule = addWagon.wagon;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void AddCaboose_Click(object sender, EventArgs e)
        {
            using (AddCaboose addCaboose = new AddCaboose())
            {
                if (addCaboose.ShowDialog() == DialogResult.OK)
                {
                    véhicule = addCaboose.caboose;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void AddLocomotive_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Un train ne peut pas avoir plus d'une locomotive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

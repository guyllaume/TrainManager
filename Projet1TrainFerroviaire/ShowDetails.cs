using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet1TrainFerroviaire
{
    public partial class ShowDetails : Form
    {
        public ShowDetails(Véhicule vehicule)
        {
            InitializeComponent();

            //Detail du véhicule selon son identifiant
            switch (vehicule.Identifiant)
            {
                case "Caboose":
                    Caboose tempCaboose = vehicule as Caboose;
                    titreDetail_lbl.Text = "Caboose : " + tempCaboose.Nom;
                    detail_lbl.Text = tempCaboose.ToString();
                    break;
                case "Wagon":
                    Wagon tempWagon = vehicule as Wagon;
                    titreDetail_lbl.Text = "Wagon : " + tempWagon.Nom;
                    detail_lbl.Text = tempWagon.ToString();
                    break;
                case "Locomotive":
                    Locomotive tempLoco = vehicule as Locomotive;
                    titreDetail_lbl.Text = "Locomotive : " + tempLoco.Nom;
                    detail_lbl.Text = tempLoco.ToString();
                    break;

            }
            centerTitle();
        }
        public ShowDetails(TrainFerroviaire train)
        {
            InitializeComponent();

            //Detail du train
            titreDetail_lbl.Text = "Train : " + train.Nom;
            detail_lbl.Text = train.ToString();
            centerTitle();
        }

        private void centerTitle()
        {
            int formWidth = this.ClientSize.Width;
            int labelWidth = titreDetail_lbl.Width;
            int centeredX = (formWidth - labelWidth) / 2;
            titreDetail_lbl.Location = new Point(centeredX, titreDetail_lbl.Location.Y);
        }
    }
}

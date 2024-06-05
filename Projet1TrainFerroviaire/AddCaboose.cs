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
        public Caboose caboose { get; private set; }
        public AddCaboose()
        {
            InitializeComponent();
        }

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
                if (typeCaboose == null) { throw new Exception("Aucun type de Caboose a été choisi."); }
                if (couleur == null) { throw new Exception("Aucune couleur a été choisi."); }

                caboose = new Caboose((typeCab)typeCaboose, caboose_txt.Text, (Color)couleur);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) when (ex is Exception || ex is ChaineException || ex is EntierException)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

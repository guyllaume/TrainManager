using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet1TrainFerroviaire
{
    public partial class Form1 : Form
    {
        const int LOCATION_Y_SPACER_NEW_TRAIN = 130;
        const int LOCATION_X_SPACER_TRAIN = 100;
        const int INITIAL_LOCATION_Y = 100;
        const int INITIAL_LOCATION_X = 15;
        const int BUTTON_PANEL_WIDTH = 80;
        const int BUTTON_PANEL_HEIGHT = 125;
        const int BUTTON_WIDTH = 75;
        const int BUTTON_HEIGHT = 25;
        const int TABLE_PANEL_WIDTH = 110;
        const int TABLE_PANEL_HEIGHT = 100;
        const int X_IMAGE_WIDTH = 20;
        const int X_IMAGE_HEIGHT = 25;
        const int TRAIN_PANEL_WIDTH = 2000;
        const int TRAIN_PANEL_HEIGHT = 125;

        List<TrainFerroviaire> listeTrain = new List<TrainFerroviaire>();
        List<FlowLayoutPanel> listButtonPanels = new List<FlowLayoutPanel>();
        List<FlowLayoutPanel> listVehicule = new List<FlowLayoutPanel>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the train Builder Application !\n" +
                "To Start building a train, click on 'Add Train'");
        }

        private void AddVehiculeEvent(FlowLayoutPanel vehiculePanel, TrainFerroviaire train)
        {
            using (Wagon_Caboose_Locomotive_Choice addVehicule = new Wagon_Caboose_Locomotive_Choice())
            {
                if (addVehicule.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        train.Attacher(addVehicule.véhicule);
                        Véhicule véhicule = train.Train[train.Train.Count-1];
                        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
                        {
                            ColumnCount = 1,
                            RowCount = 2
                        };
                        tableLayoutPanel.Size = new Size(TABLE_PANEL_WIDTH, TABLE_PANEL_HEIGHT);
                        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));

                        PictureBox x_pbox = new PictureBox();
                        x_pbox.Image = Properties.Resources.X_button;
                        x_pbox.Size = new Size(X_IMAGE_WIDTH, X_IMAGE_HEIGHT);
                        x_pbox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        x_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        x_pbox.Cursor = Cursors.Hand;
                        x_pbox.Click += (s, e) => DeleteVehiculeEvent(tableLayoutPanel, train, véhicule);

                        tableLayoutPanel.Controls.Add(x_pbox, 0, 0);

                        PictureBox vehicule_pbox = new PictureBox();

                        switch (train.Train[train.Train.Count - 1].Identifiant)
                        {
                            case "Locomotive":
                                if (train.Train[train.Train.Count - 1].Couleur == Color.Blue)
                                    vehicule_pbox.Image = Properties.Resources.locomotive_bleu;
                                if (train.Train[train.Train.Count - 1].Couleur == Color.Green)
                                    vehicule_pbox.Image = Properties.Resources.locomotive_green;
                                if (train.Train[train.Train.Count - 1].Couleur == Color.Brown)
                                    vehicule_pbox.Image = Properties.Resources.locomotive_brun;
                                break;
                            case "Wagon":
                                Wagon tempWagon = train.Train[train.Train.Count - 1] as Wagon;
                                switch (tempWagon.TypeWagon)
                                {
                                    case typeW.grain:
                                        if (train.Train[train.Train.Count - 1].Couleur == Color.Gray)
                                            vehicule_pbox.Image = Properties.Resources.Wagon_Grain_Gris;
                                        if (train.Train[train.Train.Count - 1].Couleur == Color.Brown)
                                            vehicule_pbox.Image = Properties.Resources.wagon_grain_Wood;
                                        break;
                                    case typeW.citerne:
                                        if (train.Train[train.Train.Count - 1].Couleur == Color.Gray)
                                            vehicule_pbox.Image = Properties.Resources.Wagon_Citerne_Gris;
                                        if (train.Train[train.Train.Count - 1].Couleur == Color.Black)
                                            vehicule_pbox.Image = Properties.Resources.wagon_citerne_Black;
                                        break;
                                    case typeW.animaux:
                                        if (train.Train[train.Train.Count - 1].Couleur == Color.Yellow)
                                            vehicule_pbox.Image = Properties.Resources.wagon_animaux_Yellow;
                                        if (train.Train[train.Train.Count - 1].Couleur == Color.Brown)
                                            vehicule_pbox.Image = Properties.Resources.wagon_animaux_Wood;
                                        break;
                                }
                                break;
                            case "Caboose":
                                if (train.Train[train.Train.Count - 1].Couleur == Color.Blue)
                                    vehicule_pbox.Image = Properties.Resources.caboose_blue;
                                if (train.Train[train.Train.Count - 1].Couleur == Color.Green)
                                    vehicule_pbox.Image = Properties.Resources.caboose_green;
                                break;
                        }
                        vehicule_pbox.Dock = DockStyle.Fill;
                        vehicule_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        vehicule_pbox.Cursor = Cursors.Hand;
                        vehicule_pbox.Click += (s, e) => ShowDetailsVehiculeEvent(véhicule);

                        tableLayoutPanel.Controls.Add(vehicule_pbox, 0, 1);
                        vehiculePanel.Controls.Add(tableLayoutPanel);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void DeleteTrainEvent(FlowLayoutPanel buttonPanel, FlowLayoutPanel vehiculePanel, TrainFerroviaire train)
        {
            this.Controls.Remove(buttonPanel);
            buttonPanel.Dispose();
            listButtonPanels.Remove(buttonPanel);
            this.Controls.Remove(vehiculePanel);
            vehiculePanel.Dispose();
            listVehicule.Remove(vehiculePanel);
            listeTrain.Remove(train);

            int index = 0;
            foreach (FlowLayoutPanel vehiculeFLP in listVehicule)
            {
                vehiculeFLP.Location = new Point(INITIAL_LOCATION_X + LOCATION_X_SPACER_TRAIN, INITIAL_LOCATION_Y + index * LOCATION_Y_SPACER_NEW_TRAIN);
                index++;
            }
            index = 0;
            foreach (FlowLayoutPanel buttonFLP in listButtonPanels)
            {
                buttonFLP.Location = new Point(INITIAL_LOCATION_X, INITIAL_LOCATION_Y + index * LOCATION_Y_SPACER_NEW_TRAIN);
                index++;
            }
        }
        private void ModifyLocomotiveEvent(PictureBox locomotivePBox, int trainIndex, Locomotive locomotive)
        {
            using(ModificationLocomotive modifyLoco = new ModificationLocomotive(listeTrain[trainIndex]))
            {
                if(modifyLoco.ShowDialog() == DialogResult.OK)
                {
                    listeTrain[trainIndex] = modifyLoco.train;
                    if (listeTrain[trainIndex].Train[0].Couleur == Color.Blue)
                        locomotivePBox.Image = Properties.Resources.locomotive_bleu;
                    if (listeTrain[trainIndex].Train[0].Couleur == Color.Green)
                        locomotivePBox.Image = Properties.Resources.locomotive_green;
                    if (listeTrain[trainIndex].Train[0].Couleur == Color.Brown)
                        locomotivePBox.Image = Properties.Resources.locomotive_brun;
                }
            }
        }
        private void DeleteVehiculeEvent(TableLayoutPanel vehiculePanel, TrainFerroviaire train, Véhicule véhicule)
        {
            try
            {
                if (train.Detacher(véhicule))
                {
                    foreach (FlowLayoutPanel flPanel in listVehicule)
                    {
                        foreach (TableLayoutPanel tlPanel in flPanel.Controls)
                        {
                            if (vehiculePanel == tlPanel)
                            {
                                flPanel.Controls.Remove(tlPanel);
                                tlPanel.Dispose();
                            }                        
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erreur de code, Vehicule toujours attacher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowDetailsVehiculeEvent(Véhicule véhicule)
        {
            ShowDetails showDetails = new ShowDetails(véhicule);
            showDetails.Show();
        }
        private void ShowDetailsTrainEvent(TrainFerroviaire train)
        {
            ShowDetails showDetails = new ShowDetails(train);
            showDetails.Show();
        }

        private void AddTrain_Click(object sender, EventArgs ev)
        {
            using (AddTrainForm addTrainForm = new AddTrainForm())
            {
                if(addTrainForm.ShowDialog() == DialogResult.OK)
                {
                    listeTrain.Add(addTrainForm.trainFerroviaire);
                    listButtonPanels.Add(new FlowLayoutPanel());
                    listVehicule.Add(new FlowLayoutPanel());
                    FlowLayoutPanel vehiculeFLLast = listVehicule.Last();
                    FlowLayoutPanel buttonFLLast = listButtonPanels.Last();
                    TrainFerroviaire trainLast = listeTrain.Last();

                    //Button Panel

                    listButtonPanels.Last().Location = new Point(INITIAL_LOCATION_X, INITIAL_LOCATION_Y + ((listeTrain.Count()-1) * LOCATION_Y_SPACER_NEW_TRAIN));
                    listButtonPanels.Last().Size = new Size(BUTTON_PANEL_WIDTH, BUTTON_PANEL_HEIGHT);


                    Button addVehicule_btn = new Button();

                    addVehicule_btn.Size = new Size(BUTTON_WIDTH,BUTTON_HEIGHT);
                    addVehicule_btn.Font = new Font("Arial", 8);
                    addVehicule_btn.FlatStyle = FlatStyle.Flat;
                    addVehicule_btn.BackColor = Color.Tan;
                    addVehicule_btn.ForeColor = Color.Gray;
                    addVehicule_btn.Text = "Ajouter";

                    addVehicule_btn.Click += (s,e) => AddVehiculeEvent(vehiculeFLLast, trainLast);


                    Button deleteTrain_btn = new Button();

                    deleteTrain_btn.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                    deleteTrain_btn.Font = new Font("Arial", 8);
                    deleteTrain_btn.FlatStyle = FlatStyle.Flat;
                    deleteTrain_btn.BackColor = Color.Tan;
                    deleteTrain_btn.ForeColor = Color.Gray;
                    deleteTrain_btn.Text = "Supprimer";
                    deleteTrain_btn.Click += (s,e) => DeleteTrainEvent(buttonFLLast, vehiculeFLLast, trainLast);

                    Button modifierVehicule_btn = new Button();

                    modifierVehicule_btn.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                    modifierVehicule_btn.Font = new Font("Arial", 8);
                    modifierVehicule_btn.FlatStyle = FlatStyle.Flat;
                    modifierVehicule_btn.BackColor = Color.Tan;
                    modifierVehicule_btn.ForeColor = Color.Gray;
                    modifierVehicule_btn.Text = "Modifier";

                    Button afficherDetailTrain_btn = new Button();

                    afficherDetailTrain_btn.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                    afficherDetailTrain_btn.Font = new Font("Arial", 8);
                    afficherDetailTrain_btn.FlatStyle = FlatStyle.Flat;
                    afficherDetailTrain_btn.BackColor = Color.Tan;
                    afficherDetailTrain_btn.ForeColor = Color.Gray;
                    afficherDetailTrain_btn.Text = "Détail";
                    afficherDetailTrain_btn.Click += (s,e) => ShowDetailsTrainEvent(trainLast);

                    listButtonPanels.Last().Controls.Add(addVehicule_btn);
                    listButtonPanels.Last().Controls.Add(deleteTrain_btn);
                    listButtonPanels.Last().Controls.Add(modifierVehicule_btn);
                    listButtonPanels.Last().Controls.Add(afficherDetailTrain_btn);

                    this.Controls.Add(listButtonPanels.Last());

                    //Train FlowPanel
                    listVehicule.Last().Location = new Point(INITIAL_LOCATION_X + LOCATION_X_SPACER_TRAIN, INITIAL_LOCATION_Y + ((listeTrain.Count() - 1) * LOCATION_Y_SPACER_NEW_TRAIN));
                    listVehicule.Last().Size = new Size(TRAIN_PANEL_WIDTH, TRAIN_PANEL_HEIGHT);

                    for (int i = 0; i < addTrainForm.trainFerroviaire.Train.Count; i++)
                    {
                        Véhicule vehicule = trainLast.Train[i];
                        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
                        {
                            ColumnCount = 1,
                            RowCount = 2
                        };
                        tableLayoutPanel.Size = new Size(TABLE_PANEL_WIDTH, TABLE_PANEL_HEIGHT);
                        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));  
                        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));

                        PictureBox x_pbox = new PictureBox();
                        x_pbox.Image = Properties.Resources.X_button;
                        x_pbox.Size = new Size(X_IMAGE_WIDTH, X_IMAGE_HEIGHT);
                        x_pbox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        x_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        x_pbox.Cursor = Cursors.Hand;
                        x_pbox.Click += (s,e) => DeleteVehiculeEvent(tableLayoutPanel, trainLast, vehicule);

                        tableLayoutPanel.Controls.Add(x_pbox,0,0);

                        PictureBox vehicule_pbox = new PictureBox();

                        switch (addTrainForm.trainFerroviaire.Train[i].Identifiant)
                        {
                            case "Locomotive":
                                if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Blue)
                                    vehicule_pbox.Image = Properties.Resources.locomotive_bleu;
                                if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Green)
                                    vehicule_pbox.Image = Properties.Resources.locomotive_green;
                                if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Brown)
                                    vehicule_pbox.Image = Properties.Resources.locomotive_brun;
                                break;
                            case "Wagon":
                                Wagon tempWagon = addTrainForm.trainFerroviaire.Train[i] as Wagon;
                                switch (tempWagon.TypeWagon)
                                {
                                    case typeW.grain:
                                        if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Gray)
                                            vehicule_pbox.Image = Properties.Resources.Wagon_Grain_Gris;
                                        if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Brown)
                                            vehicule_pbox.Image = Properties.Resources.wagon_grain_Wood;
                                        break;
                                    case typeW.citerne:
                                        if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Gray)
                                            vehicule_pbox.Image = Properties.Resources.Wagon_Citerne_Gris;
                                        if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Black)
                                            vehicule_pbox.Image = Properties.Resources.wagon_citerne_Black;
                                        break;
                                    case typeW.animaux:
                                        if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Yellow)
                                            vehicule_pbox.Image = Properties.Resources.wagon_animaux_Yellow;
                                        if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Brown)
                                            vehicule_pbox.Image = Properties.Resources.wagon_animaux_Wood;
                                        break;
                                }
                                break;
                            case "Caboose":
                                if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Blue)
                                    vehicule_pbox.Image = Properties.Resources.caboose_blue;
                                if (addTrainForm.trainFerroviaire.Train[i].Couleur == Color.Green)
                                    vehicule_pbox.Image = Properties.Resources.caboose_green;
                                break;
                        }
                        vehicule_pbox.Dock = DockStyle.Fill;
                        vehicule_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        vehicule_pbox.Cursor = Cursors.Hand;
                        vehicule_pbox.Click += (s,e) => ShowDetailsVehiculeEvent(vehicule);

                        tableLayoutPanel.Controls.Add(vehicule_pbox, 0, 1);
                        listVehicule.Last().Controls.Add(tableLayoutPanel);

                        if(i == 0)
                            modifierVehicule_btn.Click += (s, e) => ModifyLocomotiveEvent(vehicule_pbox, listeTrain.IndexOf(trainLast), vehicule as Locomotive);
                    }
                    this.Controls.Add(listVehicule.Last());
                }
            }
        }
    }
}

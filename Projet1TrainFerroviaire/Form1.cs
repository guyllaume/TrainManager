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
        //Initialisation de constante de design
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

        //Initialisation de liste d'objet
        List<TrainFerroviaire> listeTrain = new List<TrainFerroviaire>();
        List<FlowLayoutPanel> listButtonPanels = new List<FlowLayoutPanel>();
        List<FlowLayoutPanel> listVehicule = new List<FlowLayoutPanel>();

        // Constructeur par défaut
        public Form1()
        {
            InitializeComponent();
        }

        // Message a afficher a la lancer du programme
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the train Builder Application !\n" +
                "To Start building a train, click on 'Add Train'");
        }

        //Evenement qui Ajoute un vehicule à l'écran et au train
        private void AddVehiculeEvent(FlowLayoutPanel vehiculePanel, TrainFerroviaire train)
        {
            using (Wagon_Caboose_Locomotive_Choice addVehicule = new Wagon_Caboose_Locomotive_Choice())
            {
                if (addVehicule.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Attache le véhicule au train
                        train.Attacher(addVehicule.véhicule);
                        afficherTrain(new Button(),vehiculePanel, train, addVehicule.véhicule);
                    }
                    catch (Exception ex)
                    {
                        // Affiche un message d'erreur en cas d'exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //Evenement qui Enleve le train dans le view et la liste
        private void DeleteTrainEvent(FlowLayoutPanel buttonPanel, FlowLayoutPanel vehiculePanel, TrainFerroviaire train)
        {
            // Supprimer le panneau de boutons du formulaire et le disposer
            this.Controls.Remove(buttonPanel);
            buttonPanel.Dispose();
            listButtonPanels.Remove(buttonPanel);

            // Supprimer le panneau de véhicules du formulaire et le disposer
            this.Controls.Remove(vehiculePanel);
            vehiculePanel.Dispose();
            listVehicule.Remove(vehiculePanel);

            // Supprimer le train de la liste des trains
            listeTrain.Remove(train);

            // Réorganiser les panneaux de véhicules
            int index = 0;
            foreach (FlowLayoutPanel vehiculeFLP in listVehicule)
            {
                vehiculeFLP.Location = new Point(INITIAL_LOCATION_X + LOCATION_X_SPACER_TRAIN, INITIAL_LOCATION_Y + index * LOCATION_Y_SPACER_NEW_TRAIN);
                index++;
            }

            // Réorganiser les panneaux de boutons
            index = 0;
            foreach (FlowLayoutPanel buttonFLP in listButtonPanels)
            {
                buttonFLP.Location = new Point(INITIAL_LOCATION_X, INITIAL_LOCATION_Y + index * LOCATION_Y_SPACER_NEW_TRAIN);
                index++;
            }
        }

        //Evenement qui Modifie la locomotive du train visuellement et dans la liste
        private void ModifyLocomotiveEvent(PictureBox locomotivePBox, int trainIndex, Locomotive locomotive)
        {
            // Utiliser un formulaire de modification de locomotive
            using (ModificationLocomotive modifyLoco = new ModificationLocomotive(listeTrain[trainIndex]))
            {
                //Si le formulaire a été rempli correctement
                if(modifyLoco.ShowDialog() == DialogResult.OK)
                {
                    // Mettre à jour le train avec les modifications
                    listeTrain[trainIndex] = modifyLoco.train;

                    // Changer l'image de la locomotive en fonction de la couleur
                    if (listeTrain[trainIndex].Train[0].Couleur == Color.Blue)
                        locomotivePBox.Image = Properties.Resources.locomotive_bleu;
                    if (listeTrain[trainIndex].Train[0].Couleur == Color.Green)
                        locomotivePBox.Image = Properties.Resources.locomotive_green;
                    if (listeTrain[trainIndex].Train[0].Couleur == Color.Brown)
                        locomotivePBox.Image = Properties.Resources.locomotive_brun;
                }
            }
        }
        //Événement qui Modifie la locomotive du train visuellement et dans la liste
        private void DeleteVehiculeEvent(TableLayoutPanel vehiculePanel, TrainFerroviaire train, Véhicule véhicule)
        {
            try
            {
                // Détacher le véhicule du train
                if (train.Detacher(véhicule))
                {
                    // Rechercher et supprimer le panneau de véhicule du panneau de véhicules
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
                    // Afficher un message d'erreur si le véhicule n'a pas été détaché
                    MessageBox.Show("Erreur de code, Vehicule toujours attacher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception e)
            {
                // Afficher un message d'erreur en cas d'exception
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Événement qui Affiche les détails du véhicule
        private void ShowDetailsVehiculeEvent(Véhicule véhicule)
        {
            ShowDetails showDetails = new ShowDetails(véhicule);
            showDetails.Show();
        }

        //Événement qui Affiche les détails du train
        private void ShowDetailsTrainEvent(TrainFerroviaire train)
        {
            ShowDetails showDetails = new ShowDetails(train);
            showDetails.Show();
        }

        //Événement qui Ajoute un nouveau train a la liste de train actif
        private void AddTrain_Click(object sender, EventArgs ev)
        {
            // Utiliser un formulaire d'ajout d'un train
            using (AddTrainForm addTrainForm = new AddTrainForm())
            {
                //Si le formulaire a été rempli correctement
                if (addTrainForm.ShowDialog() == DialogResult.OK)
                {
                    // Ajoute le train à la liste des trains
                    listeTrain.Add(addTrainForm.trainFerroviaire);

                    // Ajoute des FlowPanel pour afficher le train et ses options
                    listButtonPanels.Add(new FlowLayoutPanel());
                    listVehicule.Add(new FlowLayoutPanel());

                    //Enregistre des données pour les évènements lambda, enregistrer les informations en mémoire pour qu'elles ne brisent pas a l'appel de l'évènement
                    FlowLayoutPanel vehiculeFLLast = listVehicule.Last();
                    FlowLayoutPanel buttonFLLast = listButtonPanels.Last();
                    TrainFerroviaire trainLast = listeTrain.Last();

                    // Définit l'emplacement et la taille du dernier panneau de boutons
                    listButtonPanels.Last().Location = new Point(INITIAL_LOCATION_X, INITIAL_LOCATION_Y + ((listeTrain.Count()-1) * LOCATION_Y_SPACER_NEW_TRAIN));
                    listButtonPanels.Last().Size = new Size(BUTTON_PANEL_WIDTH, BUTTON_PANEL_HEIGHT);


                    // Crée le bouton pour ajouter un véhicule
                    Button addVehicule_btn = new Button();
                    addVehicule_btn.Size = new Size(BUTTON_WIDTH,BUTTON_HEIGHT);
                    addVehicule_btn.Font = new Font("Arial", 8);
                    addVehicule_btn.FlatStyle = FlatStyle.Flat;
                    addVehicule_btn.BackColor = Color.Tan;
                    addVehicule_btn.ForeColor = Color.Gray;
                    addVehicule_btn.Text = "Ajouter";

                    // Associe l'événement Click du bouton à la méthode AddVehiculeEvent
                    addVehicule_btn.Click += (s,e) => AddVehiculeEvent(vehiculeFLLast, trainLast);


                    // Crée le bouton pour supprimer un train
                    Button deleteTrain_btn = new Button();
                    deleteTrain_btn.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                    deleteTrain_btn.Font = new Font("Arial", 8);
                    deleteTrain_btn.FlatStyle = FlatStyle.Flat;
                    deleteTrain_btn.BackColor = Color.Tan;
                    deleteTrain_btn.ForeColor = Color.Gray;
                    deleteTrain_btn.Text = "Supprimer";

                    // Associe l'événement Click du bouton à la méthode DeleteTrainEvent
                    deleteTrain_btn.Click += (s,e) => DeleteTrainEvent(buttonFLLast, vehiculeFLLast, trainLast);


                    // Crée le bouton pour modifier un véhicule
                    Button modifierVehicule_btn = new Button();
                    modifierVehicule_btn.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                    modifierVehicule_btn.Font = new Font("Arial", 8);
                    modifierVehicule_btn.FlatStyle = FlatStyle.Flat;
                    modifierVehicule_btn.BackColor = Color.Tan;
                    modifierVehicule_btn.ForeColor = Color.Gray;
                    modifierVehicule_btn.Text = "Modifier";


                    // Crée le bouton pour afficher les détails d'un train
                    Button afficherDetailTrain_btn = new Button();
                    afficherDetailTrain_btn.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                    afficherDetailTrain_btn.Font = new Font("Arial", 8);
                    afficherDetailTrain_btn.FlatStyle = FlatStyle.Flat;
                    afficherDetailTrain_btn.BackColor = Color.Tan;
                    afficherDetailTrain_btn.ForeColor = Color.Gray;
                    afficherDetailTrain_btn.Text = "Détail";

                    // Associe l'événement Click du bouton à la méthode ShowDetailsTrainEvent
                    afficherDetailTrain_btn.Click += (s,e) => ShowDetailsTrainEvent(trainLast);

                    // Ajoute les boutons au panneau de boutons du nouveau train
                    listButtonPanels.Last().Controls.Add(addVehicule_btn);
                    listButtonPanels.Last().Controls.Add(deleteTrain_btn);
                    listButtonPanels.Last().Controls.Add(modifierVehicule_btn);
                    listButtonPanels.Last().Controls.Add(afficherDetailTrain_btn);

                    // Ajoute le panneau de boutons à la fenêtre principale
                    this.Controls.Add(listButtonPanels.Last());

                    // Définit l'emplacement et la taille du panneau de véhicules du nouveau train
                    listVehicule.Last().Location = new Point(INITIAL_LOCATION_X + LOCATION_X_SPACER_TRAIN, INITIAL_LOCATION_Y + ((listeTrain.Count() - 1) * LOCATION_Y_SPACER_NEW_TRAIN));
                    listVehicule.Last().Size = new Size(TRAIN_PANEL_WIDTH, TRAIN_PANEL_HEIGHT);

                    // Ajoute les véhicules du train au panneau de véhicules
                    for (int i = 0; i < addTrainForm.trainFerroviaire.Train.Count; i++)
                    {
                        afficherTrain(modifierVehicule_btn, listVehicule.Last(), trainLast, trainLast.Train[i]);
                    }
                    // Ajoute le panneau de véhicules à la fenêtre principale
                    this.Controls.Add(listVehicule.Last());
                }
            }
        }

        //Méthode privée qui affiche la liste de véhicule d'un train donné
        private void afficherTrain(Button modifyButton, FlowLayoutPanel vehiculePanel,TrainFerroviaire train, Véhicule véhicule)
        {
            // Crée un TableLayoutPanel avec 1 colonne et 2 lignes
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2
            };
            tableLayoutPanel.Size = new Size(TABLE_PANEL_WIDTH, TABLE_PANEL_HEIGHT);
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));

            // Crée un PictureBox pour le bouton de suppression
            PictureBox x_pbox = new PictureBox();
            x_pbox.Image = Properties.Resources.X_button;
            x_pbox.Size = new Size(X_IMAGE_WIDTH, X_IMAGE_HEIGHT);
            x_pbox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            x_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
            x_pbox.Cursor = Cursors.Hand;
            x_pbox.Click += (s, e) => DeleteVehiculeEvent(tableLayoutPanel, train, véhicule);

            // Ajoute le PictureBox du bouton de suppression au TableLayoutPanel
            tableLayoutPanel.Controls.Add(x_pbox, 0, 0);

            // Crée un PictureBox pour afficher le véhicule
            PictureBox vehicule_pbox = new PictureBox();

            // Associe l'image appropriée au PictureBox en fonction du type de véhicule et de sa couleur
            switch (véhicule.Identifiant)
            {
                case "Locomotive":
                    if (véhicule.Couleur == Color.Blue)
                        vehicule_pbox.Image = Properties.Resources.locomotive_bleu;
                    if (véhicule.Couleur == Color.Green)
                        vehicule_pbox.Image = Properties.Resources.locomotive_green;
                    if (véhicule.Couleur == Color.Brown)
                        vehicule_pbox.Image = Properties.Resources.locomotive_brun;
                    break;
                case "Wagon":
                    Wagon tempWagon = véhicule as Wagon;
                    switch (tempWagon.TypeWagon)
                    {
                        case typeW.grain:
                            if (véhicule.Couleur == Color.Gray)
                                vehicule_pbox.Image = Properties.Resources.Wagon_Grain_Gris;
                            if (véhicule.Couleur == Color.Brown)
                                vehicule_pbox.Image = Properties.Resources.wagon_grain_Wood;
                            break;
                        case typeW.citerne:
                            if (véhicule.Couleur == Color.Gray)
                                vehicule_pbox.Image = Properties.Resources.Wagon_Citerne_Gris;
                            if (véhicule.Couleur == Color.Black)
                                vehicule_pbox.Image = Properties.Resources.wagon_citerne_Black;
                            break;
                        case typeW.animaux:
                            if (véhicule.Couleur == Color.Yellow)
                                vehicule_pbox.Image = Properties.Resources.wagon_animaux_Yellow;
                            if (véhicule.Couleur == Color.Brown)
                                vehicule_pbox.Image = Properties.Resources.wagon_animaux_Wood;
                            break;
                    }
                    break;
                case "Caboose":
                    if (véhicule.Couleur == Color.Blue)
                        vehicule_pbox.Image = Properties.Resources.caboose_blue;
                    if (véhicule.Couleur == Color.Green)
                        vehicule_pbox.Image = Properties.Resources.caboose_green;
                    break;
            }
            // Configure le PictureBox du véhicule
            vehicule_pbox.Dock = DockStyle.Fill;
            vehicule_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
            vehicule_pbox.Cursor = Cursors.Hand;
            vehicule_pbox.Click += (s, e) => ShowDetailsVehiculeEvent(véhicule);

            // Ajoute le PictureBox du véhicule au TableLayoutPanel
            tableLayoutPanel.Controls.Add(vehicule_pbox, 0, 1);

            // Ajoute le TableLayoutPanel au panel principal du formulaire
            vehiculePanel.Controls.Add(tableLayoutPanel);
            
            //Si le vehicule est une locomotive, Ajoute un modifyEvent 
            if (véhicule.Identifiant == "Locomotive")
                modifyButton.Click += (s, e) => ModifyLocomotiveEvent(vehicule_pbox, listeTrain.IndexOf(train), véhicule as Locomotive);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projet1TrainFerroviaire
{
    public class TrainFerroviaire : IAttacher
    {
        List<Véhicule> train = new List<Véhicule>(); //la liste des véhicules du Train
        double capacitéTotale; // = capacite totale de tirage : voir règle de la méthode attacher
        double tarifTotal; //somme des tarif* masse des wagons
        double vitesse; // vitesse totale voir règle pour méthode attacher
        string nom; // le nom du train

        // Constructeur avec des paramètres sans véhicules
        public TrainFerroviaire(String nom, Locomotive locomotive)
        {
            this.nom = nom;
            train.Add(locomotive);
            vitesse = locomotive.Vitesse;
            capacitéTotale = locomotive.CapacitéDeTirageTotale;
        }

        // Constructeur avec des paramètres avec véhicules
        public TrainFerroviaire(String nom, Locomotive locomotive, List<Véhicule> véhicules)
        {
            // Variables temporaires pour le calcul
            double capacitéTotale = 0;
            double masseCoefficient = 0;
            double masse = 0;
            double tarif = 0;

            // Initialisation des attributs du train
            this.nom = nom;
            train.Add(locomotive); // Ajout de la locomotive à la liste des véhicules du train
            vitesse = locomotive.Vitesse;
            this.capacitéTotale = locomotive.CapacitéDeTirageTotale;

            // Parcours de la liste des véhicules pour effectuer les calculs
            foreach (Véhicule véhicule in véhicules)
            {
                capacitéTotale += véhicule.CapacitéDeTirageTotale;
                masseCoefficient += véhicule.Masse * véhicule.CoefficientFriction;
                masse += véhicule.Masse;

                // Si le véhicule est un wagon, ajouter le tarif du wagon
                if (véhicule is Wagon)
                {
                    Wagon tempWagon = (Wagon)véhicule;
                    tarif += tempWagon.Tarif * tempWagon.Masse;
                }
            }

            // Vérification de la vitesse minimale
            if (!(vitesse - masseCoefficient >= 5))
            {
                throw new VitesseException("vitesse minimale");
            }

            // Vérification de la capacité maximale
            if (capacitéTotale + this.capacitéTotale - masse > 0)
            {
                // Mise à jour des attributs du train
                this.capacitéTotale += capacitéTotale;
                this.capacitéTotale -= masse;
                Vitesse -= masseCoefficient;
                Train.AddRange(véhicules); // Ajout des véhicules à la liste des véhicules du train
                TarifTotal += tarif;
            }
            else
            {
                throw new CapaciteException("Capacite limite atteinte");
            }

        }

        // Accesseurs et Mutateurs
        public List<Véhicule> Train { get => train; set => train = value; }
        public double CapacitéTotale { get => capacitéTotale; set => capacitéTotale = value; }
        public double TarifTotal { get => tarifTotal; set => tarifTotal = value; }
        public double Vitesse { get => vitesse; set => vitesse = value; }
        public string Nom { get => nom; set => nom = value; }

        //Ajouter un véhicule au train
        public bool Attacher(Véhicule vehicule)
        {
            switch (vehicule.Identifiant)
            {
                case "Caboose":
                    // Vérifie si la vitesse reste suffisante après l'attachement du véhicule
                    if (vitesse - vehicule.Masse * vehicule.CoefficientFriction <= 5)
                        throw new VitesseException("Vitesse trop petite");
                    else
                        vitesse -= vehicule.Masse * vehicule.CoefficientFriction;

                    // Met à jour la capacité totale et ajoute le véhicule au train
                    capacitéTotale += vehicule.CapacitéDeTirageTotale - vehicule.Masse;
                    train.Add(vehicule);
                    return true;
                case "Wagon":
                    Wagon tempWagon = (Wagon)vehicule;

                    // Vérifie si la vitesse reste suffisante après l'attachement du véhicule
                    if (vitesse - vehicule.Masse * vehicule.CoefficientFriction <= 5)
                        throw new VitesseException("Vitesse trop petite");
                    else
                        if (tempWagon.TypeWagon == typeW.citerne)

                        // Vérifie si le nombre de wagons citerne ne dépasse pas la limite pour éviter une explosion
                        if (NombreWagonCiterne() >= 5)
                            throw new ExplosionException("Danger Explosion");
                    vitesse -= vehicule.Masse * vehicule.CoefficientFriction;

                    // Vérifie si la capacité totale ne dépasse pas la limite
                    if (capacitéTotale + vehicule.CapacitéDeTirageTotale - vehicule.Masse <= 0)
                        throw new CapaciteException("Capacite limite atteinte");
                    else
                        capacitéTotale += vehicule.CapacitéDeTirageTotale - vehicule.Masse;

                    // Ajoute le véhicule au train
                    train.Add(vehicule);
                    return true;
                case "Locomotive":

                    // Vérifie s'il y a déjà une locomotive dans le train
                    if (NombreLocomotive() == 1)
                        throw new TrainException("le train contient déjà une locomotive");

                    nom = vehicule.Nom;
                    Train.Add(vehicule);
                    vitesse = vehicule.Vitesse;
                    capacitéTotale = vehicule.CapacitéDeTirageTotale;
                    return true;
                default:
                    return false;
            }
        }
        public bool Detacher(Véhicule vehicule)
        {
            switch (vehicule.Identifiant)
            {
                case "Caboose":
                    // Retire le véhicule du train et met à jour la vitesse et la capacité totale
                    if (train.Remove(vehicule))
                    {
                        vitesse += vehicule.Masse * vehicule.CoefficientFriction;
                        capacitéTotale = capacitéTotale - vehicule.CapacitéDeTirageTotale + vehicule.Masse;
                        return true;
                    }
                    return false;
                case "Wagon":
                    // Retire le véhicule du train et met à jour la vitesse, la capacité totale et le tarif
                    if (train.Remove(vehicule))
                    {
                        Wagon tempWagon = (Wagon)vehicule;
                        vitesse += vehicule.Masse * vehicule.CoefficientFriction;
                        capacitéTotale += vehicule.Masse;
                        tarifTotal -= tempWagon.Tarif * vehicule.CoefficientFriction;
                        return true;
                    }
                    return false;
                case "Locomotive":
                    //Lance une exception si l'on essaie de détacher une locomotive
                    throw new TrainException("le train doit contenir une locomotive");
                default:
                    return false;
            }
        }
        public bool Modifier(string nom, typeLocomotive typeLocomotive, Color couleur)
        {
            // Vérifie si le train contient exactement une locomotive
            if (NombreLocomotive() == 1)
            {
                // Récupère la locomotive existante
                Locomotive tempLoco = (Locomotive)train[0];

                // Vérifie le type de locomotive actuel et effectue les modifications nécessaires
                switch (tempLoco.TypeLocomotive)
                {
                    case typeLocomotive.longVoyage:
                        switch (typeLocomotive)
                        {
                            case typeLocomotive.moyenVoyage:
                                tempLoco.CoefficientFriction += 0.001;
                                tempLoco.CapacitéDeTirageTotale += 25000;
                                tempLoco.Masse += 500;
                                tempLoco.Vitesse += 5;
                                vitesse += 5;
                                capacitéTotale += 25000;
                                break;
                            case typeLocomotive.courtVoyage:
                                tempLoco.CoefficientFriction += 0.002;
                                tempLoco.CapacitéDeTirageTotale += 50000;
                                tempLoco.Masse += 1000;
                                tempLoco.Vitesse += 15;
                                vitesse += 15;
                                capacitéTotale += 50000;
                                break;
                        }
                        break;
                    case typeLocomotive.moyenVoyage:
                        switch (typeLocomotive)
                        {
                            case typeLocomotive.longVoyage:
                                // Vérifie si la nouvelle vitesse ou capacité est suffisante
                                if (vitesse - 5 <= 5)
                                    throw new VitesseException("La nouvelle locomotive est trop lente");
                                if (capacitéTotale - 25000 < 0)
                                    throw new VitesseException("La nouvelle locomotive est n'a pas asser de capacité");
                                tempLoco.CoefficientFriction -= 0.001;
                                tempLoco.CapacitéDeTirageTotale -= 25000;
                                tempLoco.Masse -= 500;
                                tempLoco.Vitesse -= 5;
                                vitesse -= 5;
                                capacitéTotale -= 25000;
                                break;
                            case typeLocomotive.courtVoyage:
                                tempLoco.CoefficientFriction += 0.001;
                                tempLoco.CapacitéDeTirageTotale += 25000;
                                tempLoco.Masse += 500;
                                tempLoco.Vitesse += 10;
                                vitesse += 10;
                                capacitéTotale += 25000;
                                break;
                        }
                        break;
                    case typeLocomotive.courtVoyage:
                        switch (typeLocomotive)
                        {
                            case typeLocomotive.longVoyage:
                                // Vérifie si la nouvelle vitesse ou capacité est suffisante
                                if (vitesse - 15 <= 5)
                                    throw new VitesseException("La nouvelle locomotive est trop lente");
                                if (capacitéTotale - 50000 < 0)
                                    throw new VitesseException("La nouvelle locomotive est n'a pas asser de capacité");
                                tempLoco.CoefficientFriction -= 0.002;
                                tempLoco.CapacitéDeTirageTotale -= 50000;
                                tempLoco.Masse -= 1000;
                                tempLoco.Vitesse -= 15;
                                vitesse -= 15;
                                capacitéTotale -= 50000;
                                break;
                            case typeLocomotive.moyenVoyage:
                                // Vérifie si la nouvelle vitesse ou capacité est suffisante
                                if (vitesse - 10 <= 5)
                                    throw new VitesseException("La nouvelle locomotive est trop lente");
                                if (capacitéTotale - 25000 < 0)
                                    throw new VitesseException("La nouvelle locomotive est n'a pas asser de capacité");
                                tempLoco.CoefficientFriction -= 0.001;
                                tempLoco.CapacitéDeTirageTotale -= 25000;
                                tempLoco.Masse -= 500;
                                tempLoco.Vitesse -= 10;
                                vitesse -= 10;
                                capacitéTotale -= 25000;
                                break;
                        }
                        break;
                }

                // Met à jour les propriétés de la locomotive
                tempLoco.Nom = nom;
                tempLoco.TypeLocomotive = typeLocomotive;
                tempLoco.Couleur = couleur;
                train[0] = tempLoco;
                return true;
            }
            else
            {
                // Lance une exception si le train ne contient pas de locomotive
                throw new TrainException("le train ne contient pas de locomotive");
            }
        }

        //Retourne le nombre de wagon citerne
        public int NombreWagonCiterne()
        {
            int nombreWagonCiterne = 0;

            foreach (Véhicule véhicule in train)
            {
                if(véhicule is Wagon)
                {
                    Wagon tempWagon = (Wagon)véhicule;
                    if (tempWagon.TypeWagon == typeW.citerne)
                        nombreWagonCiterne++;
                }
            }
            return nombreWagonCiterne;
        }

        //Retourne le nombre de locomotive
        public int NombreLocomotive()
        {
            int nombreLocomotive = 0;

            foreach (Véhicule véhicule in train)
            {
                if (véhicule is Locomotive)
                    nombreLocomotive++;
            }
            return nombreLocomotive;
        }

        //Retourne le nombre de wagon
        public int NombreWagon()
        {
            int nombreWagon = 0;

            foreach (Véhicule véhicule in train)
            {
                if (véhicule is Wagon)
                    nombreWagon++;
            }
            return nombreWagon;
        }

        //Retourne le nombre de Caboose
        public int NombreCaboose()
        {
            int nombreCaboose = 0;

            foreach (Véhicule véhicule in train)
            {
                if (véhicule is Caboose)
                    nombreCaboose++;
            }
            return nombreCaboose;
        }

        // Redéfinition de la méthode ToString avec tous les vehicules
        public override string ToString()
        {
            string trainString = $"Nom: {Nom},\n" +
                   $"Capacité: {CapacitéTotale},\n Vitesse: {Vitesse},\n Tarif Total: {TarifTotal}$,\n " +
                   $"Nombre de Wagon: {NombreWagon()},\n Nombre de Caboose: {NombreCaboose()},\n Nombre de Locomotive: {NombreLocomotive()},\n " +
                   $"Train:\n";
            int compteur = 0;
            foreach (Véhicule véhicule in train)
            {
                compteur++;
                trainString += $"----Train#{compteur}----\n{véhicule}";
            }
            return trainString;
        }
    }
}

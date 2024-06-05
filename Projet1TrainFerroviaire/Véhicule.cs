using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1TrainFerroviaire
{
    public class Véhicule
    {
        // Déclaration des variables privés
        private string nom;
        private string identifiant;
        private Color couleur;
        private double coefficientFriction;
        private double vitesse;
        private int nombreRoues;
        private int nombrePlaces;
        private double masse;
        private double capacitéDeTirageTotale;

        // Accesseurs et Mutateurs avec validations
        public string Nom { get => nom; set => nom = (value.Length < 5 || value.Length > 50) ? throw new ChaineException("nom", 5, 50) : value; }
        public string Identifiant { get => identifiant; set => identifiant = (value.Length < 5 || value.Length > 50) ? throw new ChaineException("identifiant", 5, 50) : value; }
        public Color Couleur { get => couleur; set => couleur = value; }
        public double CoefficientFriction { get => coefficientFriction; set => coefficientFriction = value; }
        public double Vitesse { get => vitesse; set => vitesse = value; }
        public int NombreRoues { get => nombreRoues; set => nombreRoues = (value < 4 || value > 16) ? throw new EntierException("nombreRoues", 4, 16) : value; }
        public int NombrePlaces { get => nombrePlaces; set => nombrePlaces = (value < 0 || value > 100) ? throw new EntierException("nombrePlaces", 0, 100) : value; }
        public double Masse { get => masse; set => masse = value < 0 ? throw new Exception("masse doit être positif") : value; }
        public double CapacitéDeTirageTotale { get => capacitéDeTirageTotale; set => capacitéDeTirageTotale = value < 0 ? throw new Exception("capacitéDeTirageTotale doit être positif") : value; }

        // Constructeur par défaut
        public Véhicule()
        {
            nom = "xxxxx";
            identifiant = "xxxxx";
            couleur = Color.Black;
            coefficientFriction = 0;
            vitesse = 0;
            nombreRoues = 4;
            nombrePlaces = 0;
            masse = 1;
            capacitéDeTirageTotale = 1;
        }

        // Constructeur avec certains paramètres
        public Véhicule(string nom, Color couleur, double vitesse)
        {
            this.nom = (nom.Length < 5 || nom.Length > 50) ? throw new ChaineException("nom", 5, 50) : nom;
            this.couleur = couleur;
            this.vitesse = vitesse;
        }

        // Constructeur avec nom et couleur
        public Véhicule(string nom, Color couleur)
        {
            this.nom = (nom.Length < 5 || nom.Length > 50) ? throw new ChaineException("nom", 5, 50) : nom;
            this.couleur = couleur;
        }

        // Constructeur complet
        public Véhicule(string nom, string identifiant, Color couleur, double coefficientFriction, double vitesse, int nombreRoues, int nombrePlaces, double masse, double capacitéDeTirageTotale)
        {
            this.nom = (nom.Length < 5 || nom.Length > 50) ? throw new ChaineException("nom", 5, 50): nom;
            this.identifiant = (identifiant.Length < 5 || identifiant.Length > 50) ? throw new ChaineException("identifiant", 5, 50) : identifiant;
            this.couleur = couleur;
            this.coefficientFriction = coefficientFriction;
            this.vitesse = vitesse;
            this.nombreRoues = (nombreRoues < 4 || nombreRoues > 16) ? throw new EntierException("nombres de roues", 4, 16) : nombreRoues;
            this.nombrePlaces = (nombrePlaces < 0 || nombrePlaces > 100) ? throw new EntierException("nombres de places", 0, 100) : nombrePlaces;
            this.masse = masse < 0 ? throw new Exception("masse doit être positif") : masse;
            this.capacitéDeTirageTotale = capacitéDeTirageTotale < 0 ? throw new Exception("capacitéDeTirageTotale doit être positif") : capacitéDeTirageTotale;
        }

        // Constructeur de copie
        public Véhicule(Véhicule vehiculeAutre)
        {
            nom = vehiculeAutre.nom;
            identifiant = vehiculeAutre.identifiant;
            couleur = vehiculeAutre.couleur;
            coefficientFriction = vehiculeAutre.coefficientFriction;
            vitesse = vehiculeAutre.vitesse;
            nombreRoues = vehiculeAutre.nombreRoues;
            nombrePlaces = vehiculeAutre.nombrePlaces;
            masse = vehiculeAutre.masse;
            capacitéDeTirageTotale = vehiculeAutre.capacitéDeTirageTotale;
        }

        // Redéfinition de la méthode Equals
        public override bool Equals(object obj)
        {
            return obj is Véhicule véhicule &&
                   nom == véhicule.nom &&
                   identifiant == véhicule.identifiant &&
                   EqualityComparer<Color>.Default.Equals(couleur, véhicule.couleur) &&
                   coefficientFriction == véhicule.coefficientFriction &&
                   nombreRoues == véhicule.nombreRoues &&
                   nombrePlaces == véhicule.nombrePlaces &&
                   masse == véhicule.masse &&
                   capacitéDeTirageTotale == véhicule.capacitéDeTirageTotale;
        }

        // Redéfinition de la méthode ToString
        public override string ToString()
        {
            return $"Nom: {Nom},\n Identifiant: {Identifiant},\n " +
                   $"Couleur: {Couleur},\n Coefficient de Friction: {CoefficientFriction},\n Vitesse: {Vitesse},\n " +
                   $"Nombre de Roues: {NombreRoues},\n Nombre de Places: {NombrePlaces},\n Masse: {Masse},\n " +
                   $"Capacité de Tirage Totale: {CapacitéDeTirageTotale}\n";
        }

        // Redéfinition de la méthode GetHashCode
        public override int GetHashCode()
        {
            int hashCode = -1364278304;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(identifiant);
            hashCode = hashCode * -1521134295 + couleur.GetHashCode();
            hashCode = hashCode * -1521134295 + coefficientFriction.GetHashCode();
            hashCode = hashCode * -1521134295 + vitesse.GetHashCode();
            hashCode = hashCode * -1521134295 + nombreRoues.GetHashCode();
            hashCode = hashCode * -1521134295 + nombrePlaces.GetHashCode();
            hashCode = hashCode * -1521134295 + masse.GetHashCode();
            hashCode = hashCode * -1521134295 + capacitéDeTirageTotale.GetHashCode();
            return hashCode;
        }
    }
}

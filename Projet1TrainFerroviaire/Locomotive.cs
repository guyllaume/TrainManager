using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1TrainFerroviaire
{
    // Enumération pour le type de Locomotive
    public enum typeLocomotive
    {
        longVoyage,
        moyenVoyage,
        courtVoyage
    }

    public class Locomotive : Véhicule
    {
        private typeLocomotive typeLocomotive; // Type de caboose (restaurant ou passager)

        // Constructeur par défaut
        public Locomotive() : base()
        {
            typeLocomotive = typeLocomotive.courtVoyage;
        }

        // Constructeur avec des paramètres
        public Locomotive(typeLocomotive typeLocomotive, string nom, Color couleur) : base(nom, couleur)
        {
            TypeLocomotive = typeLocomotive;
            Identifiant = "Locomotive";
            NombreRoues = 8;
            NombrePlaces = 2;
            switch (typeLocomotive)
            {
                case typeLocomotive.longVoyage:
                    CoefficientFriction = 0.001;
                    CapacitéDeTirageTotale = 50000;
                    Masse = 1000;
                    Vitesse = 35;
                    break;
                case typeLocomotive.moyenVoyage:
                    CoefficientFriction = 0.002;
                    CapacitéDeTirageTotale = 75000;
                    Masse = 1500;
                    Vitesse = 40;
                    break;
                case typeLocomotive.courtVoyage:
                    CoefficientFriction = 0.003;
                    CapacitéDeTirageTotale = 100000;
                    Masse = 2000;
                    Vitesse = 50;
                    break;
            }
        }

        // Constructeur avec tous les paramètres
        public Locomotive(typeLocomotive typeLocomotive, string nom, string identifiant, Color couleur, double coefficientFriction, double vitesse, int nombreRoues, int nombrePlaces, double masse, double capacitéDeTirageTotale) : base(nom, identifiant, couleur, coefficientFriction, vitesse, nombreRoues, nombrePlaces, masse, capacitéDeTirageTotale)
        {
            this.typeLocomotive = typeLocomotive;
        }

        // Constructeur de copie
        public Locomotive(Locomotive locomotive) : base(locomotive.Nom, locomotive.Identifiant, locomotive.Couleur, locomotive.CoefficientFriction, locomotive.Vitesse, locomotive.NombreRoues, locomotive.NombrePlaces, locomotive.Masse, locomotive.CapacitéDeTirageTotale)
        {
            typeLocomotive = locomotive.TypeLocomotive;
        }

        // Accesseurs et Mutateurs
        public typeLocomotive TypeLocomotive { get => typeLocomotive; set => typeLocomotive = value; }

        // Redéfinition de la méthode ToString
        public override string ToString()
        {
            return base.ToString() + $"TypeLocomotive: {typeLocomotive}\n";
        }

        // Redéfinition de la méthode Equals
        public override bool Equals(object obj)
        {
            return obj is Locomotive locomotive &&
                   base.Equals(obj) &&
                   typeLocomotive == locomotive.typeLocomotive;
        }

        // Redéfinition de la méthode GetHashCode
        public override int GetHashCode()
        {
            int hashCode = 661677526;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + typeLocomotive.GetHashCode();
            return hashCode;
        }
    }
}

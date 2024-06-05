using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1TrainFerroviaire
{
    // Enumération pour le type de caboose
    public enum typeCab
    {
        restaurant,
        passager,
    }

    // Classe Caboose qui hérite de la classe Véhicule
    public class Caboose : Véhicule
    {
        private typeCab typeCaboose; // Type de caboose (restaurant ou passager)
        private int nombreLits; // Nombre de lits dans le caboose

        // Accesseurs et Mutateurs 
        public typeCab TypeCaboose { get => typeCaboose; set => typeCaboose = value; }
        public int NombreLits { get => nombreLits; set => nombreLits = value; }

        // Constructeur par défaut
        public Caboose() : base()
        {
            typeCaboose = typeCab.passager;
        }

        // Constructeur avec des paramètres
        public Caboose(typeCab typeCaboose, string nom, Color couleur) : base(nom, couleur)
        {
            Identifiant = "Caboose";
            NombreRoues = 8;
            Vitesse = 0;
            CapacitéDeTirageTotale = 5000;
            switch (typeCaboose)
            {
                case typeCab.restaurant:
                    CoefficientFriction = 0.0003;
                    TypeCaboose = typeCab.restaurant;
                    NombrePlaces = 20;
                    Masse = 800;
                    NombreLits = 5;
                    break;
                case typeCab.passager:
                    TypeCaboose = typeCab.passager;
                    CoefficientFriction = 0.0004;
                    NombrePlaces = 10;
                    Masse = 700;
                    NombreLits = 10;
                    break;
            }
        }

        // Constructeur avec tous les paramètres
        public Caboose(typeCab typeCaboose, int nombreLits, string nom, string identifiant, Color couleur, double coefficientFriction, double vitesse, int nombreRoues, int nombrePlaces, double masse, double capacitéDeTirageTotale) : base(nom, identifiant, couleur, coefficientFriction, vitesse, nombreRoues, nombrePlaces, masse, capacitéDeTirageTotale)
        {
            this.typeCaboose = typeCaboose;
            this.nombreLits = nombreLits;
        }

        // Constructeur de copie
        public Caboose(Caboose caboose) : base(caboose.Nom, caboose.Identifiant, caboose.Couleur, caboose.CoefficientFriction, caboose.Vitesse, caboose.NombreRoues, caboose.NombrePlaces, caboose.Masse, caboose.CapacitéDeTirageTotale)
        {
            typeCaboose = caboose.TypeCaboose;
            nombreLits = caboose.NombreLits;
        }

        // Redéfinition de la méthode ToString
        public override string ToString()
        {
            return base.ToString() + $"TypeCaboose: {typeCaboose},\n Nombre de Lits: {nombreLits}\n";
        }

        // Redéfinition de la méthode Equals
        public override bool Equals(object obj)
        {
            return obj is Caboose caboose &&
                   base.Equals(obj) &&
                   typeCaboose == caboose.typeCaboose &&
                   nombreLits == caboose.nombreLits;
        }

        // Redéfinition de la méthode GetHashCode
        public override int GetHashCode()
        {
            int hashCode = 107071607;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + typeCaboose.GetHashCode();
            hashCode = hashCode * -1521134295 + nombreLits.GetHashCode();
            return hashCode;
        }
    }
}

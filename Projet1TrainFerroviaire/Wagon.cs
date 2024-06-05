using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1TrainFerroviaire
{
    // Enumération pour le type de wagon
    public enum typeW
    {
        grain,
        animaux,
        citerne
    }

    public class Wagon : Véhicule
    {
        private typeW typeWagon; // Type de Wagon (grain,animaux,citerne)
        private double tarif; // Tarif du wagon

        // Accesseurs et Mutateurs
        public typeW TypeWagon { get => typeWagon; set => typeWagon = value; }
        public double Tarif { get => tarif; set => tarif = value; }

        // Constructeur par défaut
        public Wagon() : base()
        {
            typeWagon = typeW.animaux;
            tarif = 0;
        }
        // Constructeur avec des paramètres
        public Wagon(typeW typeWagon, string nom, Color couleur) : base(nom, couleur)
        {
            switch (typeWagon)
            {
                case typeW.grain:
                    CoefficientFriction = 0.0005;
                    Masse = 500;
                    Tarif = 3.5;
                    break;
                case typeW.animaux:
                    CoefficientFriction = 0.0006;
                    Masse = 600;
                    Tarif = 4.5;
                    break;
                case typeW.citerne:
                    CoefficientFriction = 0.0007;
                    Masse = 400;
                    Tarif = 5.5;
                    break;
            }
            Identifiant = "Wagon";
            NombreRoues = 4;
            NombrePlaces = 0;
            CapacitéDeTirageTotale = 0;
            Vitesse = 0; // Ajout de la vitesse a 0 puisque un wagon ne permet pas d'accelerer
            TypeWagon = typeWagon;
        }

        // Constructeur avec tous les paramètres
        public Wagon(typeW typeWagon, double tarif, string nom, string identifiant, Color couleur, double coefficientFriction, double vitesse, int nombreRoues, int nombrePlaces, double masse, double capacitéDeTirageTotale) : base(nom, identifiant, couleur, coefficientFriction, vitesse, nombreRoues, nombrePlaces, masse, capacitéDeTirageTotale)
        {
            this.typeWagon = typeWagon;
            this.tarif = tarif;
        }

        // Constructeur de copie
        public Wagon(Wagon wagon) : base(wagon.Nom, wagon.Identifiant, wagon.Couleur, wagon.CoefficientFriction, wagon.Vitesse, wagon.NombreRoues, wagon.NombrePlaces, wagon.Masse, wagon.CapacitéDeTirageTotale)
        {
            typeWagon = wagon.TypeWagon;
            tarif = wagon.Tarif;
        }

        // Redéfinition de la méthode ToString
        public override string ToString() 
        {
            return base.ToString() + $"TypeWagon: {typeWagon},\n Tarif: {tarif}\n";
        }

        // Redéfinition de la méthode Equals
        public override bool Equals(object obj)
        {
            return obj is Wagon wagon &&
                   base.Equals(obj) &&
                   typeWagon == wagon.typeWagon &&
                   tarif == wagon.tarif;
        }

        // Redéfinition de la méthode GetHashCode
        public override int GetHashCode()
        {
            int hashCode = -1023408048;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + typeWagon.GetHashCode();
            hashCode = hashCode * -1521134295 + tarif.GetHashCode();
            return hashCode;
        }
    }
}

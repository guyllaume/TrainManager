using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projet1TrainFerroviaire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1TrainFerroviaire.Tests
{
    [TestClass()]
    public class TrainFerroviaireTests
    {
        //Véhicule
        [TestMethod]
        public void Véhicule_DefaultConstructor_ShouldSetDefaultValues()
        {
            Véhicule vehicle = new Véhicule();
            Assert.AreEqual("xxxxx", vehicle.Nom);
            Assert.AreEqual("xxxxx", vehicle.Identifiant);
            Assert.AreEqual(Color.Black, vehicle.Couleur);
            Assert.AreEqual(0, vehicle.CoefficientFriction);
            Assert.AreEqual(0, vehicle.Vitesse);
            Assert.AreEqual(4, vehicle.NombreRoues);
            Assert.AreEqual(0, vehicle.NombrePlaces);
            Assert.AreEqual(1, vehicle.Masse);
            Assert.AreEqual(1, vehicle.CapacitéDeTirageTotale);
        }

        [TestMethod]
        [DataRow("abcdef")]
        public void Véhicule_PublicConstructorNomCouleur_ShouldSetValues(string nom)
        {
            Véhicule vehicle = new Véhicule(nom, Color.Red);
            Assert.AreEqual(nom, vehicle.Nom);
            Assert.AreEqual(Color.Red, vehicle.Couleur);
        }

        [TestMethod]
        [ExpectedException(typeof(ChaineException))]
        [DataRow("abcd")] // Below minimum length 4
        public void Véhicule_PublicConstructorNomCouleur_InvalidNomLower_ThrowsException(string nom)
        {
            Véhicule vehicle = new Véhicule(nom, Color.Red);
        }
        [TestMethod]
        [ExpectedException(typeof(ChaineException))]
        [DataRow("abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijz")] // above max length 51
        public void Véhicule_PublicConstructorNomCouleur_InvalidNomHigher_ThrowsException(string nom)
        {
            Véhicule vehicle = new Véhicule(nom, Color.Red);
        }
        [TestMethod]
        public void Nom_ValidValue_ShouldSet()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            string validName = "TrainX";

            // Act
            vehicule.Nom = validName;

            // Assert
            Assert.AreEqual(validName, vehicule.Nom);
        }

        [TestMethod]
        [ExpectedException(typeof(ChaineException))]
        public void Nom_TooShort_ThrowsChaineException()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            string shortName = "ABC";

            // Act
            vehicule.Nom = shortName;
        }

        [TestMethod]
        [ExpectedException(typeof(ChaineException))]
        public void Nom_TooLong_ThrowsChaineException()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            string longName = new String('A', 51);

            // Act
            vehicule.Nom = longName;
        }

        [TestMethod]
        public void Identifiant_ValidValue_ShouldSet()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            string validId = "ID1234";

            // Act
            vehicule.Identifiant = validId;

            // Assert
            Assert.AreEqual(validId, vehicule.Identifiant);
        }

        [TestMethod]
        [ExpectedException(typeof(ChaineException))]
        public void Identifiant_TooShort_ThrowsChaineException()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            string shortId = "123";

            // Act
            vehicule.Identifiant = shortId;
        }

        [TestMethod]
        [ExpectedException(typeof(ChaineException))]
        public void Identifiant_TooLong_ThrowsChaineException()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            string longId = new String('I', 51);

            // Act
            vehicule.Identifiant = longId;
        }

        [TestMethod]
        public void Couleur_ValidValue_ShouldSet()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            Color color = Color.Red;

            // Act
            vehicule.Couleur = color;

            // Assert
            Assert.AreEqual(color, vehicule.Couleur);
        }

        [TestMethod]
        public void NombreRoues_ValidValue_ShouldSet()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            int validWheels = 8;

            // Act
            vehicule.NombreRoues = validWheels;

            // Assert
            Assert.AreEqual(validWheels, vehicule.NombreRoues);
        }

        [TestMethod]
        [ExpectedException(typeof(EntierException))]
        public void NombreRoues_TooFew_ThrowsEntierException()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();

            // Act
            vehicule.NombreRoues = 3;
        }

        [TestMethod]
        [ExpectedException(typeof(EntierException))]
        public void NombreRoues_TooMany_ThrowsEntierException()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();

            // Act
            vehicule.NombreRoues = 17;
        }

        [TestMethod]
        public void NombrePlaces_ValidValue_ShouldSet()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            int validPlaces = 50;

            // Act
            vehicule.NombrePlaces = validPlaces;

            // Assert
            Assert.AreEqual(validPlaces, vehicule.NombrePlaces);
        }

        [TestMethod]
        [ExpectedException(typeof(EntierException))]
        public void NombrePlaces_NegativeValue_ThrowsEntierException()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();

            // Act
            vehicule.NombrePlaces = -1;
        }

        [TestMethod]
        public void Masse_ValidPositiveValue_ShouldSet()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            double validMass = 2000.0;

            // Act
            vehicule.Masse = validMass;

            // Assert
            Assert.AreEqual(validMass, vehicule.Masse);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Masse_NegativeValue_ThrowsException()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();

            // Act
            vehicule.Masse = -100;
        }

        [TestMethod]
        public void CapacitéDeTirageTotale_ValidPositiveValue_ShouldSet()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();
            double validCapacity = 5000.0;

            // Act
            vehicule.CapacitéDeTirageTotale = validCapacity;

            // Assert
            Assert.AreEqual(validCapacity, vehicule.CapacitéDeTirageTotale);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CapacitéDeTirageTotale_NegativeValue_ThrowsException()
        {
            // Arrange
            Véhicule vehicule = new Véhicule();

            // Act
            vehicule.CapacitéDeTirageTotale = -1000;
        }

        [TestMethod]
        public void Véhicule_ValidParameters_ShouldCreateObject()
        {
            // Arrange
            string nom = "Tramway";
            string identifiant = "ID12345";
            Color couleur = Color.Red;
            double coefficientFriction = 0.5;
            double vitesse = 100.0;
            int nombreRoues = 8;
            int nombrePlaces = 50;
            double masse = 1500.0;
            double capacitéDeTirageTotale = 2000.0;

            // Act
            var véhicule = new Véhicule(nom, identifiant, couleur, coefficientFriction, vitesse, nombreRoues, nombrePlaces, masse, capacitéDeTirageTotale);

            // Assert
            Assert.IsNotNull(véhicule);
        }

        [TestMethod]
        [ExpectedException(typeof(ChaineException))]
        public void Véhicule_NomTooShort_ThrowsChaineException()
        {
            new Véhicule("abc", "ID12345", Color.Blue, 0.5, 120.0, 8, 40, 1600.0, 2500.0);
        }
        [TestMethod]
        [ExpectedException(typeof(ChaineException))]
        public void Véhicule_NomTooLong_ThrowsChaineException()
        {
            new Véhicule(new string('A', 51), "ID12345", Color.Blue, 0.5, 120.0, 8, 40, 1600.0, 2500.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ChaineException))]
        public void Véhicule_IdentifiantTooShort_ThrowsChaineException()
        {
            new Véhicule("Locomotive", "aaaa", Color.Blue, 0.3, 80.0, 10, 80, 3000.0, 3500.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ChaineException))]
        public void Véhicule_IdentifiantTooLong_ThrowsChaineException()
        {
            new Véhicule("Locomotive", new string('A', 51), Color.Blue, 0.3, 80.0, 10, 80, 3000.0, 3500.0);
        }

        [TestMethod]
        [ExpectedException(typeof(EntierException))]
        public void Véhicule_NombreRouesOutsideRangeLow_ThrowsEntierException()
        {
            new Véhicule("MetroTrain", "ID67890", Color.Green, 0.45, 60.0, 3, 60, 1450.0, 1800.0);
        }
        [TestMethod]
        [ExpectedException(typeof(EntierException))]
        public void Véhicule_NombreRouesOutsideRangeHigh_ThrowsEntierException()
        {
            new Véhicule("MetroTrain", "ID67890", Color.Green, 0.45, 60.0, 17, 60, 1450.0, 1800.0);
        }

        [TestMethod]
        [ExpectedException(typeof(EntierException))]
        public void Véhicule_NombrePlacesOutsideRangeLow_ThrowsEntierException()
        {
            new Véhicule("Subway", "ID78901", Color.Black, 0.4, 70.0, 12, -1, 2000.0, 2200.0);
        }
        [TestMethod]
        [ExpectedException(typeof(EntierException))]
        public void Véhicule_NombrePlacesOutsideRangeHigh_ThrowsEntierException()
        {
            new Véhicule("Subway", "ID78901", Color.Black, 0.4, 70.0, 12, 101, 2000.0, 2200.0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Véhicule_MasseNegative_ThrowsException()
        {
            new Véhicule("HighSpeedTrain", "ID89012", Color.White, 0.35, 150.0, 8, 70, -10.0, 1600.0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Véhicule_CapacitéDeTirageTotaleNegative_ThrowsException()
        {
            new Véhicule("CargoTrain", "ID90123", Color.Gray, 0.25, 90.0, 10, 30, 2500.0, -500.0);
        }

        [TestMethod]
        public void Véhicule_CloneConstructor_ShouldCreateCopy()
        {
            Véhicule original = new Véhicule("Original", "ID0001", Color.Green, 0.6, 110, 10, 50, 2500, 3000);
            Véhicule clone = new Véhicule(original);
            Assert.AreEqual(original.Nom, clone.Nom);
            Assert.AreEqual(original.Identifiant, clone.Identifiant);
            Assert.AreEqual(original.Couleur, clone.Couleur);
            Assert.AreEqual(original.CoefficientFriction, clone.CoefficientFriction);
            Assert.AreEqual(original.Vitesse, clone.Vitesse);
            Assert.AreEqual(original.NombreRoues, clone.NombreRoues);
            Assert.AreEqual(original.NombrePlaces, clone.NombrePlaces);
            Assert.AreEqual(original.Masse, clone.Masse);
            Assert.AreEqual(original.CapacitéDeTirageTotale, clone.CapacitéDeTirageTotale);
        }
        //Caboose
        [TestMethod]
        public void DefaultConstructor_SetsDefaultValues()
        {
            // Arrange
            Caboose caboose = new Caboose();

            // Assert
            Assert.AreEqual(typeCab.passager, caboose.TypeCaboose);
        }

        [TestMethod]
        public void ConstructorWithType_SetsValuesCorrectlyForRestaurant()
        {
            // Arrange
            Caboose caboose = new Caboose(typeCab.restaurant, "RestaurantCab", Color.Red);

            // Assert
            Assert.AreEqual("Caboose", caboose.Identifiant);
            Assert.AreEqual(8, caboose.NombreRoues);
            Assert.AreEqual(0, caboose.Vitesse);
            Assert.AreEqual(5000, caboose.CapacitéDeTirageTotale);
            Assert.AreEqual(0.0003, caboose.CoefficientFriction);
            Assert.AreEqual(20, caboose.NombrePlaces);
            Assert.AreEqual(800, caboose.Masse);
            Assert.AreEqual(5, caboose.NombreLits);
        }

        [TestMethod]
        public void ConstructorWithType_SetsValuesCorrectlyForPassenger()
        {
            // Arrange
            Caboose caboose = new Caboose(typeCab.passager, "PassengerCab", Color.Blue);

            // Assert
            Assert.AreEqual("Caboose", caboose.Identifiant);
            Assert.AreEqual(8, caboose.NombreRoues);
            Assert.AreEqual(0, caboose.Vitesse);
            Assert.AreEqual(5000, caboose.CapacitéDeTirageTotale);
            Assert.AreEqual(0.0004, caboose.CoefficientFriction);
            Assert.AreEqual(10, caboose.NombrePlaces);
            Assert.AreEqual(700, caboose.Masse);
            Assert.AreEqual(10, caboose.NombreLits);
        }

        [TestMethod]
        public void CopyConstructor_CopiesAllProperties()
        {
            // Arrange
            Caboose original = new Caboose(typeCab.passager, "PassengerCab", Color.Blue);
            Caboose copy = new Caboose(original);

            // Assert
            Assert.AreEqual(original.TypeCaboose, copy.TypeCaboose);
            Assert.AreEqual(original.NombreLits, copy.NombreLits);
            Assert.IsTrue(original.Equals(copy));
        }

        [TestMethod]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            Caboose caboose = new Caboose(typeCab.passager, "PassengerCab", Color.Blue);

            // Act
            string cabooseString = caboose.ToString();

            // Assert
            Assert.IsTrue(cabooseString.Contains($"TypeCaboose: {caboose.TypeCaboose},\n Nombre de Lits: {caboose.NombreLits}\n"));
        }

        [TestMethod]
        public void Equals_SameContent_ReturnsTrue()
        {
            // Arrange
            Caboose caboose1 = new Caboose(typeCab.passager, "PassengerCab", Color.Blue);
            Caboose caboose2 = new Caboose(typeCab.passager, "PassengerCab", Color.Blue);

            // Assert
            Assert.IsTrue(caboose1.Equals(caboose2));
        }

        [TestMethod]
        public void Equals_DifferentContent_ReturnsFalse()
        {
            // Arrange
            Caboose caboose1 = new Caboose(typeCab.passager, "PassengerCab", Color.Blue);
            Caboose caboose2 = new Caboose(typeCab.restaurant, "RestaurantCab", Color.Red);

            // Assert
            Assert.IsFalse(caboose1.Equals(caboose2));
        }

        [TestMethod]
        public void GetHashCode_EqualObjects_SameHashCode()
        {
            // Arrange
            Caboose caboose1 = new Caboose(typeCab.passager, "PassengerCab", Color.Blue);
            Caboose caboose2 = new Caboose(typeCab.passager, "PassengerCab", Color.Blue);

            // Assert
            Assert.AreEqual(caboose1.GetHashCode(), caboose2.GetHashCode());
        }

        //Wagon
        [TestMethod]
        public void Wagon_DefaultConstructor_ShouldSetDefaultValues()
        {
            // Arrange & Act
            Wagon wagon = new Wagon();

            // Assert
            Assert.AreEqual(typeW.animaux, wagon.TypeWagon);
            Assert.AreEqual(0.0, wagon.Tarif);
        }

        [TestMethod]
        public void Wagon_OverloadedConstructorWithProperties_ShouldSetProvidedValues()
        {
            // Arrange
            typeW type = typeW.grain;
            string nom = "TestWagon";
            Color couleur = Color.Red;

            // Act
            Wagon wagon = new Wagon(type, nom, couleur);

            // Assert
            Assert.AreEqual(type, wagon.TypeWagon);
            Assert.AreEqual("Wagon", wagon.Identifiant);
            Assert.AreEqual(4, wagon.NombreRoues);
            Assert.AreEqual(nom, wagon.Nom);
            Assert.AreEqual(couleur, wagon.Couleur);
        }

        [TestMethod]
        public void Wagon_CopyConstructor_ShouldCloneWagon()
        {
            // Arrange
            Wagon original = new Wagon(typeW.animaux, "OriginalWagon", Color.Blue);

            // Act
            Wagon copy = new Wagon(original);

            // Assert
            Assert.AreEqual(original.TypeWagon, copy.TypeWagon);
            Assert.AreEqual(original.Tarif, copy.Tarif);
            Assert.AreEqual(original.Nom, copy.Nom);
            Assert.AreEqual(original.Identifiant, copy.Identifiant);
            Assert.AreEqual(original.Couleur, copy.Couleur);
            Assert.AreEqual(original.CoefficientFriction, copy.CoefficientFriction);
            Assert.AreEqual(original.Vitesse, copy.Vitesse);
            Assert.AreEqual(original.NombreRoues, copy.NombreRoues);
            Assert.AreEqual(original.NombrePlaces, copy.NombrePlaces);
            Assert.AreEqual(original.Masse, copy.Masse);
            Assert.AreEqual(original.CapacitéDeTirageTotale, copy.CapacitéDeTirageTotale);
        }

        [TestMethod]
        public void ToString_WhenCalled_ShouldReturnCorrectStringFormat()
        {
            // Arrange
            Wagon wagon = new Wagon(typeW.animaux, "ToStringWagon", Color.Beige);

            // Act
            string wagonString = wagon.ToString();

            // Assert
            Assert.IsTrue(wagonString.StartsWith("Nom: ToStringWagon,"));
            Assert.IsTrue(wagonString.Contains("TypeWagon: animaux,"));
            Assert.IsTrue(wagonString.Contains("Tarif: 4.5"));
        }

        [TestMethod]
        public void Equals_DifferentWagons_ShouldReturnFalse()
        {
            // Arrange
            Wagon wagon1 = new Wagon(typeW.animaux, "Wagon1", Color.Black);
            Wagon wagon2 = new Wagon(typeW.citerne, "Wagon2", Color.White);

            // Act & Assert
            Assert.IsFalse(wagon1.Equals(wagon2));
        }

        [TestMethod]
        public void Equals_SameWagons_ShouldReturnTrue()
        {
            // Arrange
            Wagon wagon1 = new Wagon(typeW.animaux, "EqualWagon", Color.Red);
            Wagon wagon2 = new Wagon(wagon1);

            // Act & Assert
            Assert.IsTrue(wagon1.Equals(wagon2));
        }

        [TestMethod]
        public void GetHashCode_SameWagons_ShouldReturnSameHashCode()
        {
            // Arrange
            Wagon wagon1 = new Wagon(typeW.animaux, "HashWagon", Color.Red);
            Wagon wagon2 = new Wagon(wagon1);

            // Act & Assert
            Assert.AreEqual(wagon1.GetHashCode(), wagon2.GetHashCode());
        }

        //Locomotive
        [TestMethod]
        public void TestDefaultConstructor_Locomotive()
        {
            // Arrange
            Locomotive locomotive = new Locomotive();

            // Act & Assert
            Assert.AreEqual(typeLocomotive.courtVoyage, locomotive.TypeLocomotive);
            Assert.AreEqual("xxxxx", locomotive.Identifiant);
            Assert.AreEqual(4, locomotive.NombreRoues);
            Assert.AreEqual(0, locomotive.NombrePlaces);
        }

        [TestMethod]
        public void TestParameterizedConstructor_LongVoyage_Locomotive()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);

            // Act & Assert
            Assert.AreEqual(typeLocomotive.longVoyage, locomotive.TypeLocomotive);
            Assert.AreEqual("LongExpress", locomotive.Nom);
            Assert.AreEqual(Color.Red, locomotive.Couleur);
            Assert.AreEqual(0.001, locomotive.CoefficientFriction);
            Assert.AreEqual(50000, locomotive.CapacitéDeTirageTotale);
            Assert.AreEqual(1000, locomotive.Masse);
            Assert.AreEqual(35, locomotive.Vitesse);
        }

        [TestMethod]
        public void TestParameterizedConstructor_MediumVoyage_Locomotive()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.moyenVoyage, "MediumRunner", Color.Blue);

            // Act & Assert
            Assert.AreEqual(typeLocomotive.moyenVoyage, locomotive.TypeLocomotive);
            Assert.AreEqual("MediumRunner", locomotive.Nom);
            Assert.AreEqual(Color.Blue, locomotive.Couleur);
            Assert.AreEqual(0.002, locomotive.CoefficientFriction);
            Assert.AreEqual(75000, locomotive.CapacitéDeTirageTotale);
            Assert.AreEqual(1500, locomotive.Masse);
            Assert.AreEqual(40, locomotive.Vitesse);
        }

        [TestMethod]
        public void TestParameterizedConstructor_ShortVoyage_Locomotive()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.courtVoyage, "ShortSprint", Color.Green);

            // Act & Assert
            Assert.AreEqual(typeLocomotive.courtVoyage, locomotive.TypeLocomotive);
            Assert.AreEqual("ShortSprint", locomotive.Nom);
            Assert.AreEqual(Color.Green, locomotive.Couleur);
            Assert.AreEqual(0.003, locomotive.CoefficientFriction);
            Assert.AreEqual(100000, locomotive.CapacitéDeTirageTotale);
            Assert.AreEqual(2000, locomotive.Masse);
            Assert.AreEqual(50, locomotive.Vitesse);
        }

        [TestMethod]
        public void TestCopyConstructor_Locomotive()
        {
            // Arrange
            Locomotive original = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            Locomotive copy = new Locomotive(original);

            // Act & Assert
            Assert.AreEqual(original.TypeLocomotive, copy.TypeLocomotive);
            Assert.AreEqual(original.Nom, copy.Nom);
            Assert.AreEqual(original.Couleur, copy.Couleur);
            Assert.AreEqual(original.CoefficientFriction, copy.CoefficientFriction);
            Assert.AreEqual(original.Vitesse, copy.Vitesse);
            Assert.AreEqual(original.NombreRoues, copy.NombreRoues);
            Assert.AreEqual(original.NombrePlaces, copy.NombrePlaces);
            Assert.AreEqual(original.Masse, copy.Masse);
            Assert.AreEqual(original.CapacitéDeTirageTotale, copy.CapacitéDeTirageTotale);
            Assert.IsTrue(original.Equals(copy));
        }

        [TestMethod]
        public void TestEquals_SameObject()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.moyenVoyage, "MediumRunner", Color.Blue);

            // Act & Assert
            Assert.IsTrue(locomotive.Equals(locomotive));
        }

        [TestMethod]
        public void TestEquals_DifferentObjectSameValues()
        {
            // Arrange
            Locomotive locomotive1 = new Locomotive(typeLocomotive.moyenVoyage, "MediumRunner", Color.Blue);
            Locomotive locomotive2 = new Locomotive(typeLocomotive.moyenVoyage, "MediumRunner", Color.Blue);

            // Act & Assert
            Assert.IsTrue(locomotive1.Equals(locomotive2));
        }

        [TestMethod]
        public void TestEquals_DifferentObjectDifferentValues()
        {
            // Arrange
            Locomotive locomotive1 = new Locomotive(typeLocomotive.moyenVoyage, "MediumRunner", Color.Blue);
            Locomotive locomotive2 = new Locomotive(typeLocomotive.courtVoyage, "ShortSprint", Color.Green);

            // Act & Assert
            Assert.IsFalse(locomotive1.Equals(locomotive2));
        }

        [TestMethod]
        public void TestHashCode_Equality()
        {
            // Arrange
            Locomotive locomotive1 = new Locomotive(typeLocomotive.moyenVoyage, "MediumRunner", Color.Blue);
            Locomotive locomotive2 = new Locomotive(typeLocomotive.moyenVoyage, "MediumRunner", Color.Blue);

            // Act & Assert
            Assert.AreEqual(locomotive1.GetHashCode(), locomotive2.GetHashCode());
        }

        [TestMethod]
        public void TestToString_ContainsType()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);

            // Act & Assert
            StringAssert.Contains(locomotive.ToString(), "TypeLocomotive: longVoyage");
        }

        //TrainFerroviere
        [TestMethod]
        public void TestNomLocomotive_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);

            // Act
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Assert
            Assert.AreEqual(train.Vitesse, locomotive.Vitesse);
            Assert.IsTrue(train.NombreLocomotive() == 1);
            Assert.AreEqual(train.Nom, "aaa");
            Assert.AreEqual(train.CapacitéTotale, locomotive.CapacitéDeTirageTotale);
        }
        [TestMethod]
        public void TestNomLocomotiveListVehicule_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            Wagon wagon = new Wagon(typeW.citerne, "Wagon", Color.Red);
            Caboose caboose = new Caboose(typeCab.passager, "CabPass", Color.Red);
            List<Véhicule> listVehicule = new List<Véhicule> { wagon, caboose };

            // Act
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive, listVehicule);

            // Assert
            Assert.IsTrue(train.NombreLocomotive() == 1); // Test Methode NombreLocomotive()
            Assert.IsTrue(train.NombreWagon() == 1); // Test Methode NombreWagon()
            Assert.IsTrue(train.NombreWagonCiterne() == 1); // Test Methode NombreWagonCiterne()
            Assert.IsTrue(train.NombreCaboose() == 1); // Test Methode NombreCaboose()
            Assert.AreEqual(Math.Round(train.Vitesse,2), 34.44);
            Assert.AreEqual(train.Nom, "aaa");
            Assert.AreEqual(train.CapacitéTotale, 53900);
            Assert.AreEqual(train.TarifTotal, 2200);
        }

        [TestMethod]
        public void TrainFerroviaire_SetAndGetProperties_CorrectlyHandlesProperties()
        {
            TrainFerroviaire train = new TrainFerroviaire("TrainNommer", new Locomotive());
            train.Train = new List<Véhicule> { new Véhicule() };
            train.CapacitéTotale = 100.0;
            train.TarifTotal = 200.0;
            train.Vitesse = 300.0;
            train.Nom = "Express";

            Assert.AreEqual(1, train.Train.Count);
            Assert.AreEqual(100.0, train.CapacitéTotale);
            Assert.AreEqual(200.0, train.TarifTotal);
            Assert.AreEqual(300.0, train.Vitesse);
            Assert.AreEqual("Express", train.Nom);
        }
        [TestMethod]
        public void TestAttacherCaboose_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);
            Caboose caboose = new Caboose(typeCab.passager, "CabooseNom", Color.Sienna);

            // Act And Assert
            Assert.IsTrue(train.Attacher(caboose));
            Assert.IsTrue(train.NombreCaboose() == 1);
            Assert.AreEqual(train.Train[1], caboose);
        }
        [TestMethod]
        [ExpectedException(typeof(VitesseException))]
        public void TestAttacherCaboose_VitesseException_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);
            Caboose caboose = new Caboose(typeCab.passager, "CabooseNom", Color.Sienna);
            caboose.Masse = 10000000000; // Masse trop grosse va ralentir la vitesse en dessous de 5

            // Act And Assert
            train.Attacher(caboose);
        }
        [TestMethod]
        public void TestAttacherWagon_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);
            Wagon wagon = new Wagon(typeW.grain, "CabooseNom", Color.Sienna);

            // Act And Assert
            Assert.IsTrue(train.Attacher(wagon));
            Assert.IsTrue(train.NombreWagon() == 1);
            Assert.AreEqual(train.Train[1], wagon);
        }
        [TestMethod]
        [ExpectedException(typeof(VitesseException))]
        public void TestAttacherWagon_VitesseException_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);
            Wagon wagon = new Wagon(typeW.grain, "CabooseNom", Color.Sienna);
            wagon.Masse = 10000000000; // Masse trop grosse va ralentir la vitesse en dessous de 5

            // Act And Assert
            train.Attacher(wagon);
        }
        [TestMethod]
        [ExpectedException(typeof(ExplosionException))]
        public void TestAttacherWagon_ExplosionException_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);
            Wagon wagon1 = new Wagon(typeW.citerne, "CabooseNom", Color.Sienna);
            Wagon wagon2 = new Wagon(typeW.citerne, "CabooseNom", Color.Sienna);
            Wagon wagon3 = new Wagon(typeW.citerne, "CabooseNom", Color.Sienna);
            Wagon wagon4 = new Wagon(typeW.citerne, "CabooseNom", Color.Sienna);
            Wagon wagon5 = new Wagon(typeW.citerne, "CabooseNom", Color.Sienna);
            Wagon wagon6 = new Wagon(typeW.citerne, "CabooseNom", Color.Sienna);

            // Act And Assert
            train.Attacher(wagon1);
            train.Attacher(wagon2);
            train.Attacher(wagon3);
            train.Attacher(wagon4);
            train.Attacher(wagon5); 
            train.Attacher(wagon6); // Lancera une exception s'il y a deja 5 wagon citerne
        }
        [TestMethod]
        [ExpectedException(typeof(CapaciteException))]
        public void TestAttacherWagon_CapaciteException_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);
            Wagon wagon = new Wagon(typeW.citerne, "CabooseNom", Color.Sienna);
            wagon.CoefficientFriction = 0; //Empeche une vitesse trop basse
            wagon.Masse = 10000000000; // Masse trop grosse pour la capacité

            // Act And Assert
            train.Attacher(wagon);
        }
        [TestMethod]
        [ExpectedException(typeof(TrainException))]
        public void TestAttacherLocomotive_TrainException_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);
            Locomotive locomotive2 = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);

            // Act And Assert
            train.Attacher(locomotive2);
        }
        [TestMethod]
        public void TestDetacherCaboose_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);
            Caboose caboose = new Caboose(typeCab.passager, "CabooseNom", Color.Sienna);

            // Act
            train.Attacher(caboose);

            // Assert
            Assert.IsTrue(train.Detacher(caboose)); // Va enlever le caboose fraichement entrer
            Assert.IsTrue(!train.Detacher(caboose)); // N'enleve rien du train puisqu'aucun caboose correspondant se retrouve dans le train
        }
        [TestMethod]
        public void TestDetacherWagon_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);
            Wagon wagon = new Wagon(typeW.citerne, "CabooseNom", Color.Sienna);

            // Act
            train.Attacher(wagon);

            // Assert
            Assert.IsTrue(train.Detacher(wagon)); // Va enlever le wagon fraichement entrer
            Assert.IsTrue(!train.Detacher(wagon)); // N'enleve rien du train puisqu'aucun wagon correspondant se retrouve dans le train
        }
        [TestMethod]
        [ExpectedException(typeof(TrainException))]
        public void TestDetacherLocomotive_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act and Assert
            train.Detacher(locomotive); // Va lancer un erreur puisque la locomotive ne peut pas être enlever du train
        }
        [TestMethod]
        public void Modifier_OneLocomotiveLongVoyageToMoyenVoyage_ModifySuccessful()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            bool result = train.Modifier("New Loco", typeLocomotive.moyenVoyage, Color.Red);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Modifier_OneLocomotiveLongVoyageToCourtVoyage_ModifySuccessful()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.longVoyage, "LongExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            bool result = train.Modifier("New Loco", typeLocomotive.courtVoyage, Color.Blue);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Modifier_OneLocomotiveMoyenVoyageToLongVoyage_ModifySuccessful()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.moyenVoyage, "MoyenExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            bool result = train.Modifier("New Loco", typeLocomotive.longVoyage, Color.Blue);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(VitesseException))]
        public void Modifier_OneLocomotiveMoyenVoyageToLongVoyage_ThrowsVitesseExceptionForSlowSpeed()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.moyenVoyage, "MoyenExpress", Color.Red);
            locomotive.Vitesse = 1; // Ajustement pour simuler un erreur
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            train.Modifier("New Loco", typeLocomotive.longVoyage, Color.Green);
        }
        [TestMethod]
        [ExpectedException(typeof(VitesseException))]
        public void Modifier_OneLocomotiveMoyenVoyageToLongVoyage_ThrowsVitesseExceptionForIncapacity()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.moyenVoyage, "MoyenExpress", Color.Red);
            locomotive.CapacitéDeTirageTotale = 1; // Ajustement pour simuler un erreur
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            train.Modifier("New Loco", typeLocomotive.longVoyage, Color.Green);
        }
        [TestMethod]
        public void Modifier_OneLocomotiveMoyenVoyageToCourtVoyage_ModifySuccessful()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.moyenVoyage, "MoyenExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            bool result = train.Modifier("New Loco", typeLocomotive.courtVoyage, Color.Blue);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Modifier_OneLocomotiveCourtVoyageToLongVoyage_ModifySuccessful()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.courtVoyage, "CourtExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            bool result = train.Modifier("New Loco", typeLocomotive.longVoyage, Color.Blue);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        [ExpectedException(typeof(VitesseException))]
        public void Modifier_OneLocomotiveCourtVoyageToLongVoyage_ThrowsVitesseExceptionForSlowSpeed()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.courtVoyage, "CourtExpress", Color.Red);
            locomotive.Vitesse = 1; // Ajustement pour simuler un erreur
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            train.Modifier("New Loco", typeLocomotive.longVoyage, Color.Green);
        }
        [TestMethod]
        [ExpectedException(typeof(VitesseException))]
        public void Modifier_OneLocomotiveCourtVoyageToLongVoyage_ThrowsVitesseExceptionForIncapacity()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.courtVoyage, "CourtExpress", Color.Red);
            locomotive.CapacitéDeTirageTotale = 1; // Ajustement pour simuler un erreur
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            train.Modifier("New Loco", typeLocomotive.longVoyage, Color.Green);
        }
        [TestMethod]
        public void Modifier_OneLocomotiveCourtVoyageToMoyenVoyage_ModifySuccessful()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.courtVoyage, "CourtExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            bool result = train.Modifier("New Loco", typeLocomotive.moyenVoyage, Color.Blue);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        [ExpectedException(typeof(VitesseException))]
        public void Modifier_OneLocomotiveCourtVoyageToMoyenVoyage_ThrowsVitesseExceptionForSlowSpeed()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.courtVoyage, "CourtExpress", Color.Red);
            locomotive.Vitesse = 1; // Ajustement pour simuler un erreur
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            train.Modifier("New Loco", typeLocomotive.moyenVoyage, Color.Green);
        }
        [TestMethod]
        [ExpectedException(typeof(VitesseException))]
        public void Modifier_OneLocomotiveCourtVoyageToMoyenVoyage_ThrowsVitesseExceptionForIncapacity()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.courtVoyage, "CourtExpress", Color.Red);
            locomotive.CapacitéDeTirageTotale = 1; // Ajustement pour simuler un erreur
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            // Act
            train.Modifier("New Loco", typeLocomotive.moyenVoyage, Color.Green);
        }
        [TestMethod]
        public void ToString_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.courtVoyage, "CourtExpress", Color.Red);
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive);

            string toString = "Nom: aaa,\nCapacité: 100000,\n Vitesse: 50,\n Tarif Total: 0$," +
                "\n Nombre de Wagon: 0,\n Nombre de Caboose: 0,\n Nombre de Locomotive: 1,\n " +
                "Train:\n----Train#1----\nNom: CourtExpress,\n Identifiant: Locomotive,\n Couleur: Color [Red]," +
                "\n Coefficient de Friction: 0.003,\n Vitesse: 50,\n Nombre de Roues: 8,\n Nombre de Places: 2," +
                "\n Masse: 2000,\n Capacité de Tirage Totale: 100000\nTypeLocomotive: courtVoyage\n";


            // Act
            Assert.AreEqual(toString, train.ToString());
        }
        [TestMethod]
        public void ToStringWithVehicules_TrainFerroviere()
        {
            // Arrange
            Locomotive locomotive = new Locomotive(typeLocomotive.courtVoyage, "CourtExpress", Color.Red);
            Caboose caboose = new Caboose(typeCab.passager, "CabooseNom", Color.Sienna);
            Wagon wagon = new Wagon(typeW.citerne, "CabooseNom", Color.Sienna);
            List<Véhicule> listVehicule = new List<Véhicule> { wagon, caboose };
            TrainFerroviaire train = new TrainFerroviaire("aaa", locomotive, listVehicule);

            string toString = "Nom: aaa,\nCapacité: 103900,\n Vitesse: 49.44,\n Tarif Total: 2200$," +
                "\n Nombre de Wagon: 1,\n Nombre de Caboose: 1,\n Nombre de Locomotive: 1,\n Train:\n----Train#1----" +
                "\nNom: CourtExpress,\n Identifiant: Locomotive,\n Couleur: Color [Red],\n Coefficient de Friction: 0.003," +
                "\n Vitesse: 50,\n Nombre de Roues: 8,\n Nombre de Places: 2,\n Masse: 2000,\n Capacité de Tirage Totale: 100000" +
                "\nTypeLocomotive: courtVoyage\n----Train#2----\nNom: CabooseNom,\n Identifiant: Wagon,\n Couleur: Color [Sienna]," +
                "\n Coefficient de Friction: 0.0007,\n Vitesse: 0,\n Nombre de Roues: 4,\n Nombre de Places: 0,\n Masse: 400," +
                "\n Capacité de Tirage Totale: 0\nTypeWagon: citerne,\n Tarif: 5.5\n----Train#3----\nNom: CabooseNom," +
                "\n Identifiant: Caboose,\n Couleur: Color [Sienna],\n Coefficient de Friction: 0.0004,\n Vitesse: 0," +
                "\n Nombre de Roues: 8,\n Nombre de Places: 10,\n Masse: 700,\n Capacité de Tirage Totale: 5000" +
                "\nTypeCaboose: passager,\n Nombre de Lits: 10\n";



            // Act
            Assert.AreEqual(toString, train.ToString());
        }
    }
}

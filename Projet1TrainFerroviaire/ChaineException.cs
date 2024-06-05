using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1TrainFerroviaire
{
    public class ChaineException : Exception
    {
        public ChaineException(string nomPropriete, int min, int max): base($"{nomPropriete} doit être de longueur entre {min} et {max}") { }
    }
}

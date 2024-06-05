using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1TrainFerroviaire
{
    public class EntierException : Exception
    {
        public EntierException(string nomPropriete, int min, int max) : base($"{nomPropriete} doit être dans les bornes ({min},{max})") { }
    }
}

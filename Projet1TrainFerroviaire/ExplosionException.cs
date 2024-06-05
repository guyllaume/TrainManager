using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1TrainFerroviaire
{
    public class ExplosionException : Exception
    {
        public ExplosionException(string message) : base(message) { }
    }
}

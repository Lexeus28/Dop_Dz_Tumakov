using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dop_Dz_Tumakov
{
    public class Temperament
    {
        public int Scandalousness { get; set; }
        public bool IsSmart { get; set; }

        public Temperament(int scandalousness, bool isSmart)
        {
            Scandalousness = scandalousness;
            IsSmart = isSmart;
        }
    }
}

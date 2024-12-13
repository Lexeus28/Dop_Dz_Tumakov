using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dop_Dz_Tumakov
{
    public class Resident
    {
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public Problem Problem { get; set; }
        public Temperament Temperament { get; set; }

        public Resident(string name, string passportNumber, Problem problem, Temperament temperament)
        {
            Name = name;
            PassportNumber = passportNumber;
            Problem = problem;
            Temperament = temperament;
        }
    }
}

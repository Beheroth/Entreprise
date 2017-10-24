using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime();
            date.AddMonths(10);
            date.AddDays(23);
            date.AddYears(2017);
            String name = "GE";

            Generator gen = new Generator();
            Entreprise entreprise = gen.GenerateAll(name, date);


        }
    }
}

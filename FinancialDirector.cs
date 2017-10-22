using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class FinancialDirector : Director
    {
        public FinancialDirector(String firstname, String lastname, int personnalaccount) :
            base(firstname, lastname, personnalaccount)
        {

        }

        public void GenerateReport()
        {
            //TODO
        }
    }
}

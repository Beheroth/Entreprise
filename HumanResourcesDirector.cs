using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class HumanResourcesDirector : Director
    {
        public HumanResourcesDirector(String firstname, String lastname, int personnalaccount) :
            base(firstname, lastname, personnalaccount)
        {

        }

        public void GenerateReport()
        {

        }
    }

}

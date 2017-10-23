using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class FinancialDirector : Director, IGenerateReport
    {
        public FinancialDirector(
            String firstname,
            String lastname, 
            int personnalaccount) :
            base(firstname, lastname, personnalaccount)
        {

        }

        public void GenerateReport(Entreprise entreprise)
        {
            Dictionary<String, Person> employees = new Dictionary<string, Person>(entreprise.GetConsultants());
            employees.Concat(entreprise.GetManagers());
            employees.Concat(entreprise.GetDirectors());
        }
    }
}

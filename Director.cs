using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class Director : Person
    {
        public Director(String firstname, String lastname, int personnalaccount) : base(firstname, lastname, personnalaccount)
        {
            
        }
        public void GenerateReport(Entreprise entreprise)
        {
            
        }

        public void GetPaid()
        {
            this.SetPersonnalaccount(this.GetPersonnalaccount() + 150000); 
        }
    }

}

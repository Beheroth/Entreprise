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

        private string GenerateDirectorsSalary(Entreprise entreprise, DateTime date)
        {
            string report = " - Directors: \r \r";
            foreach(Director director in entreprise.GetDirectors().Values)
            {
                report += String.Format("   - {0} {1} - {2} - {3} €\r",
                    director.GetFirstname(),
                    director.GetLastname(),
                    director.GetType(),
                    150000);
            }
            return report + "\r";
        }

        private string GenerateManagersSalary(Entreprise entreprise, DateTime date)
        {
            string report = " - Managers: \r \r";
            foreach (Manager manager in entreprise.GetManagers().Values)
            {
                report += String.Format("   - {0} {1} - {2} €\r",
                    manager.GetFirstname(),
                    manager.GetLastname(),
                    60000 + 500 * manager.NumberConsultant());
            }
            return report + "\r"; 
        }

        private string GenerateConsultantsSalary(Entreprise entreprise, DateTime date)
        {
            string report = " - Consultants: \r \r";
            foreach (Consultant consultant in entreprise.GetConsultants().Values)
            {
                report += String.Format("   - {0} {1} - {2} €\r",
                    consultant.GetFirstname(),
                    consultant.GetLastname(),
                    60000 + 500 ); //TODO: modifier consultant pour qu'il détienne un agenda de toutes ses missions effectuées... ou pas
            }
            return report + "\r";
        }

        public string GenerateReport(Entreprise entreprise, DateTime date)
        {
            string report = String.Format("- Relevé des salaires au sein de {0} - {1}\r \r", entreprise.GetName(), date.Year);
            report += this.GenerateDirectorsSalary(entreprise, date) + this.GenerateManagersSalary(entreprise, date) + this.GenerateConsultantsSalary(entreprise, date);
            Console.Write(report);
            return report;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class FinancialDirector : Director
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
            foreach (Manager manager in entreprise.GetManagers().Values)
            {
                foreach (Consultant consultant in manager.GetConsultants().Values)
                {
                    int bonus = (60000 + 500 * manager.NumberConsultant()) / 100;
                    foreach(Mission mission in consultant.GetMissionsFromYear(date))
                    {
                        int bounty = 250;
                        Console.WriteLine("GENE SAL CON: " + mission.GetClient().GetType());
                        if(mission.GetClient().GetType() is Entreprise)
                        {
                            bounty = -10*mission.GetDuration();
                        }
                        bonus += bounty;
                    }

                    report += String.Format("   - {0} {1} - {2} €\r",
                        consultant.GetFirstname(),
                        consultant.GetLastname(),
                        30000 + bonus);
                }
            }
            return report + "\r";
        }

        public void GenerateReport(Entreprise entreprise)
        {
            Console.WriteLine("[FD] FD will generate report");
            File FDReport = new File("Financial Report - " + this.ToString() + entreprise.GetDate().ToString() + ".txt");
            string report = String.Format("- Relevé des salaires au sein de {0} - {1}\r \r", entreprise.GetName(), entreprise.GetDate().Year);
            report += this.GenerateDirectorsSalary(entreprise, entreprise.GetDate()) + this.GenerateManagersSalary(entreprise, entreprise.GetDate()) + this.GenerateConsultantsSalary(entreprise, entreprise.GetDate());
            Console.Write(report);
            FDReport.SaveFile(report);
        }
    }
}

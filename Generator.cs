using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entreprise
{
    class Generator
    {
        public Generator()
        {
        }

        // Method to generate the lists of the entreprise

        public List<Consultant> GenerateConsultant(String filename)
        {
            List<Consultant> result = new List<Consultant>();
            File consultantfile = new File(filename);
            // Extract each line of the file 
            foreach (string c in consultantfile.Load)
            {
                // Use the lines who match the pattern of the regex
                Regex rg = new Regex(@"^(?<job>\[a-zA-Z])/(?<firstname>[a-zA-Z])/(?<lastname>[a-zA-Z])/(?<personalaccount>[0-9])$");
                Match m = rg.Match(c);
                if (m.Success)
                {
                    if (m.Groups["job"].Value == "consultant")
                    {
                        // Generate the consultant
                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        Consultant consultant = new Consultant(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        result.Add(consultant);
                    }
                }
            }
            return result;
        }

        public List<Director> GenerateDirector(String filename)
        {
            List<Director> result = new List<Director>();
            File directorfile = new File(filename);
            // Extract each line of the file
            foreach (string c in directorfile.Load)
            {
                // Use the lines who match the pattern of the regex
                Regex rg = new Regex(@"^(?<job>\[a-zA-Z])/(?<firstname>[a-zA-Z])/(?<lastname>[a-zA-Z])/(?<personalaccount>[0-9])$");
                Match m = rg.Match(c);
                if (m.Success)
                {
                    // Generate the directors
                    if (m.Groups["job"].Value == "director")
                    {
                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        Director director = new Director(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        result.Add(director);
                    }
                    if (m.Groups["job"].Value == "financialdirector")
                    {
                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        FinancialDirector director = new FinancialDirector(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        result.Add(director);
                    }
                    if(m.Groups["job"].Value == "humanresourcesdirector")
                    {
                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        HumanResourcesDirector director = new HumanResourcesDirector(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        result.Add(director);
                    }
                }
            }
            return result;
        }
        public List<Manager> GenerateManager(String filename)
        {
            List<Manager> result = new List<Manager>();
            File managerfile = new File(filename);
            // Extract each line of the file
            foreach (string c in managerfile.Load)
            {
                // Use the lines who match the pattern of the regex
                Regex rg = new Regex(@"^(?<job>\[a-zA-Z])/(?<firstname>[a-zA-Z])/(?<lastname>[a-zA-Z])/(?<personalaccount>[0-9])/(?<consultantslist>\S)$");
                Match m = rg.Match(c);
                if (m.Success)
                {
                    if (m.Groups["job"].Value == "manager")
                    {
                        // Generate the manager
                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        Manager manager = new Manager(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);

                        foreach (string consultant in m.Groups["consultantslist"].Value.Split('.'))
                        {
                            // must receive the dico of all the consultants to link them at their manager or
                        }

                        manager.AddConsultant(consultant);
                        result.Add(manager);
                    }
                }
            }
            return result;

        }

        public List<Client> GenerateClient(String filename)
        {
            List<Client> result = new List<Client>();
            File clientfile = new File(filename);
            // Extract each line of the file
            foreach (string c in clientfile.Load)
            {
                Regex rg = new Regex(@"^(?<job>[a-zA-Z])/(?<name>\w)$");
                Match m = rg.Match(c);
                if (m.Success)
                {
                    if (m.Groups["job"].Value == "client")
                    {
                        // Generate the client
                        Client client = new Client(m.Groups["name"].Value);
                        result.Add(client);
                    }
                }
            }
            return result;
        }
    }
}

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
        public Entreprise Entreprise;

        public Generator(String entreprise, DateTime date)
        {
            this.Entreprise = new Entreprise(entreprise, date);
        }

        // Method to generate the lists of the entreprise

        public void GenerateEmploye(String filename)
        {
            File employefile = new File(filename);
            // Extract each line of the file 
            foreach (string c in employefile.Load)
            {
                // Use the lines who match the pattern of the regex
                Regex rg = new Regex(@"^(?<job>\[a-zA-Z]+)/(?<firstname>[a-zA-Z]+)/(?<lastname>[a-zA-Z]+)/(?<personalaccount>[0-9]+)$");
                Match m = rg.Match(c);
                if (m.Success)
                {
                    // Generate the consultants
                    if (m.Groups["job"].Value == "consultant")
                    {
                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        Consultant consultant = new Consultant(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        this.Entreprise.AddConsultant(consultant);
                    }

                    // Generate the directors
                    if (m.Groups["job"].Value == "director")
                    {
                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        Director director = new Director(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        this.Entreprise.AddDirector(director);
                    }
                    if (m.Groups["job"].Value == "financialdirector")
                    {
                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        FinancialDirector director = new FinancialDirector(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        this.Entreprise.AddDirector(director);
                    }
                    if (m.Groups["job"].Value == "humanresourcesdirector")
                    {
                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        HumanResourcesDirector director = new HumanResourcesDirector(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        this.Entreprise.AddDirector(director);
                    }

                    // Generate the managers
                    if (m.Groups["job"].Value == "manager")
                    {
                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        Manager manager = new Manager(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        this.Entreprise.AddManager(manager);
                    }
                }
            }

        }

        public List<Mission> GenerateMission(String filename)
        {
            Dictionary<String, List<Mission>> result = new Dictionary<String, List<Mission>>();
            File missionfile = new File(filename);
            // Extract each line of the file
            foreach (string c in missionfile.Load)
            {
                Regex rg = new Regex(@"^(?<consultant>[a-zA-Z]+)/(?<datein>+)/(?<dateout>+)/(?<client>\w+)$");
                Match m = rg.Match(c);
                if (m.Success)
                {
                    Consultant consultant = this.Entreprise.DictionaryConsultants[m.Groups["consultant"].Value];
                    Client client = this.Entreprise.DictionaryClients[m.Groups["client"].Value];


                    // Generate time in
                    string[] datein = m.Groups["datein"].Value.Split('-'); // format date year-month-day
                    DateTime In = new DateTime();
                    In.AddYears(Int32.Parse(datein[0]));
                    In.AddMonths(Int32.Parse(datein[1]));
                    In.AddDays(Int32.Parse(datein[2]));

                    // Generate time out
                    string[] dateout = m.Groups["datein"].Value.Split('-'); // format date year-month-day
                    DateTime Out = new DateTime();
                    Out.AddYears(Int32.Parse(dateout[0]));
                    Out.AddMonths(Int32.Parse(dateout[1]));
                    Out.AddDays(Int32.Parse(dateout[2]));

                    // Generate Mission
                    Mission mission = new Mission(In, Out, client); // Problem to create object mission ??

                    if ( result.ContainsKey(m.Groups["consultant"].Value)) // if key in dictionary 
                    {
                        result[m.Groups["consultant"].Value].Add(mission);
                    }
                    else
                    {
                        List<Mission> listmission = new List<Mission>();
                        listmission.Add(mission);
                        result[m.Groups["consultant"].Value] = listmission;
                    }


                    // find consultant in file
                    // create consultantagenda type: List<Mission>
                    // mission type: <datetimestart, datetimeend, client>

                    // find his manager
                    // add consultant agenda to the manager
                }
            }
        }

        public void LinkConsultantandManager(String filename)
        {
            File linkfile = new File(filename);
            // Extract each line of the file
            foreach (string l in linkfile.Load)
            {
                Regex rg = new Regex(@"^(?<manager>[a-zA-Z])/(?<consultantslist>\w)$");
                Match m = rg.Match(l);
                if (m.Success)
                {
                    String managername = m.Groups["manager"].Value;
                    try
                    {
                        Manager manager = this.Entreprise.DictionaryManagers[managername];
                        string[] consultants = m.Groups["consultantslist"].Value.Split('-');
                        foreach (String consultantname in consultants)
                        {
                            Consultant consultant = this.Entreprise.DictionaryConsultants[consultantname];
                            manager.AddConsultant(consultant);
                        }
                    }
                    catch
                    {
                        String msgERROR = "The manager :" + managername + "in the file LinkFile.txt is not find in the Entreprise";
                        Console.WriteLine(msgERROR);
                    }
                }
            }
        }

        public void GenerateClient(String filename)
        {
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
                        this.Entreprise.AddClient(client);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Entreprise
{
    class Generator
    {
        private Entreprise Entreprise;

        public Generator()
        {
            
        }


        public Entreprise GenerateAll(String entreprise, DateTime date)
        {
            this.Entreprise = new Entreprise(entreprise, date);
            this.GenerateEmploye("EmployeFile.txt");
            this.LinkConsultantandManager("LinkFile.txt");
            this.GenerateClient("ClientFile.txt");
            this.GenerateMission("MissionFile.txt");
            return this.Entreprise;
        }
        // Method to generate the lists of the entreprise

        private void GenerateEmploye(String filename)
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

        private void GenerateMission(String filename)
        {
            Dictionary<String, List<Mission>> consultantagenda = new Dictionary<String, List<Mission>>();
            File missionfile = new File(filename);
            // Extract each line of the file
            foreach (string c in missionfile.Load)
            {
                Regex rg = new Regex(@"^(?<consultant>[a-zA-Z]+)/(?<datein>+)/(?<dateout>+)/(?<client>\w+)$");
                Match m = rg.Match(c);
                if (m.Success)
                {
                    Consultant consultant = this.Entreprise.GetConsultants[m.Groups["consultant"].Value];
                    Client client = this.Entreprise.GetClients[m.Groups["client"].Value];


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

                    if ( consultantagenda.ContainsKey(m.Groups["consultant"].Value)) // if key in dictionary 
                    {
                        consultantagenda[m.Groups["consultant"].Value].Add(mission);
                    }
                    else
                    {
                        List<Mission> listmission = new List<Mission>();
                        listmission.Add(mission);
                        consultantagenda[m.Groups["consultant"].Value] = listmission;
                    }

                    foreach(String manager in this.Entreprise.GetManagers.Keys)
                    {
                        foreach(string consu in consultantagenda.Keys)
                        {
                            if (this.Entreprise.GetManagers[manager].GetConsultants().ContainsKey(consu))
                            {
                                this.Entreprise.GetManagers[manager].AddConsultantmissions(consultantagenda[consu], consu);
                            }
                        }
                    }
                }
            }
        }

        private void LinkConsultantandManager(String filename)
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
                        Manager manager = this.Entreprise.GetManagers[managername];
                        string[] consultants = m.Groups["consultantslist"].Value.Split('-');
                        foreach (String consultantname in consultants)
                        {
                            Consultant consultant = this.Entreprise.GetConsultants[consultantname];
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

        private void GenerateClient(String filename)
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

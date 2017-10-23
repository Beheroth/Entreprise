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

        public List<Dictionary<String,Object>> GenerateEmploye(String filename)
        {
            List<Dictionary<String,Object>> result = new List<Dictionary<String, Object>>();
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
                        Dictionary<String, List<Consultant>> consultants = new Dictionary<string, List<Consultant>>();
                        List<Consultant> list = new List<Consultant>();
                        consultants["consultant"] = list;

                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        Consultant consultant = new Consultant(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        consultants["consultant"].Add(consultant);
                    }

                    // Generate the directors
                    if (m.Groups["job"].Value == "director")
                    {
                        Dictionary<String, List<Director>> directors = new Dictionary<string, List<Director>>();
                        List<Director> list = new List<Director>();
                        directors["director"] = list;

                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        Director director = new Director(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        directors["director"].Add(director);
                    }
                    if (m.Groups["job"].Value == "financialdirector")
                    {
                        Dictionary<String, List<Director>> directors = new Dictionary<string, List<Director>>();
                        List<Director> list = new List<Director>();
                        directors["director"] = list;

                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        FinancialDirector director = new FinancialDirector(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        directors["financialdirector"].Add(director);
                    }
                    if (m.Groups["job"].Value == "humanresourcesdirector")
                    {
                        Dictionary<String, List<Director>> directors = new Dictionary<string, List<Director>>();
                        List<Director> list = new List<Director>();
                        directors["director"] = list;

                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        HumanResourcesDirector director = new HumanResourcesDirector(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        directors["humanressourcesdirector"].Add(director);
                    }

                    // Generate the managers
                    if (m.Groups["job"].Value == "manager")
                    {
                        Dictionary<String, List<Manager>> managers = new Dictionary<string, List<Manager>>();
                        List<Manager> list = new List<Manager>();
                        managers["manager"] = list;

                        int pa = Int32.Parse(m.Groups["personalaccount"].Value);
                        Manager manager = new Manager(m.Groups["firstname"].Value, m.Groups["lastname"].Value, pa);
                        managers["manager"].Add(manager);
                    }
                }
            }
            return result;
        }

        public List<Mission> GenerateMission(String filename)
        {
            List<Mission> result = new List<Mission>();
            File missionfile = new File(filename);
            // Extract each line of the file
            foreach (string c in missionfile.Load)
            {
                Regex rg = new Regex(@"^(?<consultant>[a-zA-Z]+)/(?<datein>+)/(?<dateout>+)/(?<client>\w+)$");
                Match m = rg.Match(c);
                if (m.Success)
                {
                    String consultant = m.Groups["consultant"].Value;
                    String client = m.Groups["client"].Value;
                    // find a way to match the string and the object

                    // Generate time in
                    string[] datein = m.Groups["datein"].Value.Split('-'); // format date year-monht-day
                    DateTime In = new DateTime();
                    In.AddYears(Int32.Parse(datein[0]));
                    In.AddMonths(Int32.Parse(datein[1]));
                    In.AddDays(Int32.Parse(datein[2]));

                    // Generate time out
                    string[] dateout = m.Groups["datein"].Value.Split('-'); // format date year-monht-day
                    DateTime Out = new DateTime();
                    Out.AddYears(Int32.Parse(dateout[0]));
                    Out.AddMonths(Int32.Parse(dateout[1]));
                    Out.AddDays(Int32.Parse(dateout[2]));

                    // find consultant in file
                    // create consultantagenda type: Dictionary<String, List<Mission>>
                    // mission type: <datetimestart, datetimeend, client>

                    // find his manager
                    // add consultant agenda to the manager
                }
            }
            return result;
        }

        public List<Dictionary<String, Mission>> LinkConsultantandManager(String filename)
        {
            List<Dictionary<String, Mission>> result = new List<Dictionary<string, Mission>>();
            File linkfile = new File(filename);
            // Extract each line of the file
            foreach (string l in linkfile.Load)
            {
                Regex rg = new Regex(@"^(?<manager>[a-zA-Z])/(?<consultantslist>\w)$");
                Match m = rg.Match(l);
                if (m.Success)
                {
                    String manager = m.Groups["manager"].Value;
                    // find the manager via a string
                    string[] consultants = m.Groups["consultantslist"].Value.Split('.');
                    foreach(String c in consultants)
                    {
                        // find the consultant whith a string
                        // connect it to the manager
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

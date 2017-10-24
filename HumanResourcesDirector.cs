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

        public override void GenerateReport(Entreprise entreprise)
        {
            String name = "HR Report" + " - " + this.ToString() + ".txt";
            File HRDReport = new File(name);
            String txt = "";
            Dictionary<Client, List<List<String>>> data = new Dictionary<Client, List<List<String>>>();
            foreach (Consultant consultant in entreprise.GetConsultants().Values)
            {
                foreach (Mission mission in consultant.GetMissionHistory())
                {
                    Client client = mission.GetClient();
                    List<String> info = new List<String>();
                    info.Add(consultant.ToString());
                    info.Add(mission.GetStart().ToString());
                    info.Add(mission.GetEnd().ToString());
                    data[client].Add(info);
                }
            }
            foreach(Client client in data.Keys)
            {
                txt += client.ToString();
                txt += Environment.NewLine;
                txt += Environment.NewLine;

                foreach(List<String> mission in data[client])
                {
                    txt += mission.ToString();
                    txt += Environment.NewLine;
                }
            }
            HRDReport.SaveFile(txt);
        }
    }

}

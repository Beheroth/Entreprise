using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class Consultant : Person
    {
        private Mission Mission;
        private List<Mission> MissionHistory; //Sorted List of All the missions the consultant has done or is doing.

        public Consultant(String firstname, String lastname, int personnalaccount) : base(firstname, lastname, personnalaccount)
        {
            this.MissionHistory = new List<Mission>();
        }

        //getter-setter

                //BEWARE OF SHALLOW COPIES!

        public Mission GetMission()
        {
            return this.Mission;
        }

        public List<Mission> GetMissionHistory()
        {
            return this.MissionHistory;
        }

        public void SetMission(Mission mission)
        {
            this.Mission = mission;
        }

        public void SetMissionHistory(List<Mission> var)
        {
            this.MissionHistory = var;
            this.MissionHistory.OrderBy(x => x.GetStart());
        }


        //methods


        public List<Mission> GetMissionsFromYear(DateTime date)
        {
            List<Mission> ans = new List<Mission>();
            foreach(Mission mission in this.GetMissionHistory())
            {
                if(mission.GetEnd().Year == date.Year)
                {
                    ans.Add(mission);
                }
            }
            return ans;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class Consultant : Person
    {
        private List<Mission> Missionagenda;
        private List<Mission> MissionHistory; //Sorted List of All the missions the consultant has done or is doing.

        public Consultant(String firstname, String lastname, int personnalaccount) : base(firstname, lastname, personnalaccount)
        {
            this.Missionagenda = new List<Mission>();
            this.MissionHistory = new List<Mission>();
        }

        //getter-setter

                //BEWARE OF SHALLOW COPIES!

        public List<Mission> GetMissionagenda()
        {
            return this.Missionagenda;
        }

        public List<Mission> GetMissionHistory()
        {
            return this.MissionHistory;
        }

        public void SetMissionagenda(List<Mission> var)
        {
            //assert that foo is of length 1
            this.Missionagenda = var;
        }

        public void SetMissionHistory(List<Mission> var)
        {
            this.MissionHistory = var;
            this.MissionHistory.Sort();
        }


        //methods

        public void AddMission(Mission mission)
        {
            //assert that mission agenda is empty
            this.Missionagenda.Add(mission);
            //assert that mission is not overlapping with any mission in missionhistory
            this.MissionHistory.Add(mission);
            this.MissionHistory.Sort();
        }

        public void ClearMissionagenda()
        {
            this.Missionagenda.Clear();
        }

        public List<Mission> GetMissionsFromDate(DateTime date)
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
        public void CheckIsBusy(DateTime date)
            //updates the Missionagenda list if the given date is after the end of the mission in missionagenda
        {
            bool ans = false;
            if(this.Missionagenda.Count == 1)
            {
                if(this.Missionagenda[0].GetEnd().CompareTo(date) < 0)
                {
                    ans = true;
                }
            }
            if(ans == false)
            {
                this.ClearMissionagenda();
            }
        }
    }
}

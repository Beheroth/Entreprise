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

        public Consultant(String firstname, String lastname, int personnalaccount) : base(firstname, lastname, personnalaccount)
        {
            this.Missionagenda = new List<Mission>();
        }

        //getter-setter

        public List<Mission> GetMissionagenda()
        {
            return this.Missionagenda;
        }

        public void SetMissionagenda(List<Mission> foo)
        {
            this.Missionagenda = foo;
        }

        //methods

        public void AddMission(Mission Mission)
        {
            //assert that mission agenda is empty
            this.Missionagenda.Add(Mission);
        }

        public void ClearMissionagenda()
        {
            this.Missionagenda.Clear();
        }

        public void CheckIsBusy(DateTime date)
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

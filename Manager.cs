using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class Manager : Person
    {
        private Dictionary<String, Consultant> Consultants;
        private Dictionary<String, List<Mission>> Consultantagenda;   //historique des missions

        public Manager(String firstname, String lastname, int personnalaccount) : base(firstname, lastname, personnalaccount)
        {
            this.Consultants = new Dictionary<String, Consultant>();
        }

        //Getter - Setter

        public Dictionary<String, Consultant> GetConsultants()
        {
            return this.Consultants;
        }

        public Dictionary<String, List<Mission>> GetConsultantagenda()
        {
            return this.Consultantagenda;
        }

        // Method

        public void AddConsultant(Consultant consultant)
        {
            //Assert that consultant is not already contained in Consultantdict
            //BEWARE: Currently Shallow copy of consultant object=> can create problems!!!
            this.Consultants.Add(consultant.GetFirstname() + consultant.GetLastname(), consultant);
        }

        public void RemoveConsultant(String id)
        {
            //assert that id exist before removing
            if (this.Consultants.ContainsKey(id))
            {
                this.Consultants.Remove(id);
            }

        }

        public void LoadConsultantdict(Dictionary<String, Consultant> consultantdict)
        {
            this.Consultants = consultantdict;
        }

        public void LoadConsultantagenda(Dictionary<String, List<Mission>> consultantagenda)
        {
            this.Consultantagenda = consultantagenda;
        }

        public int NumberConsultant()
        {
            //See how many Consultant are under the manager (getter)
            return this.Consultants.Count;
        }

        public void GenerateReport()
        {
            //TODO
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class Manager : Person
    {
        private Dictionary<String, Consultant> Consultantdict;
        private Dictionary<String, List<Mission>> Consultantagenda;

        public Manager(String firstname, String lastname, int personnalaccount) : base(firstname, lastname, personnalaccount)
        {
            this.Consultantdict = new Dictionary<String, Consultant>();
        }

        // Method

        public void AddConsultant(Consultant consultant)
        {
            //Assert that consultant is not already contained in Consultantdict
            //BEWARE: Currently Shallow copy of consultant object=> can create problems!!!
            this.Consultantdict.Add(consultant.GetFirstname() + consultant.GetLastname(), consultant);
        }

        public void RemoveConsultant(String id)
        {
            //assert that id exist before removing
            if (this.Consultantdict.ContainsKey(id))
            {
                this.Consultantdict.Remove(id);
            }

        }

        public void LoadConsultantdict(Dictionary<String, Consultant> consultantdict)
        {
            this.Consultantdict = consultantdict;
        }

        public void LoadConsultantagenda(Dictionary<String, List<Mission>> consultantagenda)
        {
            this.Consultantagenda = consultantagenda;
        }

        private int NumberConsultant()
        {
            //See how many Consultant are under the manager (getter)
            return this.Consultantdict.Count;
        }

        public override void GetPaid()
        {
            this.SetPersonnalaccount(this.GetPersonnalaccount() +
                this.GetSalary());
        }

        public int GetSalary()
        {
            return 60000 + 500 * this.NumberConsultant();
        }
        public void GenerateRapport()
        {

        }
    }
}


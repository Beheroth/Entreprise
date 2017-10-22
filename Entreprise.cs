using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class Entreprise
    {
        private string Name;
        private Dictionary<string, Director> Directors;
        private Dictionary<string, Manager> Managers;
        private Dictionary<string, Consultant> Consultants;
        private Dictionary<string, Client> Clients;

        public Entreprise(string name)
        {
            this.Name = name;
            this.Directors = new Dictionary<string, Director>();
            this.Managers = new Dictionary<string, Manager>();
            this.Consultants = new Dictionary<string, Consultant>();
            this.Clients = new Dictionary<string, Client>();
        }


        //BEWARE OF THE SHALLOW COPIES!!!

        public void LoadDirectors(Dictionary<String, Director> directors)
        {
            this.Directors = directors;
        }

        public void LoadManagers(Dictionary<String, Manager> managers)
        {
            this.Managers = managers;
        }

        public void LoadConsultants(Dictionary<String, Consultant> consultants)
        {
            this.Consultants = consultants;
        }

        public void LoadClients(Dictionary<String, Client> clients)
        {
            this.Clients = clients;
        }

        //Adding Attributes

        public void AddDirector(Director director)
        {
            this.Directors.Add(director.ToString(), director);
        }

        public void AddManager(Manager manager)
        {
            this.Managers.Add(manager.ToString(), manager);
        }

    }

}

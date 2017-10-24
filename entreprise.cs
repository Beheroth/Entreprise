using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class Entreprise : IClient
    {
        private string Name;
        private Dictionary<string, Director> Directors;
        private Dictionary<string, Manager> Managers;
        private Dictionary<string, Consultant> Consultants;
        private Dictionary<string, Client> Clients;
        private DateTime Date;

        public Entreprise(string name, DateTime date)
        {
            this.Name = name;
            this.Directors = new Dictionary<string, Director>();
            this.Managers = new Dictionary<string, Manager>();
            this.Consultants = new Dictionary<string, Consultant>();
            this.Clients = new Dictionary<string, Client>();
            this.Date = date;
        }

        // getter-setter

        public Dictionary<string, Director> GetDirectors()
            {
                return this.Directors;
            }

        public Dictionary<string, Manager> GetManagers()
            {
                return this.Managers;
            }
        
        public Dictionary<string, Consultant> GetConsultants()
            {
                return this.Consultants;
            }
        
        public Dictionary<string, Client> GetClients()
            {
                return this.Clients;
            }

        public string GetName()
            {
                return this.Name;
            }


        // don't use Loadxxx to generate

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

        public void AddConsultant(Consultant consultant)
        {
            this.Consultants.Add(consultant.ToString(), consultant);
        }

        public void AddClient(Client client)
        {
            this.Clients.Add(client.ToString(), client);
        }

        //method


        //pay 

        public void PayAll()
        {
            this.PayDirectors();
            this.PayManagers();
            this.PayConsultants();
        }

        public void PayDirectors()
        {
            foreach(Director director in this.Directors.Values)
            {
                director.GetPaid(150000);
            }
        }

        public void PayManagers()
        {
            foreach(Manager manager in this.Managers.Values)
            {
                manager.GetPaid(60000 + 500 * manager.NumberConsultant());
            }
        }

        public void PayConsultants()
        {
            foreach (Manager manager in this.Managers.Values)
            {
                foreach(Consultant consultant in manager.GetConsultants().Values)
                {
                    int salary = 35000;
                    int managerbonus = 600 + 5 * manager.NumberConsultant();
                    List<Mission> missionlist = manager.GetConsultantagenda()[consultant.ToString()];
                    int bounty = 0;
                    foreach(Mission mission in missionlist)
                    {
                        if(mission.GetStart().Year == this.Date.Year)
                        {
                            int penalty = -10 * mission.GetDuration();
                            if(mission.GetDuration() > 25)
                            {
                                penalty = -250;
                            }
                            bounty += 250 - penalty;
                        }
                    }
                    consultant.GetPaid(salary + managerbonus + bounty);
                }
            }
        }
        
            //Loop

        public void NextDay()
        {
            DateTime yesterday = this.Date;
            this.Date.AddDays(1);
            foreach(Consultant consultant in Consultants.Values)
            {
                consultant.CheckIsBusy(this.Date);
            }
            if(yesterday.Year != this.Date.Year)
            {
                this.PayAll();
            }
        }
    }

}

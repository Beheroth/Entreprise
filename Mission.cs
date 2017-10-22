using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class Mission
    {
        private DateTime Start;
        private DateTime End;
        private readonly Client Client;

        Mission(DateTime Start, DateTime End, Client Client)
        {
            this.Start = Start;
            this.End = End;
            this.Client = Client;
        }
    }
}

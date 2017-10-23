﻿using System;
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

        public Mission(DateTime Start, DateTime End, Client Client)
        {
            this.Start = Start;
            this.End = End;
            this.Client = Client;
        }

        //Getter - Setter

        public DateTime GetStart()
        {
            return this.Start;
        }

        public DateTime GetEnd()
        {
            return this.End;
        }

        public Client GetClient()
        {
            return this.Client;
        }

        //Methods 

        public int GetDuration()
        {
            return this.End.Subtract(this.Start).Days;
        }
    }
}

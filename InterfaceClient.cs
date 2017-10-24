﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise
{
    class InterfaceClient
    {
        Entreprise Entreprise;

        public InterfaceClient(Entreprise entreprise)
        {
            this.Entreprise = entreprise;
        }

        public void Start()
        {
            Console.WriteLine(this.StringStart());
            this.End();
        }

        private void End()
        {
            Console.WriteLine("Print any key to quit");
            Console.ReadLine();
        }

        private String StringStart()
        {
            String result = "";
            result += Environment.NewLine;
            result += "=======================================================";
            result += Environment.NewLine;
            result += Environment.NewLine;
            result += "Welcome to " + this.Entreprise.GetName() + " Entreprise";
            result += Environment.NewLine;
            result += Environment.NewLine;
            result += this.StringMenu();
            return result;
        }

        private String StringMenu()
        {
            List<String> listchoice = new List<String>
            {
                "Print a ManagerReport",
                "Print a FinacialDirectorReport",
                "Print a HumanRessourceReport"
            };

            String result = "";
            result += "What would you like to do ??";
            result += Environment.NewLine;
            for( int i = 0; i < listchoice.Count; i++)
            {
                result += String.Format("{0}. {1}", i+1, listchoice[i]);
                result += Environment.NewLine;
            }
            result += Environment.NewLine;
            result += String.Format("Type number in the console between 0 and {0}", listchoice.Count);
            return result;
        }

    }
}

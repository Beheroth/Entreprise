using System;
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
            Console.ReadKey();
        }

        private String StringStart()
        {
            String result = "";
            result += "Welcom to " + this.Entreprise.GetName() + " Entreprise";
            result += Environment.NewLine;
            result += Environment.NewLine;
            result += this.StringMenu();
            return result;
        }

        private String StringMenu()
        {
            String result = "";
            result += "What would you like to do ??";
            result += Environment.NewLine;
            result += "1. Print a ManagerReport";
            result += Environment.NewLine;
            result += "2. Print a FinacialDirectorReport";
            result += Environment.NewLine;
            result += "3. Print a HumanRessourceReport";
            result += Environment.NewLine;
            result += Environment.NewLine;
            result += "Type (1,2 or 3) in the console";
            return result;
        }

    }
}

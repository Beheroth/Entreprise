using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entreprise
{
    class File
    {
        public String FileName;
        public String Path;

        public File(String filename)
        {
            this.FileName = filename;
            // All files are in the folder Data
            this.Path = @"Data\" + this.FileName;
        }

        private string[] LoadFile()
        {
            string[] lines = System.IO.File.ReadAllLines(this.Path);
            return lines;
        }

        private void SaveFile(String text)
        {
            System.IO.File.WriteAllText(this.Path, text);
        }

        public Dictionary<String, List<List<String>>> LoadEmployes()
        {
            // Load the file and putt each line in a Table of string
            Dictionary<String, List<List<String>>> result = new Dictionary<String, List<List<String>>>();
            string[] lines = this.LoadFile();
            foreach (string line in lines)
            {
                // Match the lines with a regex to extract the information and stock it in a dictionnary
                Regex rg = new Regex(@"^(?<job>\w+)-(?<firstname>\w+)-(?<lastname>\w+)$");
                Match m = rg.Match(line);
                if (m.Success)
                {
                    List<String> name = new List<String>();
                    name.Add(m.Groups["firstname"].Value);
                    name.Add(m.Groups["lastname"].Value);

                    // Check if the key exist in the Dictionnary
                    if (result.ContainsKey(m.Groups["job"].Value))
                    {
                        result[m.Groups["job"].Value].Add(name);
                    }

                    else
                    {
                        List<List<String>> value = new List<List<String>>();
                        result[m.Groups["job"].Value] = value;
                        result[m.Groups["job"].Value].Add(name);
                    }
                }
            }
            return result;
        }

        public void SaveEmployes(List<List<String>> employes)
        {
            String text = "File with all the employes";
            text += Environment.NewLine;
            foreach(List<String> employe in employes)
            {
                text += employe[0] + '-' + employe[1] + '-' + employe[2];
                text += Environment.NewLine;
            }
            this.SaveFile(text);
        }
    }
}

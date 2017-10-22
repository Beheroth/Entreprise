using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.Path = @"\Data" + this.FileName;

        }
    }
}

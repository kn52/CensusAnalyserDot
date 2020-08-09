using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusAnalyser
{
    interface ICsvHelper
    {
        int readFile(string filePath);
    }
}

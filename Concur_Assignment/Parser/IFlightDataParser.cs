using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concur_Assignment.Parser
{
    public interface IFlightDataParser
    {
        int Type { get; }
        string ParseFlightData(string line);
    }
}

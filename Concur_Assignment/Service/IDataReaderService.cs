using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concur_Assignment.Dto;

namespace Concur_Assignment.Service
{
    public interface IDataReaderService
    {
        Task<List<FlightData>> GetFlightData();
    }
}

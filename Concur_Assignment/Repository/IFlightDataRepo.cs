using Concur_Assignment.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concur_Assignment.Repository
{
    public interface IFlightDataRepo
    {
        Task<List<FlightData>> GetFlightData();
    }
}

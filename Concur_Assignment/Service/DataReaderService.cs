using Concur_Assignment.Dto;
using Concur_Assignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concur_Assignment.Service
{
    public class DataReaderService : IDataReaderService
    {
        private readonly IFlightDataRepo _flightDataRepo;

        public DataReaderService(IFlightDataRepo flightDataRepo)
        {
            _flightDataRepo = flightDataRepo;
        }


        public async Task<List<FlightData>> GetFlightData()
        {
            return  await _flightDataRepo.GetFlightData();
        }
    }
}

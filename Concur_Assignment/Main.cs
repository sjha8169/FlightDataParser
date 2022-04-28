using Concur_Assignment.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concur_Assignment
{
    public class Main
    {
        private readonly IDataReaderService _dataReaderService;
        private readonly ILogger<Worker> _logger;

        public Main(IDataReaderService dataReaderService, ILogger<Worker> logger)
        {
            _dataReaderService = dataReaderService;
            _logger = logger;
        }

        public async void ReadDataAndLog()
        {
           var result = await _dataReaderService.GetFlightData();
            //_logger.LogInformation("Flight Data");
            Console.WriteLine("Flight Data");
            foreach(var row in result)
            {
                // _logger.LogInformation($"{row.LineNumber} {row.Carrier} {row.OperatingCarrier} {row.FlightNumber} {row.Classes} {row.DepartureAirport} {row.ArrivalAirport} {row.DepartureTime} {row.ArrivalTime} {row.ArrivalTimeShift} {row.Equipment} {row.Ontime} {row.Duration} ");
                Console.WriteLine(($"{row.LineNumber} {row.Carrier} {row.OperatingCarrier} {row.FlightNumber} {row.Classes} {row.DepartureAirport} {row.ArrivalAirport} {row.DepartureTime} {row.ArrivalTime} {row.ArrivalTimeShift} {row.Equipment} {row.Ontime} {row.Duration} "));
                
            }
            Console.ReadLine();
        }
    }
}

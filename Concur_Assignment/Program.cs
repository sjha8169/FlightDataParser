using Concur_Assignment.Parser;
using Concur_Assignment.Repository;
using Concur_Assignment.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concur_Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
           .ConfigureServices(ConfigureServices)
           .ConfigureServices(services => services.AddSingleton<Main>())
           .Build()
           .Services
           .GetService<Main>()
           .ReadDataAndLog();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });

        private static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddSingleton<IDataReaderService, DataReaderService>();
            services.AddSingleton<IFlightDataRepo, FlightDataRepo>();
            services.AddSingleton<IFlightDataParser, LineNumberParser>();
            services.AddSingleton<IFlightDataParser, CarrierParser>();
            services.AddSingleton<IFlightDataParser, OperatingCarrierParser>();
            services.AddSingleton<IFlightDataParser, FlightNumberParser>();
            services.AddSingleton<IFlightDataParser, ClassesParser>();
            services.AddSingleton<IFlightDataParser, DepartureAirportParser>();
            services.AddSingleton<IFlightDataParser, ArrivalAirportParser>();
            services.AddSingleton<IFlightDataParser, DepartureTimeParser>();
            services.AddSingleton<IFlightDataParser, ArrivalTimeParser>();
            services.AddSingleton<IFlightDataParser, ArrivalTimeShiftParser>();
            services.AddSingleton<IFlightDataParser, EquipmentParser>();
            services.AddSingleton<IFlightDataParser, OntimeParser>();
            services.AddSingleton<IFlightDataParser, DurationParser>();

            services.AddSingleton<Func<int, IFlightDataParser>>(provider => parserType =>
            {
                var instance = provider.GetServices<IFlightDataParser>().First(par => par.Type == parserType);
                return instance;
            });
        }
    }
}

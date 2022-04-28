using Concur_Assignment.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using Concur_Assignment.Parser;
using Microsoft.Extensions.Logging;

namespace Concur_Assignment.Repository
{
    public class FlightDataRepo : IFlightDataRepo
    {
        private readonly ILogger<Worker> _logger;
        private readonly Func<int, IFlightDataParser> _flightDataParser;

        public FlightDataRepo(Func<int, IFlightDataParser> flightDataParser, ILogger<Worker> logger)
        {
            _logger = logger;
            _flightDataParser = flightDataParser;
        }

        public async  Task<List<FlightData>> GetFlightData()
        {
            List<FlightData> flightDatas = new List<FlightData>();
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory() + "\\flightdata.txt");                

                if (File.Exists(filePath))
                {
                    string[] lines = await File.ReadAllLinesAsync(filePath);

                    foreach (var line in lines)
                    {
                        var flightData = new FlightData
                        {
                            LineNumber = _flightDataParser((int)FlightDataEnum.LineNumber).ParseFlightData(line),
                            Carrier = _flightDataParser((int)FlightDataEnum.Carrier).ParseFlightData(line),
                            OperatingCarrier = _flightDataParser((int)FlightDataEnum.OperatingCarrier).ParseFlightData(line),
                            FlightNumber = _flightDataParser((int)FlightDataEnum.FlightNumber).ParseFlightData(line),
                            Classes = _flightDataParser((int)FlightDataEnum.Classes).ParseFlightData(line),
                            DepartureAirport = _flightDataParser((int)FlightDataEnum.DepartureAirport).ParseFlightData(line),
                            ArrivalAirport = _flightDataParser((int)FlightDataEnum.ArrivalAirport).ParseFlightData(line),
                            DepartureTime = _flightDataParser((int)FlightDataEnum.DepartureTime).ParseFlightData(line),
                            ArrivalTime = _flightDataParser((int)FlightDataEnum.ArrivalTime).ParseFlightData(line),
                            ArrivalTimeShift = _flightDataParser((int)FlightDataEnum.ArrivalTimeShift).ParseFlightData(line),
                            Equipment = _flightDataParser((int)FlightDataEnum.Equipment).ParseFlightData(line),
                            Ontime = _flightDataParser((int)FlightDataEnum.Ontime).ParseFlightData(line),
                            Duration = _flightDataParser((int)FlightDataEnum.Duration).ParseFlightData(line)
                        };


                        #region Test
                        //Match m1 = Regex.Match(line.Trim(), @"^\d+");
                        //flightData.LineNumber = m1.Success ? m1.Value : "0";

                        //Match m21 = Regex.Match(line.Trim(), @"\s[A-Z]{2}\s");
                        //Match m22 = Regex.Match(line.Trim(), @"[A-Z]{2}:");
                        //if (m21.Success)
                        //{
                        //    flightData.Carrier = m21.Value.Trim();
                        //}
                        //else if (m22.Success)
                        //{
                        //    flightData.Carrier = m22.Value.Trim().Substring(0,2);
                        //}
                        //else
                        //{
                        //    flightData.Carrier = string.Empty;
                        //}

                        //Match m31 = Regex.Match(line.Trim(), @":[A-Z]{2}");
                        //Match m32 = Regex.Match(line.Trim(), @"\s[A-Z]{2}\d");
                        //if (m31.Success)
                        //{
                        //    flightData.OperatingCarrier = m31.Value.Substring(1, 2);
                        //}
                        //else if (m32.Success)
                        //{
                        //    flightData.OperatingCarrier = m32.Value.Trim().Substring(0,2);
                        //}
                        //else
                        //{
                        //    flightData.OperatingCarrier = string.Empty;
                        //}

                        //Match m41 = Regex.Match(line.Trim(), @"[A-Z]{2}(\d{4})");
                        //Match m42 = Regex.Match(line.Trim(), @"\s(\d{3})\s");
                        //if (m41.Success)
                        //{
                        //    flightData.FlightNumber = m41.Value.Substring(2, 4);
                        //}
                        //else if (m42.Success)
                        //{
                        //    flightData.FlightNumber = m42.Value.Trim();
                        //}
                        //else
                        //{
                        //    flightData.FlightNumber = string.Empty;
                        //}

                        //var m5 = Regex.Matches(line.Trim(), @"([A-Z]{1}\d{1})\s");
                        //if (m5 != null)
                        //{
                        //    StringBuilder stringBuilder = new StringBuilder();
                        //    foreach (Match match in m5)
                        //    {
                        //        stringBuilder.Append(match.Value?.Trim()?.Substring(0, 1));
                        //    }
                        //    flightData.Classes = stringBuilder.ToString();
                        //}

                        //var m6 = Regex.Matches(line.Trim(), @"[A-Z]{3}");
                        //if(m6 != null && m6.Any())
                        //{
                        //    flightData.DepartureAirport = m6.Count > 0 ? m6.First().Value : "";
                        //    flightData.ArrivalAirport = m6.Count > 1 ? m6.Last().Value : "";
                        //}

                        //var m7 = Regex.Matches(line.Trim(), @"\s\d{4}");
                        //if (m7 != null && m7.Any())
                        //{
                        //    flightData.DepartureTime = m7.Count > 0 ? m7.First().Value.Trim() : "";
                        //    flightData.ArrivalTime = m7.Count > 1 ? m7.Last().Value.Trim() : "";
                        //}

                        //Match m8 = Regex.Match(line.Trim(), @"[+|-]\d");
                        //flightData.ArrivalTimeShift = m8.Success ? m8.Value : string.Empty;

                        //Match m9 = Regex.Match(line.Trim(), @"E0[.|/][A-Z0-9]{3}");
                        //flightData.Equipment = m9.Success ? m9.Value.Substring(3, m9.Value.Length - 3) : string.Empty;

                        //Match m10 = Regex.Match(line.Trim(), @"(([0-9]+\s+)|(\s[A-Z]{1}\s+))(\d:\d{2})");
                        //flightData.Ontime = (m10.Groups[1].Success && m10.Groups[1].Value.Trim().Length == 1) ? m10.Groups[1].Value.Trim() : "";
                        //flightData.Duration = m10.Groups[4].Success ? m10.Groups[4].Value.Trim() : "";
                        #endregion

                        flightDatas.Add(flightData);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }


            return flightDatas;
        }
    }
}

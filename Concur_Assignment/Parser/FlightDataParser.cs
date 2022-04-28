using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Concur_Assignment.Parser
{
    public class LineNumberParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.LineNumber;

        public string ParseFlightData(string line)
        {
            Match m1 = Regex.Match(line.Trim(), @"^\d+");
            return m1.Success ? m1.Value : "0";
        }
    }

    public class CarrierParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.Carrier;

        public string ParseFlightData(string line)
        {
            Match m21 = Regex.Match(line.Trim(), @"\s[A-Z]{2}\s");
            Match m22 = Regex.Match(line.Trim(), @"[A-Z]{2}:");
            if (m21.Success)
            {
                return m21.Value.Trim();
            }
            else if (m22.Success)
            {
                return m22.Value.Trim().Substring(0, 2);
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class OperatingCarrierParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.OperatingCarrier;

        public string ParseFlightData(string line)
        {
            Match m31 = Regex.Match(line.Trim(), @":[A-Z]{2}");
            Match m32 = Regex.Match(line.Trim(), @"\s[A-Z]{2}\d");
            if (m31.Success)
            {
                return m31.Value.Substring(1, 2);
            }
            else if (m32.Success)
            {
                return m32.Value.Trim().Substring(0, 2);
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class FlightNumberParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.FlightNumber;

        public string ParseFlightData(string line)
        {
            Match m41 = Regex.Match(line.Trim(), @"[A-Z]{2}(\d{4})");
            Match m42 = Regex.Match(line.Trim(), @"\s(\d{3})\s");
            if (m41.Success)
            {
                return m41.Value.Substring(2, 4);
            }
            else if (m42.Success)
            {
                return m42.Value.Trim();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class ClassesParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.Classes;

        public string ParseFlightData(string line)
        {
            var m5 = Regex.Matches(line.Trim(), @"([A-Z]{1}\d{1})\s");
            if (m5 != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (Match match in m5)
                {
                    stringBuilder.Append(match.Value?.Trim()?.Substring(0, 1));
                }
                return stringBuilder.ToString();
            }
            return string.Empty;
        }
    }

    public class DepartureAirportParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.DepartureAirport;

        public string ParseFlightData(string line)
        {
            var m6 = Regex.Matches(line.Trim(), @"[A-Z]{3}");
            if (m6 != null && m6.Any())
            {
                return m6.Count > 0 ? m6.First().Value : "";                
            }
            return string.Empty;
        }
    }

    public class ArrivalAirportParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.ArrivalAirport;

        public string ParseFlightData(string line)
        {
            var m6 = Regex.Matches(line.Trim(), @"[A-Z]{3}");
            if (m6 != null && m6.Any())
            {                
                return m6.Count > 1 ? m6.Last().Value : "";
            }
            return string.Empty;
        }
    }

    public class DepartureTimeParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.DepartureTime;

        public string ParseFlightData(string line)
        {
            var m7 = Regex.Matches(line.Trim(), @"\s\d{4}");
            if (m7 != null && m7.Any())
            {
                return m7.Count > 0 ? m7.First().Value.Trim() : "";
            }
            return string.Empty;
        }
    }

    public class ArrivalTimeParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.ArrivalTime;

        public string ParseFlightData(string line)
        {
            var m7 = Regex.Matches(line.Trim(), @"\s\d{4}");
            if (m7 != null && m7.Any())
            {
                return m7.Count > 1 ? m7.Last().Value.Trim() : "";
            }
            return string.Empty;
        }
    }

    public class ArrivalTimeShiftParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.ArrivalTimeShift;

        public string ParseFlightData(string line)
        {
            Match m8 = Regex.Match(line.Trim(), @"[+|-]\d");
            return m8.Success ? m8.Value : string.Empty;
        }
    }

    public class EquipmentParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.Equipment;

        public string ParseFlightData(string line)
        {
            Match m9 = Regex.Match(line.Trim(), @"E0[.|/][A-Z0-9]{3}");
            return m9.Success ? m9.Value.Substring(3, m9.Value.Length - 3) : string.Empty;
        }
    }

    public class OntimeParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.Ontime;

        public string ParseFlightData(string line)
        {
            Match m10 = Regex.Match(line.Trim(), @"(([0-9]+\s+)|(\s[A-Z]{1}\s+))(\d:\d{2})");
            return (m10.Groups[1].Success && m10.Groups[1].Value.Trim().Length == 1) ? m10.Groups[1].Value.Trim() : "";
        }
    }

    public class DurationParser : IFlightDataParser
    {
        public int Type => (int)FlightDataEnum.Duration;

        public string ParseFlightData(string line)
        {
            Match m10 = Regex.Match(line.Trim(), @"(([0-9]+\s+)|(\s[A-Z]{1}\s+))(\d:\d{2})");
            return m10.Groups[4].Success ? m10.Groups[4].Value.Trim() : "";
        }
    }


}

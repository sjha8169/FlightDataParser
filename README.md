# FlightDataParser
Flight Data Parser

This app is written in .net 5. You need to have it installed https://dotnet.microsoft.com/en-us/download/dotnet/5.0
This is a console app which parses the flight data to a C# model object.
You can run it and see the data printed in console or you can put the breakpoint in Main.cs ReadDataAndLog method.
I started by adding dependency injection and configuring the app for it. Then I added DataReaderService file which is called in the main class thru dependency injection. This service file has
FlightDataRepo injected. I created an interface IFlightDataParser and created classes that inherit from it. These parser classes are point to each fields, i.e., linenumber, carrier, etc., that needs to be parsed.
Each parser classes that implement IFlightDataParser's ParseFlightData method has regular expression to parse needed data out of line received from text file.
The architecture is based on SOLID principle. Each unit can be easily tested or replace if needed. Parser classes be easily replaced by different implementation without impacting FlightDataRepo.
Right now DataReaderService is reading from text file. This implemnetation can be switched to reading from database or any data store.
It took me 4 hours, roughly, to build this app. I have spend almost 3 hours trying to get the regular expression correct. I took the help of an online tool https://regexr.com/
and Regular expression quick reference document to build regular expression for each field. 

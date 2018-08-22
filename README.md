# Serilog ASP.NET Core Implementations
Like many other libraries for .NET, Serilog provides diagnostic logging to files, the console, and elsewhere. It is easy to set up, has a clean API, and is portable between recent .NET platforms.  Unlike other logging libraries, Serilog is built with powerful structured event data in mind.  <br />



### For MSSQL
Install-Package Serilog.AspNetCore -Version 2.1.1  <br />
Install-Package Serilog.Settings.Configuration -Version 2.6.1  <br />
Install-Package Serilog.Sinks.MSSqlServer -Version 5.1.2 <br />


### FileSinks
Install-Package Serilog.AspNetCore -Version 2.1.1  <br />
Install-Package Serilog.Settings.Configuration -Version 2.6.1   <br />
Install-Package Serilog.Sinks.File -Version 4.0.0 <br />




### In .NET platform, there are multiple matured logging frameworks such as:
Log4Net(http://logging.apache.org/log4net/)   <br />
nLog(http://nlog-project.org/)    <br />
CommonLogging(http://netcommon.sourceforge.net/)   <br />
ObjectGuy(http://www.theobjectguy.com/dotnetlog/)   <br />
ELMAH(https://code.google.com/p/elmah/)  <br />

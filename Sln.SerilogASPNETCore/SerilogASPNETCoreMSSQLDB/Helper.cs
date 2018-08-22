using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace SerilogASPNETCoreMSSQLDB
{
    public static class Helper
    {
        public static void CreateMSSqlLogger(string connectionString)
        {
            try
            {              
                var tableName = "Logs";

                var columnOption = new ColumnOptions();
                //columnOption.Store.Remove(StandardColumn.MessageTemplate);

                columnOption.AdditionalDataColumns = new Collection<DataColumn>
                            {
                                new DataColumn {DataType = typeof (string), ColumnName = "OtherData"},
                            };

                Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Information()
                                .MinimumLevel.Override("SerilogDemo", LogEventLevel.Information)
                                .WriteTo.MSSqlServer(connectionString, tableName,
                                        columnOptions: columnOption

                                        )
                                .CreateLogger();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void CreateMSSqlLoggerUsingJSONFile()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

    }
}

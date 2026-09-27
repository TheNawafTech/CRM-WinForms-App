using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsDataAccessSettings
{
    static public class ClsDataAcessSettings
    {
        // Name of the <connectionStrings> entry in the application's App.config (CRM.exe.config).
        public const string ConnectionStringName = "CRMproject";

        // Read from the application's configuration file; there is deliberately no built-in fallback.
        // A missing or empty entry is a setup error. It surfaces through the business layer as a Failure,
        // and the message does not include the connection string.
        static public string ConnectingCRMproject
        {
            get
            {
                ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings[ConnectionStringName];

                if (setting == null || string.IsNullOrWhiteSpace(setting.ConnectionString))
                {
                    throw new ConfigurationErrorsException(
                        $"The connection string '{ConnectionStringName}' is missing or empty in the application configuration file.");
                }

                return setting.ConnectionString;
            }
        }
    }
}

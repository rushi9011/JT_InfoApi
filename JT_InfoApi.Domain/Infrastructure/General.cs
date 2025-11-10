using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT_InfoApi.Domain.Infrastructure
{
    public static class General
    {
        public static string ConnectionBuilder()
        {
            try
            {
                var connectionString = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost",
                    InitialCatalog = "JT_Information",
                    IntegratedSecurity = true,
                    TrustServerCertificate = true
                };

                return connectionString.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while building connection string", ex);
            }
        }

    }
}

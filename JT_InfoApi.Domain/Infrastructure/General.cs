using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

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

        public static bool EatPork(string clientCode, string soup, ILogger logger)

        {

            try

            {

                if (soup == Encrypt(clientCode, logger))

                {

                    return true;

                }

                else

                {

                    return false;

                }

            }

            catch (Exception ex)

            {

                logger.LogError(ex.Message);

                return false;

            }

        }

        private static string Encrypt(string clientCode, ILogger logger, string key = "jt74")

        {

            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

            if (clientCode.Length == 0 || clientCode == "")

            {

                return "";

            }

            try

            {

                DES.Key = MD5.ComputeHash(Encoding.ASCII.GetBytes(key));

                DES.Mode = CipherMode.ECB;

                byte[] buffer = Encoding.ASCII.GetBytes(clientCode);

                return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));

            }

            catch (Exception ex)

            {

                logger.LogError(ex.Message);
                return "";

            }

        }

    }
}

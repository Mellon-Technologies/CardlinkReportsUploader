using System;
using System.IO;
using NLog;
using Renci.SshNet;
using Sentry;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using System.Text;
using MtmsLibrary.Database;
using System.Collections.Generic;

namespace CardlinkReportsFtpUpload
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            SentrySdk.Init(o =>
            {
                // Tells which project in Sentry to send events to:
                o.Dsn = Properties.Settings.Default.SentryDSN;
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = Properties.Settings.Default.SentryDebug;
                // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                o.TracesSampleRate = Properties.Settings.Default.SentryTracesSampleRate;
            });
            {
                try
                {
                    Report();

                    DateTime thisDay = DateTime.Today;

                    //Path for CARDLINK_ISSUER_INFORMATION csv
                    string CardlinkIssuerInformationPath = $"{Properties.Settings.Default.PathToSaveCsv}CARDLINK_ISSUER_INFORMATION{thisDay.ToString("ddMMyyyy")}.csv";
                    string ftpPathToUploadIssuerInformation = $"{Properties.Settings.Default.FtpPathToUpload}CARDLINK_ISSUER_INFORMATION{thisDay.ToString("ddMMyyyy")}.csv";
                    //Path for CARDLINK_AVAC_INFORMATION csv
                    string CardlinkAvacInformationPath = $"{Properties.Settings.Default.PathToSaveCsv}CARDLINK_AVAC_INFORMATION{thisDay.ToString("ddMMyyyy")}.csv";
                    string ftpPathToUploadAvacInformation = $"{Properties.Settings.Default.FtpPathToUpload}CARDLINK_AVAC_INFORMATION{thisDay.ToString("ddMMyyyy")}.csv";
                    //Path for CARDLINK_MTMS_INGENICO csv
                    string CardlinkMtmsIngenicoPath = $"{Properties.Settings.Default.PathToSaveCsv}CARDLINK_MTMS_INGENICO{thisDay.ToString("ddMMyyyy")}.csv";
                    string ftpPathToUploadMtmsIngenico = $"{Properties.Settings.Default.FtpPathToUpload}CARDLINK_MTMS_INGENICO{thisDay.ToString("ddMMyyyy")}.csv";

                    var connectionInfo = new ConnectionInfo(Properties.Settings.Default.FtpAddress,
                                            Properties.Settings.Default.FtpUser,
                                            new PasswordAuthenticationMethod(Properties.Settings.Default.FtpUser, Properties.Settings.Default.FtpPassword));
                    connectionInfo.Timeout = new TimeSpan(0, 5, 0);

                    //Check if file  CARDLINK_ISSUER_INFORMATION csv exists and uploads it
                    if (File.Exists(CardlinkIssuerInformationPath))
                    {
                        using (var client = new SftpClient(connectionInfo))
                        {
                            client.Connect();
                            var fileStream = File.OpenRead(CardlinkIssuerInformationPath);
                            client.UploadFile(fileStream, ftpPathToUploadIssuerInformation);
                        }
                    }
                    else
                    {
                        SentrySdk.CaptureMessage("file not found in "+ CardlinkIssuerInformationPath);
                        logger.Error($"file not found in {CardlinkIssuerInformationPath}");
                        Helper.SendEmail("file CardlinkIssuerInformation that should be created at 5:30 was not found in " + CardlinkIssuerInformationPath);
                    }

                    //Check if file  CARDLINK_AVAC_INFORMATION csv exists and uploads it
                    if (File.Exists(CardlinkAvacInformationPath))
                    {
                        using (var client = new SftpClient(connectionInfo))
                        {
                            client.Connect();
                            var fileStream = File.OpenRead(CardlinkAvacInformationPath);
                            client.UploadFile(fileStream, ftpPathToUploadAvacInformation);
                        }
                    }
                    else
                    {
                        SentrySdk.CaptureMessage("file not found in " + CardlinkAvacInformationPath);
                        logger.Error($"file not found in {CardlinkAvacInformationPath}");
                        Helper.SendEmail("file CardlinkAvacInformation that should be created at 5:30 was not found in " + CardlinkAvacInformationPath);
                    }


                    //Check if file CARDLINK_MTMS_INGENICO csv exists and uploads it
                    if (File.Exists(CardlinkMtmsIngenicoPath))
                    {
                        using (var client = new SftpClient(connectionInfo))
                        {
                            client.Connect();
                            var fileStream = File.OpenRead(CardlinkMtmsIngenicoPath);
                            client.UploadFile(fileStream, ftpPathToUploadMtmsIngenico);
                        }
                    }
                    else
                    {
                        SentrySdk.CaptureMessage("file not found in " + CardlinkMtmsIngenicoPath);
                        logger.Error($"file not found in {CardlinkMtmsIngenicoPath}");
                        Helper.SendEmail("file CardlinkMtmsIngenico that should be created at 5:30 was not found in " + CardlinkMtmsIngenicoPath );
                    }


                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                    logger.Error(ex, null);
                    Helper.SendEmail(ex.ToString());
                }
            }
        }

        public static void Report()
        {
            try
            {

                DbContext connection = new DbContext(Properties.Settings.Default.ConnectionString);
                string sqlQuery = $"select TRANSACTIONS_DATE,HOST_REQUEST_TIME,POS_TERMINALID,POS_MERCHANTID from BW3.STATS_LOGGING where POS_OWNERBANKID=394 and POS_AUTH_RESULT='OK' " +
                    $"and TO_DATE( SUBSTR (TRANSACTIONS_DATE, 0, 6) || '20' || SUBSTR (TRANSACTIONS_DATE, 7, 2) || HOST_REQUEST_TIME, 'DD/MM/YYYYHH24:MI:SS') <= SYSDATE " +
                    $"and TO_DATE( SUBSTR (TRANSACTIONS_DATE, 0, 6) || '20' || SUBSTR (TRANSACTIONS_DATE, 7, 2) || " +
                    $"HOST_REQUEST_TIME, 'DD/MM/YYYYHH24:MI:SS')  > = SYSDATE-({Properties.Settings.Default.StartHourReport}) ORDER BY TO_DATE( SUBSTR (TRANSACTIONS_DATE, 0, 6) || '20' || SUBSTR (TRANSACTIONS_DATE, 7, 2) || HOST_REQUEST_TIME, 'DD/MM/YYYYHH24:MI:SS') ASC";
                OracleDataReader reader = connection.GetData(sqlQuery);
                List<string> CsvData = new List<string>();
                string CsvFirstLine = @"""TRANSACTIONS_DATE""  ""HOST_REQUEST_TIME""  ""POS_TERMINALID""  ""POS_MERCHANTID""";

                CsvData.Add(CsvFirstLine);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var report = AddToList(reader);
                        CsvData.Add(report);
                    }
                }
                else
                {
                    string report = "No entries";
                    CsvData.Add(report);
                }

                reader.Close();

                DateTime thisDay = DateTime.Today;
                string Path = $"{Properties.Settings.Default.PathToSaveCsv}StatsLogging-{thisDay.ToString("dd-MM-yyyy")}.csv";

                File.WriteAllLines(Path, CsvData, Encoding.UTF8);

                string ftpPathToUpload = $"{Properties.Settings.Default.FtpPathToUpload}StatsLogging-{thisDay.ToString("dd-MM-yyyy")}.csv";

                var connectionInfo = new ConnectionInfo(Properties.Settings.Default.FtpAddress,
                                        Properties.Settings.Default.FtpUser,
                                        new PasswordAuthenticationMethod(Properties.Settings.Default.FtpUser, Properties.Settings.Default.FtpPassword));

                using (var client = new SftpClient(connectionInfo))
                {
                    client.Connect();
                    var fileStream = File.OpenRead(Path);
                    client.UploadFile(fileStream, ftpPathToUpload);
                }

            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                logger.Error(ex, null);
            }
        }


        public static string AddToList(OracleDataReader reader)
        {
            string TransactionsDate = CheckIfDbNull(reader.GetValue(0).ToString());
            string HostRequestTime = CheckIfDbNull(reader.GetValue(1).ToString());
            string PosTerminalId = CheckIfDbNull(reader.GetValue(2).ToString());
            string PosMerchantId = CheckIfDbNull(reader.GetValue(3).ToString());
            string report = @"""" + TransactionsDate + @"""  """ + HostRequestTime + @"""  """ + PosTerminalId + @"""  """ + PosMerchantId + @"""";


            return report;
        }

        public static string CheckIfDbNull(string value)
        {
            if (Convert.IsDBNull(value))
            {
                return string.Empty;
            }
            else
            {
                return value;
            }
        }
    }



}

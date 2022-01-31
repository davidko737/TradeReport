using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeReportUnitTest
{
    public static class TRCsvPath
    {
        private static readonly string CurrDir = Directory.GetCurrentDirectory() + "/Data";

        public static readonly string Broker =  Path.Combine(CurrDir, "Broker.csv");
        public static readonly string Product = Path.Combine(CurrDir, "Product.csv");
        public static readonly string Trade = Path.Combine(CurrDir, "Trade.csv");

        public static string GetOutPath(string productName, string brokerName)
        {
            var fileName = $"{productName}-{brokerName}-" + DateTime.Now.ToString("yyyyMMdd-HHmm") + ".csv";
            return Path.Combine(CurrDir, fileName);
        }
    }
}

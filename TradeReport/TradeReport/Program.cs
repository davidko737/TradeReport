using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;
using TradeReport.Common;
using TradeReport.Entity;
using TradeReport.Helper;
using TradeReport.Repository;

namespace TradeReport
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TRDataHelper.LoadDummyData();

            GenTradeReport();
        }

        private static void GenTradeReport()
        {
            // Assume user has the interface to select product & broker
            // And front-end pass the product and broker object to back-end (this engine)
            //
            var product = new Product();
            product.Name = "IRS";
            product.Id = 3;

            var broker = new Broker();
            broker.Name = "BrokerA";
            broker.Id = 1;

            TRCsvHelper.GenTradeReport(product, broker);
        }
    }
}







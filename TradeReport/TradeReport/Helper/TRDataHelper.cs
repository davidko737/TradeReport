using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeReport.Common;
using TradeReport.Common.Extension;
using TradeReport.Entity;
using TradeReport.Repository;

namespace TradeReport.Helper
{
    public class TRDataHelper
    {
        public static void LoadDummyData()
        {
            using (CsvReader reader = TRCsvHelper.GetReader(TRCsvPath.Broker))
            {
                TRData.Brokers = reader.GetRecords<Broker>().ToList();
                TRData.DictBrokers = TRData.Brokers.Cast<Broker>().ToDictionary(o => o.Id, o => o);
            }
            using (CsvReader reader = TRCsvHelper.GetReader(TRCsvPath.Product))
            {
                TRData.Products = reader.GetRecords<Product>().ToList();
                TRData.DictProducts = TRData.Products.Cast<Product>().ToDictionary(o => o.Id, o => o);
            }
            using (CsvReader reader = TRCsvHelper.GetReader(TRCsvPath.Trade))
            {
                TRData.DerivativesTrades = reader.GetRecords<DerivativesTrade>().ToList();
                TRData.DictTrades = TRData.DerivativesTrades.Cast<DerivativesTrade>().ToDictionary(o => o.Id, o => o);
            }
            AggregateDummyData();
        }

        public static void AggregateDummyData()
        {
            foreach (var (item, idx) in TRData.DerivativesTrades.WithIndex())
            {
                TRData.DerivativesTrades[idx].Broker = TRData.DictBrokers[item.BrokerId];
                TRData.DerivativesTrades[idx].Product = TRData.DictProducts[item.ProductId];
            }
        }
    }
}

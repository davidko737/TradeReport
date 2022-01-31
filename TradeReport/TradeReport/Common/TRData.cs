using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeReport.Entity;

namespace TradeReport.Common
{
    public static class TRData
    {
        public static List<DerivativesTrade> DerivativesTrades;
        public static List<Broker> Brokers;
        public static List<Product> Products;

        // For Fast Access: O(1)
        public static Dictionary<int, DerivativesTrade> DictTrades;
        public static Dictionary<int, Broker> DictBrokers;
        public static Dictionary<int, Product> DictProducts;
    }
}

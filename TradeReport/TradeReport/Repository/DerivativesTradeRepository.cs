using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeReport.Common;
using TradeReport.Entity;

namespace TradeReport.Repository
{
    public class DerivativesTradeRepository : IRepository<DerivativesTrade>
    {
        public List<DerivativesTrade> GetAll()
        {
            return TRData.DerivativesTrades;
        }

        public DerivativesTrade GetBy(int id)
        {
            return TRData.DictTrades[id];
        }

        public List<DerivativesTrade> GetAllFilterBy(int productId, int brokerId)
        {
            List<DerivativesTrade> filtered = TRData.DerivativesTrades
                .Where(x => x.BrokerId == brokerId)
                .Where(x => x.ProductId == productId)
                .ToList();
            return filtered;
        }
    }
}

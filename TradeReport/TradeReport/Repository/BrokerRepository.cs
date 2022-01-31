using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeReport.Common;
using TradeReport.Core.Interface;
using TradeReport.Entity;

namespace TradeReport.Repository
{
    public class BrokerRepository : IRepository<Broker>
    {
        public List<Broker> GetAll()
        {
            return TRData.Brokers;
        }

        public Broker GetBy(int id)
        {
            return TRData.DictBrokers[id];
        }

        public Broker GetBy(string name)
        {
            Broker broker = TRData.Brokers
                .Where(x => x.Name == name)
                .ToList()
                .First();
            return broker;
        }
    }
}

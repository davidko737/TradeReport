using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeReport.Entity
{
    public class Trade: BaseEntity
    {
        public string TradeRef  { get; set; }
        [Format("yyyyMMdd")]
        public DateTime ExecutionDate { get; set; }
        public decimal Qty { get; set; }
        public string BuySell { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }

        // Foreign Keys 
        public int ProductId { get; set; }
        [Ignore]
        public Product Product { get; set; }
        public int BrokerId { get; set; }
        [Ignore]
        public Broker Broker { get; set; }
    }
}

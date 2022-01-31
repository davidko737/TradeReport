using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeReportUnitTest
{
    public class Trade
    {
        public string TradeRef { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal Qty { get; set; }
        public string BuySell { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public int ProductId { get; set; }
        public int BrokerId { get; set; }
        public DateTime Maturity { get; set; }
    }
}

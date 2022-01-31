using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeReport.Entity
{
    public class ReportDTO
    {
        public ReportDTO(DerivativesTrade trade)
        {
            this.TradeRef = trade.TradeRef;
            this.ProductId = trade.ProductId;
            this.ProductName = trade.Product.Name;
            this.Date = trade.ExecutionDate;
            this.Qty = trade.Qty;
            this.BuySell = trade.BuySell;
            this.Price = trade.Price;
            this.BrokerId = trade.BrokerId;
            this.BrokerName = trade.Broker.Name;
            this.Desc = trade.Desc;
            this.Maturity = trade.Maturity;
        }
        public string TradeRef { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BrokerId { get; set; }
        public string BrokerName { get; set; }
        [Format("yyyyMMdd")]
        public DateTime Date { get; set; }
        [Format("yyyyMMdd")]
        public DateTime Maturity { get; set; }
        public decimal Qty { get; set; }
        public string BuySell { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
    }
}

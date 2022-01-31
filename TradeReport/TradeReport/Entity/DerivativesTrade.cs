using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeReport.Entity
{
    public class DerivativesTrade: Trade
    {
        [Format("yyyyMMdd")]
        public DateTime Maturity { get; set; }

        // TODO: There are some Derivatives-specified properties
        // e.g. Strike price, spok price, info of underlying assest
        //
        // Since diff instructment have its own properties,
        // You probably need one trade model for one instrument 
        // SuperClass: DerivativesTrade
        // SubClass: SwapTrade, BondFuturesTrade, InterestRateSwapTrade
        // 
        // If do so, coresponding DTOs needed too
    }
}

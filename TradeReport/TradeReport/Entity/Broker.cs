using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeReport.Entity
{
    public class Broker: BaseEntity
    {
        public string Name { get; set; }
    }
}

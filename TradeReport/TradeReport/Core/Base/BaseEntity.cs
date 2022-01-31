using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeReport.Core.Interface;

namespace TradeReport.Entity
{
    public class BaseEntity: IEntity
    {
        public int Id { get; set; }
    }
}

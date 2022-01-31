using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeReport.Common.Extension
{
    public static class IEnumerableEx
    { 
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self) 
            => self.Select((item, index) => (item, index));
    }
}

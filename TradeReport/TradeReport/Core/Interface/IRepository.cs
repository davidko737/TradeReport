using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeReport.Core.Interface;

namespace TradeReport.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        List<T> GetAll();
        T GetBy(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeReport.Common;
using TradeReport.Entity;

namespace TradeReport.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        public List<Product> GetAll()
        {
            return TRData.Products;
        }

        public Product GetBy(int id)
        {
            return TRData.DictProducts[id];
        }

        public Product GetBy(string name)
        {
            Product product = TRData.Products
                .Where(x => x.Name == name)
                .ToList()
                .First();
            return product;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext dbContext;

        public EFProductRepository(ApplicationDbContext dbContext){
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> Products => dbContext.Products;
    }
}

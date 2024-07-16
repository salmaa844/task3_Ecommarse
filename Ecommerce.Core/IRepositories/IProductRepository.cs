using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepositories
{
    public  interface IProductRepository : IGenricRepositorycs<Products> 
    {
        // public Task GetAllProductaByCategoryId();
       
        public Task<IEnumerable<Products>> GetAllProductsByCategoryId(int Cat_Id);

    }
}

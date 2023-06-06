using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSC.Application;
using MSC.Application.csproj;

namespace MSC.Application
{
    internal interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(uint id);
        Task Add(Product product);
        Task Edit(Product product);
        Task Delete(uint id);
    }
}

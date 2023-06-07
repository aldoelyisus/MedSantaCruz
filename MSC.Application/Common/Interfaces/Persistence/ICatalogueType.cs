using MSC.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.Application.Common.Interfaces.Persistence
{
    public interface ICatalogueType
    {
        Task<IEnumerable<Product>> GetProductsByCategory(string category);
    }
}

using MSC.Domain.Catalogue.ValueObjects;
using MSC.Domain.Common.Models;
using MSC.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.Domain.Catalogue
{
    public class CatalogueType : AggregateRoot<CatalogueTypeId>
    {
        

        public string Name { get; set; } = null!;

        public virtual ICollection<Product.Product> Products { get; set; } = new List<Product.Product>();




        public CatalogueType(CatalogueTypeId id, string name, ICollection<Product.Product> products) : base(id)
        {
            Name = name;
            Products = products;

        }

        public static CatalogueType Create(CatalogueTypeId id, string name, ICollection<Product.Product> products)
        {
            return new CatalogueType(CatalogueTypeId.CreateUnique(), name, products);
        }




    }
}

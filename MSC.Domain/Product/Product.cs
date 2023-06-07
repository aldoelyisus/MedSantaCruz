using MSC.Domain.Catalogue;
using MSC.Domain.Common.Models;
using MSC.Domain.Product.ValueObjects;


namespace MSC.Domain.Product {

    public class Product : AggregateRoot<ProductId>
    {
        public string Category { get; set; } = null!;

        public string Catalogue { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string Description { get; set; } = null!;

        public uint Stock { get; set; }

        public uint Price { get; set; }

        public uint Cost { get; set; }

        public uint Discount { get; set; }

        public bool Featured { get; set; }

        public string ImgPath { get; set; } = null!;

        //  public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public virtual CatalogueType CatalogueNavigation { get; set; } = null!;

        // public virtual CategoryType CategoryNavigation { get; set; } = null!;


        private Product(ProductId id, string category, string catalogue, string name, string model, string brand,
            string description, uint stock, uint price, uint cost, uint discount, bool featured, string imgPath) : base(id)
        {

            Category = category;
            Catalogue = catalogue;
            Name = name;
            Model = model;
            Brand = brand;
            Description = description;
            Stock = stock;
            Price = price;
            Cost = cost;
            Discount = discount;
            Featured = featured;
            ImgPath = imgPath;

        }

        public static Product Create(ProductId id, string category, string catalogue, string name, string model, string brand,
            string description, uint stock, uint price, uint cost, uint discount, bool featured, string imgPath)
        {
            return new(ProductId.CreateUnique(), category, catalogue, name, model, brand, description, stock, price, cost, discount, featured, imgPath);
        }

    }

}
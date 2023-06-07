using MSC.Domain.Common.Models;
using MSC.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.Domain.Product.ValueObjects
{
    public sealed class ProductId : ValueObject
    {
        public Guid Value { get; }

        private ProductId(Guid value)
        {
            Value = value;
        }

        public static ProductId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

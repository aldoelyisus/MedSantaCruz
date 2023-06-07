using MSC.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.Domain.Catalogue.ValueObjects
{
        public sealed class CatalogueTypeId : ValueObject
        {
            public Guid Value { get; }

            private CatalogueTypeId(Guid value)
            {
                Value = value;
            }

            public static CatalogueTypeId CreateUnique() => new(Guid.NewGuid());

            public override IEnumerable<object> GetEqualityComponents()
            {
                yield return Value;
            }
        }
    
}

using System;
using System.Collections.Generic;

namespace ddc_sample_app.Shared
{
    public class ComponentCollection : List<Type>
    {
        public ComponentCollection() : base() { }

        public ComponentCollection(IEnumerable<Type> components) : base(components) { }
    }
}

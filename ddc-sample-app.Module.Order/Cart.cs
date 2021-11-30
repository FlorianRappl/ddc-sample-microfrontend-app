using System.Collections.Generic;

namespace ddc_sample_app.Module.Order
{
    public class Cart
    {
        public ICollection<CartEntry> Games { get; init; }

        public Cart() => Games = new List<CartEntry>();

        public void Clear() => Games.Clear();
    }
}

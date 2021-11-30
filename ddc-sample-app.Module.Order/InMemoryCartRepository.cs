namespace ddc_sample_app.Module.Order
{
    public class InMemoryCartRepository : ICartRepository
    {
        private readonly Cart _cart = new();

        public Cart Get() => _cart;

        public void AddGame(CartEntry game) => Get().Games.Add(game);

        public bool HasGame(CartEntry game) => Get().Games.Contains(game);

        public void ClearCart() => _cart.Clear();
    }
}

namespace ddc_sample_app.Module.Order
{
    public interface ICartRepository
    {
        Cart Get();

        void AddGame(CartEntry game);

        bool HasGame(CartEntry game);

        void ClearCart();
    }
}

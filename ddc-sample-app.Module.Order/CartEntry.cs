namespace ddc_sample_app.Module.Order
{
    public record CartEntry
    {
        public int GameId { get; set; }

        public decimal Price { get; set; }
    }
}
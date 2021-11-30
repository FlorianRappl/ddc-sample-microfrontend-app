namespace ddc_sample_app.Module.Discover
{
    public record Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}
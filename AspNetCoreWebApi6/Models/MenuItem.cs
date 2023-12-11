namespace AspNetCoreWebApi6.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime LastUpdated { get; set; }

        public string? Category { get; set; }

        public string? Origin { get; set; }

        public string? Supplier { get; set; }

        public int StockQuantity { get; set; }

        public int MinimumStockThreshold { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string? ImageUrl { get; set; }

    }




}

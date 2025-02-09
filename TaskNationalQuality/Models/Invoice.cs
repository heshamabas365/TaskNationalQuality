namespace TaskNationalQuality.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal? Total { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<ProductInvoice>? ProductInvoices { get; set; }
    }
}

namespace TaskNationalQuality.ViewModels.Invoice
{
    public class CreateInvoiceViewModel
    {
        public int UserId { get; set; }

        public List<int> ProductIds { get; set; }
        public List<TaskNationalQuality.Models.Product> Products { get; set; }
    }
}

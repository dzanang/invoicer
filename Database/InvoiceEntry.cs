namespace Database
{
    public class InvoiceEntry
    {
        public int Id { get; set; }
        public virtual Article Article { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}

namespace NETLAB14_DAEA.Models.Requets
{
    public class InvoiceInsertRequest
    {
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set; }
    }
}

namespace NETLAB14_DAEA.Models.Requets
{
    public class InvoiceInsertRequestV3
    {
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set; }
    }
}

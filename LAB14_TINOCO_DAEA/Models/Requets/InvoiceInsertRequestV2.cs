using LAB14_TINOCO_DAEA.Models;

namespace NETLAB14_DAEA.Models.Requets
{
    public class InvoiceInsertRequestV2
    {
        public int CustomerID { get; set; }
        public List<InvoiceInsertRequestV3> requestInvoiceV3s { get; set; }
        
    }
}

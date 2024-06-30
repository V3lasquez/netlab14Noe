namespace NETLAB14_DAEA.Models.Requets
{
    public class CustomerUpdateNumeroDocumento
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string DocumentNumber { get; set; }
        public bool Active { get; set; } = true;
    }
}

namespace Matrix.Model.Customer
{
    public class CustomerList
    {
        public IEnumerable<Entity.Customer> Customers { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}

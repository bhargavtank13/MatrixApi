using Matrix.Model.RegionalSaleDirector;


namespace Matrix.Model.SalesRep
{
    public class SalesRepListDto
    {
        public string SaleRepName { get; set; }

        public string SaleRepEmail { get; set; }

        public Guid RegionalSaleDirectorId { get; set; }
        public RegionalSaleDirectorDto RegionalSaleDirector { get; set; }
    }
}

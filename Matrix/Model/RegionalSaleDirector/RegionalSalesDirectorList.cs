namespace Matrix.Model.RegionalSaleDirector
{
    public class RegionalSalesDirectorList
    {
        public IEnumerable<Entity.RegionalSaleDirector> RegionalSaleDirectors { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }

}

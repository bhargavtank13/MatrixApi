using Matrix.Enum;
using System.ComponentModel.DataAnnotations;

namespace Matrix.Entity
{
    public class Sales : BaseEntity
    {
        [Key]
        public Guid SalesId { get; set; }
        public DateOnly Date { get; set; }
        public int QuoteNumber { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid SaleRepId { get; set; }
        public SalesRep SalesRep { get; set; }
        public Guid RegionalSaleDirectorId { get; set; }
        public RegionalSaleDirector RegionalSaleDirector { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string RFQNotes { get; set; }
        public string SourcingNotes { get; set; }
        public int SuggestedSalesPrice { get; set; }
        public int HTSCode { get; set; }
        public string CountryOfOrigin { get; set; }
        public string FreightTerms { get; set; }
        public string FobPoint { get; set; }
        public string AdditionalNotes { get; set; }
        public RFQStatus RFQStatus{ get; set; }

    }
}

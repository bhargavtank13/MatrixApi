using Matrix.Enum;
using System.ComponentModel.DataAnnotations;

namespace Matrix.Entity
{
    public class RepeatItem : BaseEntity
    {
        [Key]
        public Guid RepeatItemId { get; set; }
        public Guid SalesId { get; set; }
        public Sales Sales { get; set; }
        public ItemType ItemType { get; set; }
        public int CurrentItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public Guid ItemGroupId { get; set; }
        public ItemGroup ItemGroup { get; set; }
        public string Dimensions { get; set; }
        public int EstimatedAnnualUsage { get; set; }
        public int EstimatedCustomerSpend { get; set; }
        public string ItemNotes { get; set; }
        public int Cost { get; set; }
        public PriceUnit PriceUnit { get; set; }
        public string MOQ { get; set; }
        public int OrderMultiple { get; set; }
        public string LeadTIme { get; set; }
        public int PalletSize { get; set; }
        public int PalletQTY { get; set; }
        public UOMType UOMType1 { get; set; }
        public int QTY1 { get; set; }
        public UOMType UOMType2 { get; set; }
        public int QTY2 { get; set; }
        public UOMType UOMType3 { get; set; }
        public int QTY3 { get; set; }
        public Boolean IsCheckd { get; set; }
        public string FullSkidDimensions { get; set; }
        public int Weight { get; set; }
        public int MinQty { get; set; }
        public int Price { get; set; }
        public string PackagingAndQtyPallet { get; set; }
        public int SetupCharge { get; set; }
    }
}

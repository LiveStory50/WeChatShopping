namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderBillChi")]
    public partial class OrderBillChi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string ProCode { get; set; }

        [StringLength(10)]
        public string UnitPrice { get; set; }

        public int? Qty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SunPrice { get; set; }

        [StringLength(10)]
        public string IsReview { get; set; }

        public virtual OrderBillFath OrderBillFath { get; set; }

        public virtual Product Product { get; set; }
    }
}

namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notice")]
    public partial class Notice
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Body { get; set; }

        [Required]
        [StringLength(10)]
        public string PostUserId { get; set; }

        public DateTime ModiTime { get; set; }
    }
}

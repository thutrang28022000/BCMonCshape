namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(5)]
        public string ProductID { get; set; }

        [StringLength(5)]
        public string CategoryID { get; set; }

        [StringLength(255)]
        public string ProductName { get; set; }

        public decimal? UnitCost { get; set; }

        public int? Quantity { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public virtual Category Category { get; set; }
    }
}

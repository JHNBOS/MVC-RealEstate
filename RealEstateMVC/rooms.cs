namespace RealEstateMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rooms
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string property_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(70)]
        public string name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal area_size { get; set; }

        [Required]
        [StringLength(200)]
        public string image { get; set; }
    }
}

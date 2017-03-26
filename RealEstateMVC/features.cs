namespace RealEstateMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class features
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int property_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(70)]
        public string name { get; set; }

        [Required]
        [StringLength(210)]
        public string description { get; set; }
    }
}

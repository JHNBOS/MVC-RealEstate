namespace RealEstateMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class properties
    {
        [Key]
        public int property_id { get; set; }

        [Required]
        [StringLength(70)]
        public string type { get; set; }

        [Required]
        [StringLength(70)]
        public string city { get; set; }

        [Required]
        [StringLength(70)]
        public string country { get; set; }

        [Required]
        [StringLength(10)]
        public string built_year { get; set; }

        public int number_of_rooms { get; set; }

        [Column(TypeName = "numeric")]
        public decimal area_size { get; set; }

        [Column(TypeName = "numeric")]
        public decimal price { get; set; }

        [Required]
        [StringLength(210)]
        public string image { get; set; }

        [Required]
        [StringLength(120)]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string postal { get; set; }

        [Required]
        [StringLength(70)]
        public string owned_by { get; set; }
    }
}

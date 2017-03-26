namespace RealEstateMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class users
    {
        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(70)]
        public string first_name { get; set; }

        [Required]
        [StringLength(70)]
        public string last_name { get; set; }

        [Required]
        [StringLength(70)]
        public string city { get; set; }

        [Required]
        [StringLength(70)]
        public string country { get; set; }

        [Required]
        [StringLength(70)]
        public string birth_date { get; set; }

        [Required]
        [StringLength(70)]
        public string gender { get; set; }

        [Required]
        [StringLength(70)]
        public string email { get; set; }

        [Required]
        [StringLength(70)]
        public string phone { get; set; }

        [Required]
        [StringLength(70)]
        public string type { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }
    }
}

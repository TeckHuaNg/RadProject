namespace RADProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vehicle")]
    public partial class Vehicle
    {
        
        public int VehicleId { get; set; }

        [Display(Name = "Make")]
        public int MakeId { get; set; }

        [Display(Name = "Model")]
        public int ModelId { get; set; }

        public short Year { get; set; }

        public int Price { get; set; }

        [Display(Name = "Sold Date")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? SoldDate { get; set; }

        [StringLength(1024)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public virtual Model Model { get; set; }
        public virtual Make Make { get; set; }
    }
}

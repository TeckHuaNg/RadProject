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


        [Display(Name = "Year")]
        public short modelYear { get; set; }

        public int Price { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Sold Date")]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime? SoldDate { get; set; }

        [Display(Name = "Image")]
        [StringLength(1024)]
        public string ImageUrl { get; set; }

        public virtual Make Make { get; set; }

        public virtual Model Model { get; set; }
    }
}

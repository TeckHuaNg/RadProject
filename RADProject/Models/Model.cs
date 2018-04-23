namespace RADProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Model")]
    public partial class Model
    {
        public int ModelId { get; set; }

        [Display(Name = "Engine Size")]
        public decimal EngineSize { get; set; }

        [Display(Name = "Number Of Doors")]
        public int NumberOfDoors { get; set; }


        [Required]
        [StringLength(50)]
        public string Colour { get; set; }

        [Display(Name = "Vehicle Type")]
        public int VehicleTypeId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual VehicleType VehicleType { get; set; }
    }
}

namespace RADProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Make")]
    public partial class Make
    {
        public int MakeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}

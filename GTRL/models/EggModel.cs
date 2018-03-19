using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTARL.models
{
    [Table("Eggs")]
    public class EggModel
    {
        [Key]
        [Column("id", Order = 1)]
        public int EggId { get; set; }

        [Column("posx", Order = 2), Required]
        public float PositionX { get; set; }

        [Column("posy", Order = 3), Required]
        public float PositionY { get; set; }

        [Column("posz", Order = 4), Required]
        public float PositionZ { get; set; }

        [Column("rotx", Order = 5), Required]
        public float RotationX { get; set; }

        [Column("roty", Order = 6), Required]
        public float RotationY { get; set; }

        [Column("rotz", Order = 7), Required]
        public float RotationZ { get; set; }

        [Column("user", Order = 8, TypeName = "char"), StringLength(255), Required]
        public string User { get; set; }

    }
}

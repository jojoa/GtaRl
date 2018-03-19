using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTARL.models
{
    [Table("EggsFound")]
    public class EggFoundModel
    {
        [Key]
        [Column("id", Order = 1)]
        public int EggId { get; set; }

        [Column("EggID", Order = 2), Required]
        public int EggID { get; set; }

        [Column("user", Order = 3, TypeName = "char"), StringLength(255), Required]
        public string Name { get; set; }

     

    }
}

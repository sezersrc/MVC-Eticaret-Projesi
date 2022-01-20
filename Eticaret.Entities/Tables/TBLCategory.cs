using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    [Table("TBLCategory")]
    public class TBLCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [StringLength(50)] public string Name { get; set; }

        [StringLength(60)] public string CategorySeo { get; set; }

        public bool? Status { get; set; }
        public byte MenuOrder { get; set; } // Sirası 

        public virtual ICollection<TBLProduct> TBLProducs { get; set; }
    }
}
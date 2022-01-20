using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    [Table("TBLImages")]
    public class TBLImages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int imageID { get; set; }

        public int ProductID { get; set; }

        [StringLength(50)] public string images { get; set; }

        public virtual TBLProduct TBLProducts { get; set; }
    }
}
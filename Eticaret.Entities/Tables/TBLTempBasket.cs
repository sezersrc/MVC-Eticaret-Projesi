using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    [Table("TBLTempBasket")]
    public class TBLTempBasket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BasketID { get; set; }

        public int CookiesID { get; set; }
        public int ProductID { get; set; }

        [StringLength(50)] public string Name { get; set; }

        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public byte Piece { get; set; }

        [StringLength(35)] public string images { get; set; }
    }
}
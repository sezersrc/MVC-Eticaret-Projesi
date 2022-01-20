using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    //ComponentModel => Manage Nugget Gir  Yükle.

    [Table("TBLProduct")]
    public class TBLProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        [StringLength(50, MinimumLength = 10, ErrorMessage = "Ürün Başlığı 10 - 50 karakter arasında olmalıdır.")]
        public string Name { get; set; }
        public string Details { get; set; }
        public string  ShortDetails { get; set; }


        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public byte Stock { get; set; }


        [StringLength(35)] public string images { get; set; }



        public bool Status { get; set; }
        public virtual TBLCategory TBLCategory { get; set; }
        public virtual ICollection<TBLImages> TBLImages { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    // Üyeliksiz Alış Veriş Yapan Müşteri Bilgileri
    [Table("TBLNoMemberShip")]
    public class TBLNoMemberShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }
}
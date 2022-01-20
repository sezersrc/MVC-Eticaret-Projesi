using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    [Table("TBLOrder")]
    public class TBLOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        public decimal CargoPrice { get; set; }
        public int MusteriID { get; set; }
        public decimal TotalPrice { get; set; }
        public int KDV { get; set; }

        [StringLength(15)]
        //Kredi Kartı, Havale, Kapıda ödeme
        public string PaymentType { get; set; }

        public DateTime? PaymentTime { get; set; }

        [StringLength(35)]
        public string CargoNumber { get; set; }

        [StringLength(35)] // Bekleniyor,Kargoya Verildi,Ödeme Bekleniyor,Onaylandı.
        public string OrderStatus { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    [Table("TBLCustomer")]
    public class TBLCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [StringLength(50)] public string NSurname { get; set; }

        [StringLength(30)] public string Email { get; set; }

        [StringLength(30)] public string Phone { get; set; }

        [StringLength(20)] public string Password { get; set; }

        public virtual ICollection<TBLCustomerAddress> TBLCustomerAddress { get; set; }
    }
}
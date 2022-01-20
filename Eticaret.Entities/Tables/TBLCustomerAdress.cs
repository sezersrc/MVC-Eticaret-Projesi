using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    [Table("TBLCustomerAddress")]
    public class TBLCustomerAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int CustomerID { get; set; }

        [StringLength(35)] public string AddressName { get; set; }

        [StringLength(35)] public string City { get; set; }

        [StringLength(35)] public string District { get; set; }

        [StringLength(200)] public string FullAddress { get; set; }

        public virtual TBLCustomer TBLCustomer { get; set; }
    }
}
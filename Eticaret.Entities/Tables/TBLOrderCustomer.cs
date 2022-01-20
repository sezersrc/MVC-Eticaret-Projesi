using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    [Table("TBLOrderCustomer")]
    public class TBLOrderCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderID { get; set; }
        public string NameSurName { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(35)]
        public string City { get; set; }

        [StringLength(35)]
        public string District { get; set; }

        [StringLength(200)]
        public string FullAddress { get; set; }
    }
}
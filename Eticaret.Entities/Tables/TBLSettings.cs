using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Entities
{
    [Table("TBLSettings")]
    public class TBLSettings
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(60)] public string Name { get; set; }
        [StringLength(30)] public string Phone { get; set; }
        [StringLength(30)] public string CellPhone { get; set; }
        [StringLength(35)] public string Logo { get; set; }
        [StringLength(35)] public string Facebook { get; set; }
        [StringLength(35)] public string Instagram { get; set; }
        [StringLength(35)] public string YouTube { get; set; }
        [StringLength(35)] public string Twitter { get; set; }
        [StringLength(30)] public string VergiDairesi { get; set; }
        [StringLength(10)] public string VergiNO { get; set; }
        [StringLength(30)] public string Email { get; set; }    
        [StringLength(35)] public string City { get; set; }
        [StringLength(35)] public string District { get; set; }
        [StringLength(200)] public string CompanyAdress { get; set; }
        [StringLength(20)] public string Password { get; set; }
    }






}

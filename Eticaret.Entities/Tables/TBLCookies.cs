using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    [Table("TBLCookies")]
    public class TBLCookies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GCookiesID { get; set; }

        public int OlusturulanID { get; set; }
    }
}
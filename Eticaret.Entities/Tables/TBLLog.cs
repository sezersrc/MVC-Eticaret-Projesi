using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Entities
{
    [Table("TBLLog")]
    public class TBLLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogID { get; set; }

        [StringLength(100)] public string Logs { get; set; }

        [StringLength(100)] public string ErrorMessage { get; set; }

        public DateTime? Datetime { get; set; }
        public int UserCookies { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Entities
{
    [Table("TBLBlog")]
    public class TBLBlog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogID { get; set; }

        [StringLength(50)] public string BlogName { get; set; }

        public string BlogDetails { get; set; }

        [StringLength(60)] public string BlogSeo { get; set; }

        public string BlogImage { get; set; }
    }
}

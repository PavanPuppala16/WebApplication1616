using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1616.Models
{
    public class Files1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}

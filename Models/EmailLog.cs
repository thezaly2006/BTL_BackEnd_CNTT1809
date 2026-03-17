using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models
{
    [Table("EmailLogs")]
    public class EmailLog
    {
        [Key]
        public int EmailLogID { get; set; }

        [Display(Name = "Hội viên")]
        public int MemberID { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại email")]
        public string? EmailType { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;

        [StringLength(20)]
        [Display(Name = "Trạng thái")]
        public string? Status { get; set; }

        [StringLength(500)]
        [Display(Name = "Lỗi")]
        public string? ErrorMessage { get; set; }

        [ForeignKey("MemberID")]
        public virtual Member? Member { get; set; }
    }
}
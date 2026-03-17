using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models
{
    [Table("CheckInLogs")]
    public class CheckInLog
    {
        [Key]
        public int LogID { get; set; }

        [Display(Name = "Hội viên")]
        public int MemberID { get; set; }

        [Display(Name = "Giờ vào")]
        public DateTime CheckInTime { get; set; } = DateTime.Now;

        [Display(Name = "Giờ ra")]
        public DateTime? CheckOutTime { get; set; }

        [StringLength(50)]
        [Display(Name = "Số thẻ")]
        public string? CardNo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("MemberID")]
        public virtual Member? Member { get; set; }
    }
}
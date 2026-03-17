using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models
{
    [Table("PTSchedules")]
    public class PTSchedules
    {
        [Key]
        public int ScheduleID { get; set; }

        [Display(Name = "PT")]
        public int PTID { get; set; }

        [Display(Name = "Hội viên")]
        public int MemberID { get; set; }

        [Required]
        [Display(Name = "Ngày")]
        [DataType(DataType.Date)]
        public DateTime ScheduleDate { get; set; }

        [Required]
        [Display(Name = "Giờ bắt đầu")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "Giờ kết thúc")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại buổi")]
        public string? SessionType { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? Notes { get; set; }

        [StringLength(20)]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; } = "Scheduled";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("PTID")]
        public virtual PersonalTrainer? PersonalTrainer { get; set; }

        [ForeignKey("MemberID")]
        public virtual Member? Member { get; set; }
    }
}
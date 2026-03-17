using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models
{
    [Table("Members")]
    public class Member
    {
        [Key]
        public int MemberID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone]
        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(200)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Số thẻ")]
        public string MembershipCardNo { get; set; }

        [Display(Name = "Loại gói tập")]
        public int? MembershipTypeID { get; set; }

        [Display(Name = "Ngày bắt đầu")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "Ngày hết hạn")]
        public DateTime? EndDate { get; set; }

        [StringLength(20)]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("MembershipTypeID")]
        public virtual MembershipType? MembershipType { get; set; }

        public virtual ICollection<PTSchedules> PTSchedules { get; set; } = new List<PTSchedules>();
        public virtual ICollection<CheckInLog> CheckInLogs { get; set; } = new List<CheckInLog>();
    }
}
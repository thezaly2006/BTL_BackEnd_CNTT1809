using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models
{
    [Table("PersonalTrainers")]
    public class PersonalTrainer
    {
        [Key]
        public int PTID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Phone]
        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string? Phone { get; set; }

        [StringLength(200)]
        [Display(Name = "Chuyên môn")]
        public string? Specialization { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Giá/giờ (VNĐ)")]
        public decimal? HourlyRate { get; set; }

        [Display(Name = "Sẵn sàng")]
        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<PTSchedules> PTSchedules { get; set; } = new List<PTSchedules>();
    }
}
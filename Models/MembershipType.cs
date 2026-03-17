using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models
{
    [Table("MembershipTypes")]
    public class MembershipType
    {
        [Key]
        public int MembershipTypeID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên gói tập")]
        public string TypeName { get; set; }

        [Required]
        [Display(Name = "Thời hạn (ngày)")]
        public int DurationDays { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Giá (VNĐ)")]
        public decimal Price { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}
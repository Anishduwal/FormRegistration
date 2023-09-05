using System.ComponentModel.DataAnnotations;

namespace Campaign.Models
{
    public class OrganizationModel
    {
        public int Id { get; set; }
        [Required]
        public string? OrganizationName { get; set; }
        [Required]
        public string? FullAddress { get; set; }
        public string? EmailAddress { get; set; }
        [Required]
        public string? MobileNo { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? DirectorName { get; set; }
        public string? VatPanNumber { get; set; }
        public IFormFile? VatPanImage { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedLocalDate { get; set; }
        public DateTime CreatedUtcDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedLocalDate { get; set; }
        public DateTime UpdatedUtcDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace HealthCareWebApp.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactInfo { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<Prescription>? Prescriptions { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;



namespace HealthCareWebApp.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Specialty { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactInfo { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }


        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<Prescription>? Prescriptions { get; set; }
    }
}

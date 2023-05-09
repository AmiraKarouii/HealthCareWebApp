using System.ComponentModel.DataAnnotations;

namespace HealthCareWebApp.Models
{
    public class Prescription
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Dosage { get; set; }

        [Required]
        [StringLength(200)]
        public string Instructions { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }

        public int PatientId { get; set; }
        public virtual Patient? Patient { get; set; }

    }
}

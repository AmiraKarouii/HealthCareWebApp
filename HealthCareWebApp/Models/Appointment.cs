﻿using System.ComponentModel.DataAnnotations;

namespace HealthCareWebApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }

        public int PatientId { get; set; }
        public  virtual Patient? Patient { get; set; }
    }
}

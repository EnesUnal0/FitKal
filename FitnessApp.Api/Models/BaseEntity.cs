using System;

namespace FitnessApp.Api.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public string? CreatedBy { get; set; } 
        public string? UpdatedBy { get; set; } 
    }
}
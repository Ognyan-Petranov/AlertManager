using System;
using System.ComponentModel.DataAnnotations;

namespace AlertManager.Domain.Models
{
    public class Alert
    {
        public Alert(string condition)
        {
            Condition = condition;
            AlertId = Guid.NewGuid().ToString();
        }

        [Key]
        public string AlertId { get; set; }

        [Required]
        public string Condition { get; private set; }

        public bool IsValid { get; set; }

        public bool IsOpen { get; set; }
    }
}

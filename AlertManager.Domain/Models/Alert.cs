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
            // As i dont remember the exact task and didn't get the chance to copy it,
            // i am setting IsOpen default value to true, as it makes sense to me.
            IsOpen = true;
        }

        [Key]
        public string AlertId { get; set; }

        [Required]
        public string Condition { get; private set; }

        public bool IsValid { get; set; }

        public bool IsOpen { get; set; }
    }
}

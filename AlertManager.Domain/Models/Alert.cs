using System.ComponentModel.DataAnnotations;

namespace AlertManager.Domain.Models
{
    public class Alert : Entity
    {
        public Alert(string condition)
            : base()
        {
            Condition = condition;
            IsOpen = true;
        }

        [Required]
        public string Condition { get; private set; }

        public bool IsValid { get; set; }

        public bool IsOpen { get; private set; }
    }
}

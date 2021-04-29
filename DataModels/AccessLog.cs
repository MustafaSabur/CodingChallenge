using System;
using System.ComponentModel.DataAnnotations;

namespace Challenge.DataModels
{
    public class AccessLog
    {
        private const int MaximumAttempsAllowed = 3;

        [Key]
        public int Id { get; set; }

        [Required]
        public int NumberOfAttempts { get; set; }
    }
}

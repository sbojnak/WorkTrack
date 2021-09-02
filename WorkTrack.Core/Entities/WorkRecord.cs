using System;
using System.ComponentModel.DataAnnotations;

namespace WorkTrack.Core.Entities
{
    public class WorkRecord
    {
        public int Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public string Description { get; set; }
    }
}

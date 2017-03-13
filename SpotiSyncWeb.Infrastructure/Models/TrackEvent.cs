using System;
using System.ComponentModel.DataAnnotations;

namespace SpotiSyncWeb.Infrastructure.Models
{
    public class TrackEvent
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }
    }
}

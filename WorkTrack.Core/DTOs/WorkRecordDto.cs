using System;
using System.ComponentModel.DataAnnotations;

namespace WorkTrack.Core.DTOs
{
    public record WorkRecordDto(int Id, [Required] DateTime Start, [Required] DateTime End, string Description);
}

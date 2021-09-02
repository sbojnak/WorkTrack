using System;

namespace WorkTrack.Api.Models
{
    public record AddWorkRecordInput(DateTime Start, DateTime End, string Description);
}

using System;

namespace LeadTracking.Core.Data
{
    public interface IAuditable
    {
        DateTime CreatedOnUtc { get; set; }
        DateTime? LastUpdateOnUtc { get; set; }
    }
}

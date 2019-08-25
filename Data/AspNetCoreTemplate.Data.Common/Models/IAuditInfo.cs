namespace TShirtShop.Data.Common.Models
{
    using System;
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; }

        DateTime? ModifiedOn { get; set; }
    }
}

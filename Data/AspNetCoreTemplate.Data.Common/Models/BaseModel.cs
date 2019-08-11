namespace TShirtShop.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
   

    public abstract class BaseMode<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

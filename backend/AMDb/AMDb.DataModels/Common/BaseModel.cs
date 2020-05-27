namespace AMDb.DataModels.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BaseModel<Tkey> : IAuditInfo
    {
        [Key]
        public Tkey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

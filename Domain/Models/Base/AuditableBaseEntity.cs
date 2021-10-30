using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public abstract class AuditableBaseEntity : BaseEntity
    {
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual string LastModifiedBy { get; set; }
        public virtual DateTime LastModifiedOn { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModifed { get; set; }
    }
}

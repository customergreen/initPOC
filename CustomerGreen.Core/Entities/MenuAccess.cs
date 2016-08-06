using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerGreen.Core.Entities
{
    [Table("MenuAccess")]
    public class MenuAccess : AuditableEntity
    {
        public virtual Menu Menu { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
    }
}
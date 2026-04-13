using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

namespace UniTaskFlow01.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Collaboration")]
    public class TaskAttachment : BaseObject
    {
        public virtual string Name { get; set; }

        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public virtual FileData File { get; set; }

        // --- RELATIONSHIPS ---
        public virtual OfficeTask Task { get; set; }
    }
}
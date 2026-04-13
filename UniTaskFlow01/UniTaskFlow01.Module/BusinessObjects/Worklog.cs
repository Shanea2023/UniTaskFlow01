using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;

namespace UniTaskFlow01.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Collaboration")]
    public class WorkLog : BaseObject
    {
        public virtual double HoursSpent { get; set; }
        public virtual DateTime DateLogged { get; set; } = DateTime.Today;
        public virtual string Description { get; set; }

        // --- RELATIONSHIPS ---
        public virtual ApplicationUser LoggedBy { get; set; }
        public virtual OfficeTask Task { get; set; }
    }
}